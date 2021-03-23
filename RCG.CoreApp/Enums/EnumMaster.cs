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
        }
    }
}
