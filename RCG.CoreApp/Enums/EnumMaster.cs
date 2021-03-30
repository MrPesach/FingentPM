using System.ComponentModel.DataAnnotations;

namespace RCG.CoreApp.Enums
{
    public static class EnumMaster
    {
        public enum Roles
        {
            SuperAdmin,
            Admin
        }

        public enum DialogResults
        {
            Unidefined,
            Yes,
            No,
            Success,
            Cancelled,
            OK,
        }

        public enum MessageBoxType
        {
            Error = 1,
            Success = 2,
            Confirmation = 3
        }
    }
}
