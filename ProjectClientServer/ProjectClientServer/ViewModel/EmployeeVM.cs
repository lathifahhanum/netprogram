using System.ComponentModel.DataAnnotations;

namespace ProjectClientServer.ViewModel
{
    public class EmployeeVM
    {
        public int id { get; set; }

        [Display(Name = "NIK")]
        public string Nik { get; set; }

        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Display(Name = "Job Tenure")]
        public int WorkingPeriod { get; set; }

        public string Degree { get; set; }
    }

}
