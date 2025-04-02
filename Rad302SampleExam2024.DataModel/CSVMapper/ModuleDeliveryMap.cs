using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad302SampleExam2024.DataModel.CSVMapper
{
    public class ModuleDeliveryMap : ClassMap<ProgrammeDelivery>
    {
        public ModuleDeliveryMap()
        {
            Map(m => m.ModuleCode).Name("Mcode");
            Map(m => m.ProgCode).Name("Pcode");
            Map(m => m.Year).Name("Year");
        }
    }
}
