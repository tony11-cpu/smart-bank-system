using System;

namespace SmartBank
{
    public class clsGlobal
    {
        public static clsUsers ActiveUser { get;  set; }
        public static event Action OnTransactionCompleted;
        public static void FireTransactionCompleted() => OnTransactionCompleted?.Invoke();
    }
}
