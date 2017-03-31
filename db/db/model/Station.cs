using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db.model
{
    public class Station
    {
        public string LocationAddress { get; set; }
        public string ObservatoryName { get; set; }
        public string LocationByTWD67 { get; set; }
        public DateTime CreateTime { get; set; } //顯示目前時間
    }
}
