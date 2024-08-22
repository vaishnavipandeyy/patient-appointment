using Doctor_management.interfaces;
using Doctor_management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace Doctor_management.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		IDataAccess objDataAccess;
		public HomeController(ILogger<HomeController> logger, IDataAccess dataac)
        {
            _logger = logger;
			objDataAccess = dataac;

		}

		public IActionResult Index()
        {
			if (HttpContext.Session.GetString("UserName") == null)
			{
				return RedirectToAction("Login", "Home");
			}
			if (HttpContext.Session.GetString("UserName") != null)
			{
				ViewBag.Data = HttpContext.Session.GetString("UserName").ToString();

			}
			return View();
        }
		

		public IActionResult Login()
        {
            return View();
        }
		[HttpPost]
		public IActionResult Login(string EMail, string Password)
		{
			ViewBag.Error = "";
			DataTable dt = objDataAccess.UserLogin(EMail, Password);
			if (dt != null && dt.Rows.Count > 0)
			{
				string UserName = dt.Rows[0]["Name"].ToString();
				int UserId = Convert.ToInt32(dt.Rows[0]["Uid"].ToString());
				HttpContext.Session.SetString("UserName", UserName.ToString());
				HttpContext.Session.SetString("UserId", Convert.ToString(UserId));
				return RedirectToAction("index", "Home");  
			}
			else
			{
				ViewBag.Error = "Invalid user email or password !";
			}
			return View();
		}
		[HttpGet]
		public IActionResult signup()
		{
			return View();
		}
        [HttpPost]
		public IActionResult signup(signup objsign) 
		{
            objDataAccess.usersignup(objsign);

			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
