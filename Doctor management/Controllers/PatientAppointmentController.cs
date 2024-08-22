using Doctor_management.interfaces;
using Doctor_management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Doctor_management.Controllers
{
	public class PatientAppointmentController : Controller
	{
		IDataAccess objDataAccess;

		public PatientAppointmentController(IDataAccess datobjDataAccessaac)
		{
			objDataAccess = datobjDataAccessaac;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult PatientAppointment()
		{
           
            return View();
		}

		
		[HttpGet]
		public JsonResult BindPatientName()
		{
            List<dropdown> dropdowns = objDataAccess.BindPatientNames();
			return Json(dropdowns);
        }

		[HttpGet]
		public JsonResult BindMedicinePres()
		{
			List<dropdown> dropdowns = objDataAccess.BindMedicinePres();
			return Json(dropdowns);
		}
		[HttpGet]		
		public JsonResult BindDiagnosticPres()
		{
			List<dropdown> dropdowns = objDataAccess.BindDiagnosticPres();
			return Json(dropdowns);
		}
	}
}
