using System;

namespace _4_VersionAttribute
{
    [Version("2.11")]
    class SampleClass
    {
        static void Main()
        {
            Type type = typeof(SampleClass);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (VersionAttribute item in allAttributes)
            {
                Console.WriteLine("{0} - {1}", item, item.Version);
            }
        }
    }
}
