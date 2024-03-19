using Microsoft.AspNetCore.Mvc;

namespace Catalog_2.Controllers
{
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IResult Test() 
        {
            return Results.Ok("Успешно");
        }
    }
}
