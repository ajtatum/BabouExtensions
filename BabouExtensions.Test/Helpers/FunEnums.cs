using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BabouExtensions.Test.Helpers
{
    public enum FunEnums
    {
        [EnumMember(Value = "Here")]
        [Description("Here")]
        [Display(Name = "Here")]
        Here,
        Everywhere
    }
}
