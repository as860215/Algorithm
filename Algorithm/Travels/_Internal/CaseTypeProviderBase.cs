
using System.Collections.Generic;

namespace Algorithm.Travels
{
    /// <summary>�ץ󴣨Ѫ̰�</summary>
    internal abstract class CaseTypeProviderBase
    {
        /// <summary>���o�U�@���i�઺���d</summary>
        /// <param name="caseStatus">�ثe���d</param>
        /// <returns>�U�@���i�઺���d</returns>
        public abstract List<CaseStatus>? GetNextStatus(CaseStatus caseStatus);
    }
}