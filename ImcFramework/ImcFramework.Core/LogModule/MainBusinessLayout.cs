using log4net.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core
{
    public class MainBusinessLayout : PatternLayout
    {
        public MainBusinessLayout()
        {
            this.AddConverter("property", typeof(MainBusinessPatternConverter));
        }
    }
}
