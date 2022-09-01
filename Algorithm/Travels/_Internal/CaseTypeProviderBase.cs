
using System.Collections.Generic;

namespace Algorithm.Travels
{
    /// <summary>案件提供者基底</summary>
    internal abstract class CaseTypeProviderBase
    {
        /// <summary>取得下一關可能的關卡</summary>
        /// <param name="caseStatus">目前關卡</param>
        /// <returns>下一關可能的關卡</returns>
        public abstract List<CaseStatus>? GetNextStatus(CaseStatus caseStatus);
    }
}