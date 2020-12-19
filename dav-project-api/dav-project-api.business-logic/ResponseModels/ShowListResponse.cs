using System.Collections.Generic;

namespace dav_project_api.business_logic
{
    public class ShowListResponse : BaseResponse
    {
        public List<string> Items { get; set; }
    }
}
