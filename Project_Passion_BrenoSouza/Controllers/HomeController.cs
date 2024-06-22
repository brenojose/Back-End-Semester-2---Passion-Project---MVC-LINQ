using Microsoft.AspNetCore.Mvc;
using Project_Passion_BrenoSouza.Models;
using System.Diagnostics;

namespace Project_Passion_BrenoSouza.Controllers
{
    public class HomeController : Controller
    {
        //<summary>
        // Logger instance for the HomeController.
        //</summary>
        private readonly ILogger<HomeController> _logger;

        //<summary>
        // Constructor for HomeController that initializes the logger.
        //</summary>
        //<param name="logger">The logger instance.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //<summary>
        // Displays the home page.
        //</summary>
        //<returns>The Index view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        //<summary>
        // Displays the privacy policy page.
        //</summary>
        //<returns>The Privacy view.</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        //<summary>
        // Displays the error page with error information.
        //</summary>
        //<returns>The Error view with error details.</returns>
        //<example>
        // GET /Home/Error
        //</example>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
