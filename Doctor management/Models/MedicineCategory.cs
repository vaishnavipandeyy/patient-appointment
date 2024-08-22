namespace Doctor_management.Models
{
    public class MedicineCategory
    {
        public int? MedicineCategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Descreption { get; set; }
        public int? Status { get; set; }
        public string? CategoryStatus { get; set; }
        public string? Mode { get; set; }
        public string? AddedBy { get; set; }  
        public string? AddedOn { get; set; }  
        public bool? isactive { get; set; }  
    }
}
