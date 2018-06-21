namespace SimpleMvc.Framework
{
    using System;

    public class MvcContext
    {
        private static MvcContext Instance;

        private static readonly object instanceLock = new object();

        private MvcContext() { }

        public static MvcContext Get
        {
            get
            {
                if(Instance == null)
                {
                    lock (instanceLock)
                    {
                        if(Instance == null)
                        {
                            Instance = new MvcContext();
                        }
                    }
                }
                return Instance;
            }
        }

        public string AssemblyName { get; set; }

        public string ControllersFolder { get; set; }

        public string ControllersSuffix { get; set; }

        public string ViewsFolder { get; set; }

        public string ModelsFolder { get; set; }

        public string ResourcesFolder { get; set; }
    }
}
