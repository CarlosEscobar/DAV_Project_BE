using dav_project_api.data_access.Context;
using dav_project_api.data_access.Entities;
using dav_project_api.data_access.Repositories;
using System.Threading.Tasks;

namespace dav_project_api.data_access.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DavProjectContext dbContext;
        public GenericRepository<GroceryItem> GroceryItemRepository { get; private set; }
        public GenericRepository<GroceryItemGroceryList> GroceryItemGroceryListRepository { get; private set; }
        public GenericRepository<GroceryItemRecipe> GroceryItemRecipeRepository { get; private set; }
        public GenericRepository<GroceryList> GroceryListRepository { get; private set; }
        public GenericRepository<Recipe> RecipeRepository { get; private set; }
        public GenericRepository<Reminder> ReminderRepository { get; private set; }
        public GenericRepository<User> UserRepository { get; private set; }

        public UnitOfWork(DavProjectContext context)
        {
            dbContext = context;
            GroceryItemRepository = new GenericRepository<GroceryItem>(dbContext);
            GroceryItemGroceryListRepository = new GenericRepository<GroceryItemGroceryList>(dbContext);
            GroceryItemRecipeRepository = new GenericRepository<GroceryItemRecipe>(dbContext);
            GroceryListRepository = new GenericRepository<GroceryList>(dbContext);
            RecipeRepository = new GenericRepository<Recipe>(dbContext);
            ReminderRepository = new GenericRepository<Reminder>(dbContext);
            UserRepository = new GenericRepository<User>(dbContext);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public async Task Commit()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
