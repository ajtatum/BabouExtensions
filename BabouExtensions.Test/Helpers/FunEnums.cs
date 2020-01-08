using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BabouExtensions.Test.Helpers
{
    public enum FunEnums
    {
        [EnumMember(Value = "HereEnumMember")]
        [Description("HereDescription")]
        [Display(Name = "HereDisplay")]
        Here,
        Everywhere
    }
}
