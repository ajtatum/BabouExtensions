using System.Collections.Generic;
using System.Runtime.Serialization;
using BabouExtensions.Helpers;
using BabouExtensions.Test.Helpers;
using Xunit;

namespace BabouExtensions.Test
{
    public class EnumTest
    {
        [Fact]
        public void GetEnumFromDescription_From_String()
        {
            var here = "HereDescription".GetEnumValueFromDescription<FunEnums>();
            Assert.Equal(FunEnums.Here, here);
        }

        [Fact]
        public void GetEnumFromDisplayName_From_String()
        {
            var here = "HereDisplay".GetEnumFromDisplayName<FunEnums>();
            Assert.Equal(FunEnums.Here, here);
        }
        
        [Fact]
        public void ParseEnum_From_String()
        {
            var here = "Here".ParseEnum(FunEnums.Here);
            Assert.Equal(FunEnums.Here, here);
        }

        [Fact]
        public void GetAttrEnumMemberAttribute()
        {
            var here = FunEnums.Here.GetAttributeOfType<EnumMemberAttribute>().Value;
            Assert.Equal("HereEnumMember", here);
        }

        [Fact]
        public void GetDisplayName_With_Specified()
        {
            var here = FunEnums.Here.GetDisplayName();
            Assert.Equal("HereDisplay", here);
        }

        [Fact]
        public void GetDisplayName_Without_Specified()
        {
            var everywhere = FunEnums.Everywhere.GetDisplayName();
            Assert.Equal("Everywhere", everywhere);
        }

        [Fact]
        public void GetDescriptionAttr()
        {
            var everywhere = FunEnums.Everywhere.GetDescriptionAttr();
            Assert.Equal("Everywhere", everywhere);
        }

        [Fact]
        public void GetListByDescriptionAttr()
        {
            var funEnumList = BabouEnum<FunEnums>.GetListByDescriptionAttr();

            var funStringList = new List<string>() {"HereDescription", "Everywhere"};

            Assert.Equal(funStringList, funEnumList);
        }

        [Fact]
        public void GetListByDisplayAttr()
        {
            var funEnumList = BabouEnum<FunEnums>.GetListByDisplayAttr();

            var funStringList = new List<string>() { "HereDisplay", "Everywhere" };

            Assert.Equal(funStringList, funEnumList);
        }
    }
}
