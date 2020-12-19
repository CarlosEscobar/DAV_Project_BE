namespace dav_project_api.business_logic.Services
{
    public interface IRecipeService
    {
        public FindRecipeResponse DoFindRecipe(FindRecipe findRecipeModel);
        public SelectRecipeResponse DoSelectRecipe(SelectRecipe selectRecipeModel);
    }
}
