using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BackendApi.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum valor)
        {
            return valor.GetType()
                        .GetField(valor.ToString())
                        ?.GetCustomAttribute<DisplayAttribute>()?
                        .Name ?? valor.ToString();
        }

    }
}
