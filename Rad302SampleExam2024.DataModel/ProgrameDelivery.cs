using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad302SampleExam2024.DataModel
{
    public class ProgrammeDelivery
    {
        [Key]
        [ForeignKey("associatedProgramme")]
        public string ProgCode { get; set; }
        [Key]
        [ForeignKey("associatedModule")]
        public string ModuleCode { get; set; }

        public int Year { get; set; }

        public virtual Programme associatedProgramme { get; set; }

        public virtual Module associatedModule { get; set; }
    }
}
