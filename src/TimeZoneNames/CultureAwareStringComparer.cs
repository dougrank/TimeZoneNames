﻿using System.Collections.Generic;
using System.Globalization;

namespace TimeZoneNames
{
    // This class is only necessary because StringComparer.Create isn't available in the version of .NET Standard we want to target.

    internal class CultureAwareStringComparer : IComparer<string>
    {
        private readonly CompareOptions _options;
        private readonly CompareInfo _compareInfo;

        public CultureAwareStringComparer(CultureInfo culture, CompareOptions options)
        {
            _options = options;
            _compareInfo = culture.CompareInfo;
        }

        public int Compare(string x, string y)
        {
            return _compareInfo.Compare(x, y, _options);
        }
    }
}