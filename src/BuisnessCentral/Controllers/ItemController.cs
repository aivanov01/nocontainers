using BuisnessCentral.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuisnessCentral.Controllers
{
    [Route("api/v1/[controller]")]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<CatalogItemModel?>> GetCatalogItem(string guid)
        {
            try
            {
                var item = await _itemService.GetItemAsync(guid);
                return Ok(item);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }
        [HttpPost]
        public async Task<ActionResult<int>> CreateItemAsync(CatalogItemModel model)
        {
            if (model is null)
                return NotFound("Cannot create an empty object");
            try
            {
                var id = await _itemService.CreateItemAsync(model);
                return Ok(Int32.Parse(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItemAsync(CatalogItemModel model)
        {
            if (model is null)
                return NotFound("Cannot create an empty object");

            try
            {
                await _itemService.UpdateItemAsync(model);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteItemAsync(string guid)
        {
            try
            {
                await _itemService.DeleteItemAsync(guid);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
