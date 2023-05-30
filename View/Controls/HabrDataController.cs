using Microsoft.AspNetCore.Mvc;
using Model.Abstraction;
using Model.Types;
using System.Runtime.CompilerServices;

namespace View.Controls
{
    [Controller]
    public class HabrDataShower : Controller
    {
        private readonly IAsyncArticleDataSourse _arctickSourse;

        public HabrDataShower(IAsyncArticleDataSourse arctickSourse)
        {
            _arctickSourse = arctickSourse;
        }

        [HttpGet]
        [Route("/")]
        public async Task<IActionResult> GetHabrArticlsList()
        {
            var articls = await _arctickSourse.GetAvaliableArticlsAsync();
            return View(articls);
        } 

        public async IActionResult GetArticklComponent(Articl articl)
        {
            return PartialView( articl);
        }
    }
}
