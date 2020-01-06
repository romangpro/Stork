using System.Globalization;
using System.Resources;

namespace Domain
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this object e, CultureInfo ci)
        {
            var rm = new ResourceManager(e.GetType());
            var resourceDisplayName = rm.GetString(e.GetType().Name + "_" + e);

            return string.IsNullOrWhiteSpace(resourceDisplayName) ? string.Format("[[{0}]]", e) : resourceDisplayName;
        }
    }
}
