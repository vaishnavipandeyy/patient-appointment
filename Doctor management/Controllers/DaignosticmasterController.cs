using Doctor_management.interfaces;
using Doctor_management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Doctor_management.Controllers
{
	public class DaignosticmasterController : Controller
	{
		IDataAccess objDataAccess;
		
		public DaignosticmasterController(IDataAccess datobjDataAccessaac)
		{
			objDataAccess = datobjDataAccessaac;
		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult DaignosticMaster(int DMID)
		{
			string Mode = DMID == 0 ? "ALL" : "GET";
			ViewBag.BtnText = "Submit";
			if (DMID > 0)
			{


				List<daignostic> objGetEditData = new List<daignostic>();
				objGetEditData = objDataAccess.daignosticList(DMID, "GET");
				foreach (var items in objGetEditData)
				{
					ViewBag.isEditMode = 1;
					ViewBag.daignosticc = items.daignosticc;
					ViewBag.description = items.Descreption;
					ViewBag.isactive = items.isactive == true ? "1" : "2";    
					ViewBag.DMID = items.DMID;
					ViewBag.BtnText = "Update";


				}
			}
			List<daignostic> objLidtMedcat = new List<daignostic>();
			objLidtMedcat = objDataAccess.daignosticList(DMID, "ALL");
			return View(objLidtMedcat);
			
		}
		[httpPost]
		public IActionResult DaignosticMaster(daignostic objdaignostic)
		{
			if (objdaignostic.DMID != null)
			{
				objdaignostic.Mode = objdaignostic.DMID == 0 ? "INS" : "UPD";
			}
			else
			{
				objdaignostic.Mode = "INS";


			}
			ViewBag.BtnText = "Submit";
			objdaignostic.AddedBy = HttpContext.Session.GetString("UserName");
			objDataAccess.AddUpdateDeleteDaignosticmaster(objdaignostic);
			ViewBag.errormsg = objdaignostic.DMID == 0 ? "Medicine Category Added Successfully." : "Medicine Category Updated Successfully.";

			List<daignostic> objLidtMedcat = new List<daignostic>();
			objLidtMedcat = objDataAccess.daignosticList(0, "ALL");
			return View(objLidtMedcat);
			
		}
	}
}
