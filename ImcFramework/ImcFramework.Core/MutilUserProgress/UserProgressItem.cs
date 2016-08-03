using ImcFramework.WcfInterface.ProgressInfos;
using System.Collections.Generic;

namespace ImcFramework.Core.MutilUserProgress
{
    /// <summary>
    /// The dictionary for the user as key,the <see cref="ProgressItem"/> as value.
    /// </summary>
    public class UserProgressItem : Dictionary<string, ProgressItem>
    {
        public bool ProgressSummarySpecific { get; private set; }

        private ProgressSummary progressSummary;
        public ProgressSummary ProgressSummary
        {
            get { return progressSummary; }
            set
            {
                progressSummary = value;
                ProgressSummarySpecific = true;

                Clear();
            }
        }

        public void SetItemValueFinish(string user)
        {
            if (ContainsKey(user))
            {
                this[user].Value = this[user].Total;
            }
        }

        public void SetProgressItem(string user, int total, int value, bool accumulate = true)
        {
            if (ContainsKey(user))
            {
                this[user].Total = total;
            }
            else
            {
                this[user] = new ProgressItem(0, total, user);
            }
        }
    }
}
