using System;

namespace Algorithm.Travels
{
    /// <summary>案件提供者工廠</summary>
    internal static class CaseTypeProviderFactory
    {
        /// <summary>建立服務</summary>
        /// <param name="caseType">案件種類</param>
        /// <returns></returns>
        public static CaseTypeProviderBase CreateProvider(this CaseType caseType)
            => caseType switch
            {
                CaseType.Appeal => new AppealProvider(),
                _ => throw new NotImplementedException($"未實作的{caseType}")
            };
    }
}