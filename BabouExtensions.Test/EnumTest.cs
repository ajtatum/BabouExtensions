using System.Runtime.Serialization;
using BabouExtensions.Test.Helpers;
using Xunit;

namespace BabouExtensions.Test
{
    public class EnumTest
    {
        [Fact]
        public void EnumTest1()
        {
            var here = "Here".GetEnumValueFromDescription<FunEnums>();
            Assert.Equal(FunEnums.Here, here);
        }

        [Fact]
        public void EnumTest2()
        {
            var here = "Here".GetEnumFromDisplayName<FunEnums>();
            Assert.Equal(FunEnums.Here, here);
        }
        
        [Fact]
        public void EnumTest3()
        {
            var here = "Here".ParseEnum(FunEnums.Here);
            Assert.Equal(FunEnums.Here, here);
        }

        [Fact]
        public void EnumTest4()
        {
            var here = FunEnums.Here.GetAttributeOfType<EnumMemberAttribute>().Value;
            Assert.Equal("Here", here);
        }

        [Fact]
        public void EnumTest5()
        {
            var here = FunEnums.Here.GetDisplayName();
            Assert.Equal("Here", here);
        }

        [Fact]
        public void EnumTest6()
        {
            var everywhere = FunEnums.Everywhere.GetDisplayName();
            Assert.Equal("Everywhere", everywhere);
        }

        [Fact]
        public void EnumTest7()
        {
            var everywhere = FunEnums.Everywhere.GetDescriptionAttr();
            Assert.Equal("Everywhere", everywhere);
        }
    }
}
