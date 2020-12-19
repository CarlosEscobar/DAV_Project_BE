using System;
using Microsoft.AspNetCore.Mvc;
using dav_project_api.business_logic.Services;
using dav_project_api.business_logic;

namespace dav_project_api.Controllers
{
    [ApiController]
    [Route("grocerylist")]
    public class GroceryListController : ControllerBase
    {
        private IGroceryListService groceryListService;

        public GroceryListController(IGroceryListService groceryListService)
        {
            this.groceryListService = groceryListService;
        }

        [HttpGet]
        public ActionResult DoShowList([FromBody] ShowList showListModel)
        {
            try
            {
                return Ok(groceryListService.DoShowList(showListModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult DoCreateList([FromBody] CreateList createListModel)
        {
            try
            {
                return Ok(groceryListService.DoCreateList(createListModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public ActionResult DoAddElementToList([FromBody] AddElement addElementModel)
        {
            try
            {
                return Ok(groceryListService.DoAddElementToList(addElementModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public ActionResult DoDeleteElementFromList([FromBody] DeleteElement deleteElementModel)
        {
            try
            {
                return Ok(groceryListService.DoDeleteElementFromList(deleteElementModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("clear")]
        public ActionResult DoClearList([FromBody] ClearList clearListModel)
        {
            try
            {
                return Ok(groceryListService.DoClearList(clearListModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
