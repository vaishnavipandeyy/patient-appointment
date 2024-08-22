namespace Doctor_management.Models
{
    public class daignostic
    {
        public int? DMID { get; set; }
        public string? daignosticc { get; set; }
        public string? Descreption { get; set; } 
        public string? AddedBy { get; set; }
        
        public string? AddedOn { get; set; }
        public int? Updateby { get; set; }
        public int? Updateon { get;set; }
        public int? Status { get; set; } 
        public string? DiagnosticStatus { get; set; } 

        public string? Mode { get; set; }
        public bool? isactive { get; set; }




    }
}
