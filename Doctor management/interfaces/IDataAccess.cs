using Doctor_management.Models;
using System.Data;

namespace Doctor_management.interfaces
{
	public interface IDataAccess
	{
		public void usersignup(signup adm);

		public DataTable UserLogin(string Emailid, string Password);

		void AddUpdateDeleteMedicineCategory(MedicineCategory objMedicineCategory);

		List<MedicineCategory> MedicineCategoryList(int MedicineCategoryId, string Mode);

		List<dropdown> GetDataFromDatabase();

		public void AddUpdateDeleteMedicineMaster(medicinemaster objMedicinemaster);
		public List<medicinemaster> MedicineMasterList(int MedicineId, string Mode);
		public List<MedicineEdit> MedicineEditList(int MedicineCategoryId, string Mode);
		public void AddUpdateDeleteDaignosticmaster(daignostic objdaignostic);
		public List<daignostic> daignosticList(int DMID, string Mode);

		List<dropdown> BindPatientNames();

		List<dropdown> BindMedicinePres();
		public List<dropdown> BindDiagnosticPres();

		void AddUpdateDeletePatientAppointment(Patient objPatient);


	}
}
