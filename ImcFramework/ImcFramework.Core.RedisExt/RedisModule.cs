using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core.RedisExt
{
    public class RedisModule : ServiceModuleBase, IModuleExtension
    {
        public const string MODULE_NAME = "Redis_Module";

        public ServiceContext ServiceContext
        {
            get; set;
        }

        public override string Name
        {
            get
            {
                return MODULE_NAME;
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
