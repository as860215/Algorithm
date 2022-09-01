
using System.Collections.Generic;

namespace Algorithm.Travels
{
    /// <summary>案件小幫手</summary>
    internal static class CaseHelper
    {
        public static List<CaseStatus> GetNextStatus(this CaseType caseType, CaseStatus caseStatus)
            => caseType.CreateProvider().GetNextStatus(caseStatus);
    }
}