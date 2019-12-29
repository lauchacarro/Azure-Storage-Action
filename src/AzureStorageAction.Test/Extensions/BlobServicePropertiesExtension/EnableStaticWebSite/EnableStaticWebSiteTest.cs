using Azure.Storage.Blobs.Models;

using AzureStorageAction.Extensions;

using NUnit.Framework;

namespace AzureStorageAction.Test.Extensions.BlobServicePropertiesExtension.EnableStaticWebSite
{
    class EnableStaticWebSiteTest
    {
        BlobServiceProperties blobServiceProperties;

        [SetUp]
        public void Setup()
        {
            blobServiceProperties = new BlobServiceProperties
            {
                StaticWebsite = new BlobStaticWebsite()
            };
        }

        [Test]
        public void EnableStaticWebSite_With_True_Return_True()
        {
            blobServiceProperties.EnableStaticWebSite(true);

            Assert.AreEqual(AzureStorageAction.Extensions.BlobServicePropertiesExtension.INDEXDOCUMENT, blobServiceProperties.StaticWebsite.IndexDocument);
            Assert.AreEqual(AzureStorageAction.Extensions.BlobServicePropertiesExtension.ERRORDOCUMENT404PATH, blobServiceProperties.StaticWebsite.ErrorDocument404Path);
            Assert.IsTrue(blobServiceProperties.StaticWebsite.Enabled);
        }

        [Test]
        public void EnableStaticWebSite_With_False_Return_False()
        {
            blobServiceProperties.EnableStaticWebSite(false);

            Assert.IsFalse(blobServiceProperties.StaticWebsite.Enabled);
        }
    }
}
