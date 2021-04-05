using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        public enum ApplConfig
        {
            [Display(Name = "Indesign Index File Save Path")]
            IndesignIndexFileSavePath = 1,
        }

        public static string GetDisplayValue(object value)
        {
            var fieldInfo = value?.GetType().GetField(value.ToString());

            var descriptionAttributes = fieldInfo?.GetCustomAttributes(
                typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (!descriptionAttributes.Any())
            {
                return string.Empty;
            }

            return (descriptionAttributes?.Length > 0) ? descriptionAttributes[0].Name : value?.ToString();
        }
    }
}
