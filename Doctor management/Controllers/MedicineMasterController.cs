using Doctor_management.interfaces;
using Doctor_management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
namespace Doctor_management.Controllers
{
    public class MedicineMasterController : Controller
    {
        IDataAccess objDataAccess;
       // private readonly IDataAccess? dataac;
        public MedicineMasterController(IDataAccess datobjDataAccessaac) {
            objDataAccess= datobjDataAccessaac;
        }
        
        [HttpGet]
        public IActionResult Medicine_master(medicinemaster objmedicinemaster,int MedicineId)
        {
            
            objDataAccess.AddUpdateDeleteMedicineMaster(objmedicinemaster);

            string Mode = MedicineId == 0 ? "ALL" : "GET";
            List<medicinemaster> objListMedmas = new List<medicinemaster>();
            objListMedmas = objDataAccess.MedicineMasterList(MedicineId, Mode);
            ViewBag.data = objListMedmas;
            return View();
  
        }
        [HttpPost]
        public IActionResult Medicine_master(medicinemaster objmedicinemaster)
        {
            objmedicinemaster.Mode = objmedicinemaster.MedicineId == null ? "INS" : "UPD";
            objmedicinemaster.AddedBy = HttpContext.Session.GetString("UserName");
            objDataAccess.AddUpdateDeleteMedicineMaster(objmedicinemaster);
            ViewBag.errormsg = objmedicinemaster.MedicineId == 0 ? "Medicine Category Added Successfully." : "Medicine Category Updated Successfully.";
            return View();
            
        }


        [HttpGet]
        public JsonResult BindMedicinecategory()
        {
            List<dropdown> dropdowns = objDataAccess.GetDataFromDatabase();
            return Json(dropdowns);
        }


    }
}
