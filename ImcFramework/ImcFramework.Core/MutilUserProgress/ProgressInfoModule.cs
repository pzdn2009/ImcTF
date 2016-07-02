using ImcFramework.LogPool;

namespace ImcFramework.Core.MutilUserProgress
{
    public class ProgressInfoModule : ServiceModuleBase
    {
        public const string MODUEL_NAME = "ProgressInfo_Module";

        public ProgressInfoModule()
        {
        }

        public override string Name
        {
            get
            {
                return MODUEL_NAME;
            }
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Stop()
        {
            base.Stop();
        }
    }
}
