using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftplanToOutlookCalendar {
    public class Record {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string RecordType { get; set; }
        public string MunkaidőType { get; set; }
    }
}
