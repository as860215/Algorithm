using System.ComponentModel;

namespace Algorithm
{
    /// <summary>狀態</summary>
    public enum CaseStatus
    {
        /// <summary>建立</summary>
        [Description("建立")]
        Create = 0001,
        /// <summary>待分派</summary>
        Pending = 0020,
        /// <summary>使用者編輯</summary>
        UserModify = 1001,
        /// <summary>使用者審核</summary>
        UserConfirm = 1002,
        /// <summary>使用者補件</summary>
        UserReplenish = 1010,
        /// <summary>客服確認中</summary>
        CustomerServiceCheck = 2001,
        /// <summary>管理員編輯</summary>
        AdminModify = 5001,
        /// <summary>管理員審核</summary>
        AdminConfirm = 5002,
        /// <summary>結案</summary>
        Closed = 9040,
        /// <summary>銷案</summary>
        Cancel = 9060,
    }
}