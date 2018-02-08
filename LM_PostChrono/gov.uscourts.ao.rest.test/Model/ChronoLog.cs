using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestERS.Model
{
    public class ChronoLog
    {
        
        public string application { get; set; }
        public string status { get; set; }
        public DateTime addDate { get; set; }
        public int retryCount { get; set; }
        public DateTime retryDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public string finalDispostion { get; set; }
        public Chrono chrono { get; set; }

    }
}
