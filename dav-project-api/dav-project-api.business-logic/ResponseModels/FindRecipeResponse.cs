using System.Collections.Generic;

namespace dav_project_api.business_logic
{
    public class FindRecipeResponse : BaseResponse
    {
        public List<string> Recipes { get; set; }
    }
}
