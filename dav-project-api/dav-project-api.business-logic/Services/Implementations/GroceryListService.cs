using dav_project_api.data_access.Entities;
using dav_project_api.data_access.UnitOfWork;
using System;
using System.Linq;

namespace dav_project_api.business_logic.Services
{
    public class GroceryListService : IGroceryListService
    {
        private IUnitOfWork unitOfWork;

        public GroceryListService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public CreateListResponse DoCreateList(CreateList createListModel)
        {
            try
            {
                using (unitOfWork)
                {
                    var theUser = unitOfWork.UserRepository.GetById(Guid.Parse(createListModel.Token));
                    if (theUser == null)
                    {
                        return new CreateListResponse()
                        {
                            ResponseMessage = "Error: Usuario no encontrado."
                        };
                    }

                    unitOfWork.GroceryListRepository.Create(new GroceryList()
                    {
                        Id = Guid.NewGuid(),
                        Name = createListModel.ListName.ToLower(),
                        UserId = theUser.Id
                    });
                    unitOfWork.Commit();

                    return new CreateListResponse()
                    {
                        ResponseMessage = "Success"
                    };
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public AddElementResponse DoAddElementToList(AddElement addElementModel)
        {
            try
            {
                using (unitOfWork)
                {
                    User theUser = unitOfWork.UserRepository.GetById(Guid.Parse(addElementModel.Token));
                    if (theUser == null)
                    {
                        return new AddElementResponse()
                        {
                            ResponseMessage = "Error: Usuario no encontrado."
                        };
                    }

                    GroceryList theList = theUser.GroceryLists.FirstOrDefault(list => list.Name == addElementModel.ListName.ToLower());
                    GroceryItem theItem = unitOfWork.GroceryItemRepository.GetAll().FirstOrDefault(item => item.Name == addElementModel.ElementName.ToLower());

                    if (theList == null)
                    {
                        return new AddElementResponse()
                        {
                            ResponseMessage = "Error: Lista no encontrada."
                        };
                    }
                    if (theItem == null)
                    {
                        return new AddElementResponse()
                        {
                            ResponseMessage = "Error: Producto no encontrado."
                        };
                    }

                    unitOfWork.GroceryItemGroceryListRepository.Create(new GroceryItemGroceryList()
                    {
                        GroceryListId = theList.Id,
                        GroceryItemId = theItem.Id
                    });
                    unitOfWork.Commit();

                    return new AddElementResponse()
                    {
                        ResponseMessage = "Success"
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DeleteElementResponse DoDeleteElementFromList(DeleteElement deleteElementModel)
        {
            try
            {
                using (unitOfWork)
                {
                    User theUser = unitOfWork.UserRepository.GetById(Guid.Parse(deleteElementModel.Token));
                    if (theUser == null)
                    {
                        return new DeleteElementResponse()
                        {
                            ResponseMessage = "Error: Usuario no encontrado."
                        };
                    }

                    GroceryList theList = theUser.GroceryLists.FirstOrDefault(list => list.Name == deleteElementModel.ListName.ToLower());
                    GroceryItem theItem = unitOfWork.GroceryItemRepository.GetAll().FirstOrDefault(item => item.Name == deleteElementModel.ElementName.ToLower());

                    if (theList == null)
                    {
                        return new DeleteElementResponse()
                        {
                            ResponseMessage = "Error: Lista no encontrada."
                        };
                    }
                    if (theItem == null)
                    {
                        return new DeleteElementResponse()
                        {
                            ResponseMessage = "Error: Producto no encontrado."
                        };
                    }

                    GroceryItemGroceryList theGroceryItemGroceryList = unitOfWork.GroceryItemGroceryListRepository.GetAll()
                                                                                                                  .FirstOrDefault(groceryItemGroceryList => groceryItemGroceryList.GroceryListId == theList.Id
                                                                                                                                                         && groceryItemGroceryList.GroceryItemId == theItem.Id);
                    unitOfWork.GroceryItemGroceryListRepository.Delete(theGroceryItemGroceryList);
                    unitOfWork.Commit();

                    return new DeleteElementResponse()
                    {
                        ResponseMessage = "Success"
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ShowListResponse DoShowList(ShowList showListModel)
        {
            try
            {
                using (unitOfWork)
                {
                    User theUser = unitOfWork.UserRepository.GetById(Guid.Parse(showListModel.Token));
                    if (theUser == null)
                    {
                        return new ShowListResponse()
                        {
                            ResponseMessage = "Error: Usuario no encontrado."
                        };
                    }

                    GroceryList theList = theUser.GroceryLists.FirstOrDefault(list => list.Name == showListModel.ListName);
                    if (theList == null)
                    {
                        return new ShowListResponse()
                        {
                            ResponseMessage = "Error: Lista no encontrada."
                        };
                    }

                    return new ShowListResponse()
                    {
                        ResponseMessage = "Success",
                        Items = theList.GroceryItemGroceryLists.Select(groceryItemGroceryList => groceryItemGroceryList.GroceryItem)
                                                               .Select(groceryItem => groceryItem.Name)
                                                               .ToList()
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClearListResponse DoClearList(ClearList clearListModel)
        {
            try
            {
                using (unitOfWork)
                {
                    User theUser = unitOfWork.UserRepository.GetById(Guid.Parse(clearListModel.Token));
                    if (theUser == null)
                    {
                        return new ClearListResponse()
                        {
                            ResponseMessage = "Error: Usuario no encontrado."
                        };
                    }

                    GroceryList theList = theUser.GroceryLists.FirstOrDefault(list => list.Name == clearListModel.ListName.ToLower());
                    if (theList == null)
                    {
                        return new ClearListResponse()
                        {
                            ResponseMessage = "Error: Lista no encontrada."
                        };
                    }

                    foreach (GroceryItemGroceryList groceryItemGroceryList in theList.GroceryItemGroceryLists)
                    {
                        unitOfWork.GroceryItemGroceryListRepository.Delete(groceryItemGroceryList);
                    }
                    unitOfWork.Commit();

                    return new ClearListResponse()
                    {
                        ResponseMessage = "Success"
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
