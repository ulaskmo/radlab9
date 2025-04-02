using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad302SampleExam2024.DataModel
{
    public class Module
    {
        [Key]
        public string ModuleCode { get; set; }
        public string ModuleName{ get; set; }

        public ICollection<ProgrammeDelivery> moduleDeliveries { get; set; }

    }
}
