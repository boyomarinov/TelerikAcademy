using System;

namespace _4_VersionAttribute
{
    [AttributeUsage(AttributeTargets.Struct |
    AttributeTargets.Class | AttributeTargets.Interface,
    AllowMultiple = true)]

    class VersionAttribute : System.Attribute
    {
        private string version;

        public VersionAttribute(string version)
        {
            this.version = version;
        }

        public string Version
        {
            get { return this.version; }
        }
    }
}
