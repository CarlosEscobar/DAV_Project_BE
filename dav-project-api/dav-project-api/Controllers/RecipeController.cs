using System;
using Microsoft.AspNetCore.Mvc;
using dav_project_api.business_logic.Services;
using dav_project_api.business_logic;

namespace dav_project_api.Controllers
{
    [ApiController]
    [Route("recipe")]
    public class RecipeController : ControllerBase
    {
        private IRecipeService recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        [HttpGet]
        public ActionResult DoFindRecipe([FromBody] FindRecipe findRecipeModel)
        {
            try
            {
                return Ok(recipeService.DoFindRecipe(findRecipeModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult DoSelectRecipe([FromBody] SelectRecipe selectRecipeModel)
        {
            try
            {
                return Ok(recipeService.DoSelectRecipe(selectRecipeModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
