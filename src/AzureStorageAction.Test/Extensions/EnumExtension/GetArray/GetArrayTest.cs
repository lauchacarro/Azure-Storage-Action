using AzureStorageAction.Extensions;

using NUnit.Framework;

namespace AzureStorageAction.Test.Extensions.EnumExtension.GetArray
{
    class GetArrayTest
    {
        [Test]
        public void GetArray_With_EnumWithTwoItems_Return_ArrayWith2Values()
        {
            MockEnumTwoItems[] array = typeof(MockEnumTwoItems).GetArray<MockEnumTwoItems>();

            Assert.AreEqual(2, array.Length);
        }

        [Test]
        public void GetArray_With_EnumWithoutItems_Return_ArrayEmply()
        {
            MockEnumEmply[] array = typeof(MockEnumEmply).GetArray<MockEnumEmply>();

            Assert.IsEmpty(array);
        }


    }
}
