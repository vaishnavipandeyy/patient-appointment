using Doctor_management.interfaces;
using Doctor_management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Doctor_management.Controllers
{
    public class MedicineCategoryController : Controller
    {
        IDataAccess objDataAccess;
        // private readonly IDataAccess? dataac;
        public MedicineCategoryController(IDataAccess datobjDataAccessaac)
        {
            objDataAccess = datobjDataAccessaac;
        }

        [HttpGet]
        public IActionResult medicinecategorymaster(int MedicineCategoryId)
        {
            string Mode = MedicineCategoryId == 0 ? "ALL" : "GET";
            ViewBag.BtnText = "Submit";
            if (MedicineCategoryId > 0)
            {


                List<MedicineCategory> objGetEditData = new List<MedicineCategory>();
                objGetEditData = objDataAccess.MedicineCategoryList(MedicineCategoryId, "GET");
                foreach (var items in objGetEditData)
                {
                    ViewBag.isEditMode = 1;
                    ViewBag.CategoryName = items.CategoryName;
                    ViewBag.description = items.Descreption;
                    ViewBag.isactive = items.isactive == true ? "1" : "2";
                    ViewBag.MedicineCategoryId = items.MedicineCategoryId;
                    ViewBag.BtnText = "Update";


                }
            }
            List<MedicineCategory> objLidtMedcat = new List<MedicineCategory>();
            objLidtMedcat = objDataAccess.MedicineCategoryList(MedicineCategoryId, "ALL");
            return View(objLidtMedcat);
        }


        [httpPost]
        public IActionResult medicinecategorymaster(MedicineCategory objMedicineCategory)
        {
            if (objMedicineCategory.MedicineCategoryId != null)
            {
                objMedicineCategory.Mode = objMedicineCategory.MedicineCategoryId == 0 ? "INS" : "UPD";
            }
            else
            {
                objMedicineCategory.Mode = "INS";


            }
            ViewBag.BtnText = "Submit";
            objMedicineCategory.AddedBy = HttpContext.Session.GetString("UserName");
            objDataAccess.AddUpdateDeleteMedicineCategory(objMedicineCategory);
            ViewBag.errormsg = objMedicineCategory.MedicineCategoryId == 0 ? "Medicine Category Added Successfully." : "Medicine Category Updated Successfully.";

            List<MedicineCategory> objLidtMedcat = new List<MedicineCategory>();
            objLidtMedcat = objDataAccess.MedicineCategoryList(0, "ALL");
            return View(objLidtMedcat);
        }
    }
}
