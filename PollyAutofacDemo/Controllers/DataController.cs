using Microsoft.AspNetCore.Mvc;
using PollyAutofacDemo.Services;

namespace PollyAutofacDemo.Controllers
{
    public class DataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IYourService _yourService;

        public DataController(IYourService yourService)
        {
            _yourService = yourService;
        }

        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var data = await _yourService.GetDataAsync();
            return Ok(data);
        }
    }
}
