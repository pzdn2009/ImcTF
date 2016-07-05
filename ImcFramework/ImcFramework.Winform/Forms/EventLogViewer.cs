using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace ImcFramework.Winform.Forms
{
    public partial class EventLogViewer : Form
    {
        private string serviceName = string.Empty;
        public EventLogViewer(string serviceName = "")
        {
            InitializeComponent();

            this.serviceName = serviceName;
        }

        private void EventLogViewer_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        public void Initialize(int count = 20)
        {
            int cnt = 0;
            foreach (EventLogEntry log in eventLog1.Entries)
            {
                if(log.EntryType != EventLogEntryType.Error)
                {
                    continue;
                }
                if (cnt++ > count)
                {
                    break;
                }

                eventlogs.Items.Add(new
                {
                    log.Source,
                    log.Message
                });
            }
        }
    }
}
