using ImcFramework.Data;
using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core.Quartz.Commands
{
    public class GetServiceInfoOutput : ExecuteResult
    {
        public EServiceStatus EServiceStatus { get; set; }

        public string ScheduleInfo { get; set; }

        public bool Enable { get; set; }
    }
}
