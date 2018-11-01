using System;
using System.ComponentModel;

namespace Application.Domain.Utils
{
    public static class EnumExtensions
    {
        public static string ToDescriptionString(this Enum enumObj)
        {
            var attributes = (DescriptionAttribute[])enumObj.GetType().GetField(enumObj.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : enumObj.ToString();
        }

        public static T BuscarValorEnumPelaDescricao<T>(string description)
        {
            var type = typeof(T);

            if (!type.IsEnum)
                throw new InvalidOperationException($"\"{type}\" is not a \"System.Enum\" type.");

            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attribute != null)
                {
                    if (attribute.Description.ToLower() == description.ToLower()) return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException($"No value was found for description \"{description}\".", nameof(description));
        }
    }
}
