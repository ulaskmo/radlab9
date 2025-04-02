using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad302SampleExam2024.DataModel.CSVMapper
{
    public class ProgrammeMap : ClassMap<Programme>
    {
        public ProgrammeMap()
        {

            Map(m => m.ProgCode).Name("Pcode");
            Map(m => m.Description).Name("Description");
        
        }
    }
}
