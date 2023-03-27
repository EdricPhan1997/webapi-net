using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Services;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IHangHoaResponsitory _hangHoaResponsitory;

        public ProductsController(IHangHoaResponsitory hangHoaResponsitory) {
            _hangHoaResponsitory = hangHoaResponsitory;
        }
        [HttpGet]
        public IActionResult GetAllProducts( string search, double? from, double? to ,string sortBy, int page = 1) 
        {
            try
            {
                var result = _hangHoaResponsitory.GetAll(search, from, to, sortBy); 
                return Ok(result);
            } catch
            {
                return BadRequest("We can not get the products list");
            }
        }
    }
}
