using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad302SampleExam2024.DataModel
{
    public class Programme
    {
        [Key]
        public string ProgCode { get; set; }
        public string Description { get; set; }

        public ICollection<ProgrammeDelivery> programmeDeliveries { get; set; }
    }
}
