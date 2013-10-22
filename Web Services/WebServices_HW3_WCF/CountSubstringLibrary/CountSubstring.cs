using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;

namespace CountSubstringLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CountSubstring" in both code and config file together.
    public class CountSubstring : ICountSubstring
    {
        public int CountOccurrences(string needle, string haystack)
        {
            return Regex.Matches(haystack, needle).Count;
        }

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}
    }
}
