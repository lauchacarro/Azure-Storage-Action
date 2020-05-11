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
            blobServiceProperties.EnableStaticWebSite("index.html", "404.html");

            Assert.AreEqual("index.html", blobServiceProperties.StaticWebsite.IndexDocument);
            Assert.AreEqual("404.html", blobServiceProperties.StaticWebsite.ErrorDocument404Path);
            Assert.IsTrue(blobServiceProperties.StaticWebsite.Enabled);
        }

        [Test]
        public void EnableStaticWebSite_With_False_Return_False()
        {
            blobServiceProperties.DisableStaticWebSite();

            Assert.IsFalse(blobServiceProperties.StaticWebsite.Enabled);
        }
    }
}
