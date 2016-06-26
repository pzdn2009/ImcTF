using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImcFramework.Winform
{
    public interface IView
    {
        string ServiceName { get; set; }
        EServiceStatus ServiceStatus { get; set; }
        string ScheduleInfo { get; set; }
    }
}
