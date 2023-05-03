using System.ComponentModel;
namespace MySemanticKernelFirstProject.Extensions;

public static class GetEnumExtension
{
    public static string GetDescription(this Enum value)
    {
        var type = value.GetType();
        var memberInfo = type.GetMember(value.ToString());
        var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
        var description = ((DescriptionAttribute)attributes[0]).Description;
        return description;
    }
}