using dav_project_api.data_access.Entities;
using dav_project_api.data_access.UnitOfWork;
using System;
using System.Linq;

namespace dav_project_api.business_logic.Services
{
    public class RecipeService : IRecipeService
    {
        private IUnitOfWork unitOfWork;

        public RecipeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public FindRecipeResponse DoFindRecipe(FindRecipe findRecipeModel)
        {
            try
            {
                using (unitOfWork)
                {
                    User theUser = unitOfWork.UserRepository.GetById(Guid.Parse(findRecipeModel.Token));
                    if (theUser == null)
                    {
                        return new FindRecipeResponse()
                        {
                            ResponseMessage = "Error: Usuario no encontrado."
                        };
                    }

                    GroceryList theList = theUser.GroceryLists.FirstOrDefault(list => list.Name == findRecipeModel.ListName.ToLower());
                    if (theList == null)
                    {
                        return new FindRecipeResponse()
                        {
                            ResponseMessage = "Error: Lista no encontrada."
                        };
                    }

                    return new FindRecipeResponse()
                    {
                        ResponseMessage = "Success",
                        Recipes = theList.GroceryItemGroceryLists.Select(groceryItemGroceryList => groceryItemGroceryList.GroceryItem)
                                                                 .SelectMany(groceryItem => groceryItem.GroceryItemRecipes)
                                                                 .Select(groceryItemRecipe => groceryItemRecipe.Recipe.Name)
                                                                 .Take(5)
                                                                 .ToList()
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SelectRecipeResponse DoSelectRecipe(SelectRecipe selectRecipeModel)
        {
            try
            {
                using (unitOfWork)
                {
                    User theUser = unitOfWork.UserRepository.GetById(Guid.Parse(selectRecipeModel.Token));
                    if (theUser == null)
                    {
                        return new SelectRecipeResponse()
                        {
                            ResponseMessage = "Error: Usuario no encontrado."
                        };
                    }

                    GroceryList theList = theUser.GroceryLists.FirstOrDefault(list => list.Name == selectRecipeModel.ListName.ToLower());
                    if (theList == null)
                    {
                        return new SelectRecipeResponse()
                        {
                            ResponseMessage = "Error: Lista no encontrada."
                        };
                    }

                    return new SelectRecipeResponse()
                    {
                        ResponseMessage = "Success",
                        RecipeName = theList.GroceryItemGroceryLists.Select(groceryItemGroceryList => groceryItemGroceryList.GroceryItem)
                                                                    .SelectMany(groceryItem => groceryItem.GroceryItemRecipes)
                                                                    .Select(groceryItemRecipe => groceryItemRecipe.Recipe.Name)
                                                                    .Take(5)
                                                                    .ToList()[selectRecipeModel.RecipeIndex]
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
