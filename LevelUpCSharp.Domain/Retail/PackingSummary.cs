using System;
using System.Collections.Generic;

namespace LevelUpCSharp.Retail
{
    public class PackingSummary
    {
        public PackingSummary(IEnumerable<LineSummary> positions, string vendor)
        {
            Positions = positions;
            Vendor = vendor;
            TimeStamp = DateTimeOffset.Now;
        }

        public static PackingSummary CreateEmpty(string deliver)
        {
            return new PackingSummary(Array.Empty<LineSummary>(), deliver);
        }

        public DateTimeOffset TimeStamp { get; }

        public IEnumerable<LineSummary> Positions { get; }
        public object Vendor { get; set; }
    }
}