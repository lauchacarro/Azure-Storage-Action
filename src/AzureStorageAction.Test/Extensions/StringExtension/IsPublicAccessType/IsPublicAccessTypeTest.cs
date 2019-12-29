using Azure.Storage.Blobs.Models;

using AzureStorageAction.Extensions;

using NUnit.Framework;

namespace AzureStorageAction.Test.Extensions.StringExtension.IsPublicAccessType
{
    class IsPublicAccessTypeTest
    {
        [Test]
        public void IsPublicAccessType_With_ValidEnumName_Return_True()
        {
            string name = "BlobContainer";
            bool result = name.IsPublicAccessType(out PublicAccessType publicAccessType);
            Assert.IsTrue(result);
            Assert.AreEqual(PublicAccessType.BlobContainer, publicAccessType);
        }

        [Test]
        public void IsPublicAccessType_With_InexistentEnumName_Return_False()
        {
            string name = "FakeName";
            bool result = name.IsPublicAccessType(out PublicAccessType publicAccessType);
            Assert.IsFalse(result);
            Assert.AreEqual((PublicAccessType)(-1), publicAccessType);
        }

        [Test]
        public void IsPublicAccessType_With_Null_Return_False()
        {
            string name = null;
            bool result = name.IsPublicAccessType(out PublicAccessType publicAccessType);
            Assert.IsFalse(result);
            Assert.AreEqual((PublicAccessType)(-1), publicAccessType);
        }
    }
}
