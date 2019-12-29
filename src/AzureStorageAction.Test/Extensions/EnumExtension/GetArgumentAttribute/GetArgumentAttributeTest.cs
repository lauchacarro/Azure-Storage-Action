using AzureStorageAction.Arguments;
using AzureStorageAction.Extensions;

using NUnit.Framework;

namespace AzureStorageAction.Test.Extensions.EnumExtension.GetArgumentAttribute
{
    class GetArgumentAttributeTest
    {
        [Test]
        public void GetArgumentAttribute_With_ValidArgument_Return_InstanceArgumentAttribute()
        {
            ArgumentAttribute argumentAttribute = MockEnum.Mock1.GetArgumentAttribute();
            Assert.IsNotNull(argumentAttribute);
        }

        [Test]
        public void GetArgumentAttribute_With_InvalidEnum_Return_Null()
        {
            ArgumentAttribute argumentAttribute = ((MockEnum)(-1)).GetArgumentAttribute();
            Assert.IsNull(argumentAttribute);
        }

        [Test]
        public void GetArgumentAttribute_With_EnumWIthoutAttribute_Return_Null()
        {
            ArgumentAttribute argumentAttribute = MockEnum.Mock4.GetArgumentAttribute();
            Assert.IsNull(argumentAttribute);
        }
    }
}
