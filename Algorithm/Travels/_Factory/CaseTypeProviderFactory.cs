using System;

namespace Algorithm.Travels
{
    /// <summary>�ץ󴣨Ѫ̤u�t</summary>
    internal static class CaseTypeProviderFactory
    {
        /// <summary>�إߪA��</summary>
        /// <param name="caseType">�ץ����</param>
        /// <returns></returns>
        public static CaseTypeProviderBase CreateProvider(this CaseType caseType)
            => caseType switch
            {
                CaseType.Appeal => new AppealProvider(),
                _ => throw new NotImplementedException($"����@��{caseType}")
            };
    }
}