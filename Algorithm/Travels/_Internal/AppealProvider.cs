using System;
using System.Collections.Generic;

namespace Algorithm.Travels
{
    /// <summary>申訴案件提供者</summary>
    internal class AppealProvider : CaseTypeProviderBase
    {
        /// <inheritdoc/>
        public override List<CaseStatus>? GetNextStatus(CaseStatus caseStatus)
            => caseStatus switch
            {
                CaseStatus.Create => new List<CaseStatus> { CaseStatus.UserModify },
                CaseStatus.UserModify => new List<CaseStatus> { CaseStatus.UserConfirm, CaseStatus.Cancel },
                CaseStatus.UserConfirm => new List<CaseStatus> { CaseStatus.Pending, CaseStatus.CustomerServiceCheck },
                CaseStatus.Pending => new List<CaseStatus> { CaseStatus.CustomerServiceCheck },
                CaseStatus.CustomerServiceCheck => new List<CaseStatus> { CaseStatus.UserReplenish, CaseStatus.AdminModify },
                CaseStatus.AdminModify => new List<CaseStatus> { CaseStatus.CustomerServiceCheck, CaseStatus.AdminConfirm },
                CaseStatus.AdminConfirm => new List<CaseStatus> { CaseStatus.Closed, CaseStatus.AdminModify },
                _ => null
            };
    }
}