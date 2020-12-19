using dav_project_api.data_access.Entities;
using dav_project_api.data_access.Repositories;
using System;
using System.Threading.Tasks;

namespace dav_project_api.data_access.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<GroceryItem> GroceryItemRepository { get; }
        GenericRepository<GroceryItemGroceryList> GroceryItemGroceryListRepository { get; }
        GenericRepository<GroceryItemRecipe> GroceryItemRecipeRepository { get; }
        GenericRepository<GroceryList> GroceryListRepository { get; }
        GenericRepository<Recipe> RecipeRepository { get; }
        GenericRepository<Reminder> ReminderRepository { get; }
        GenericRepository<User> UserRepository { get; }
        Task Commit();
    }
}
