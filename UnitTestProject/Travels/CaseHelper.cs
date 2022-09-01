
using System.Collections.Generic;

namespace UnitTestProject.Travels
{
    /// <summary>�ץ�p����</summary>
    internal static class CaseHelper
    {
        public static List<CaseStatus> GetNextStatus(this CaseType caseType, CaseStatus caseStatus)
            => caseType.CreateProvider().GetNextStatus(caseStatus);
    }
}