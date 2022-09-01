using System.ComponentModel;

namespace Algorithm
{
    /// <summary>���A</summary>
    public enum CaseStatus
    {
        /// <summary>�إ�</summary>
        [Description("�إ�")]
        Create = 0001,
        /// <summary>�ݤ���</summary>
        Pending = 0020,
        /// <summary>�ϥΪ̽s��</summary>
        UserModify = 1001,
        /// <summary>�ϥΪ̼f��</summary>
        UserConfirm = 1002,
        /// <summary>�ϥΪ̸ɥ�</summary>
        UserReplenish = 1010,
        /// <summary>�ȪA�T�{��</summary>
        CustomerServiceCheck = 2001,
        /// <summary>�޲z���s��</summary>
        AdminModify = 5001,
        /// <summary>�޲z���f��</summary>
        AdminConfirm = 5002,
        /// <summary>����</summary>
        Closed = 9040,
        /// <summary>�P��</summary>
        Cancel = 9060,
    }
}