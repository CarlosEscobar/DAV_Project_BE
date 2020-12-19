namespace dav_project_api.business_logic.Services
{
    public interface IGroceryListService
    {
        public CreateListResponse DoCreateList(CreateList createListModel);
        public AddElementResponse DoAddElementToList(AddElement addElementModel);
        public DeleteElementResponse DoDeleteElementFromList(DeleteElement deleteElementModel);
        public ShowListResponse DoShowList(ShowList showListModel);
        public ClearListResponse DoClearList(ClearList clearListModel);
    }
}