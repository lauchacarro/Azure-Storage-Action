using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureStorageAction.Extensions
{
    public static class BlobServicePropertiesExtension
    {
        public const string INDEXDOCUMENT = "index.html";
        public const string ERRORDOCUMENT404PATH = "404.html";
        public static void EnableStaticWebSite (this BlobServiceProperties properies, bool enable)
        {
            properies.StaticWebsite.Enabled = enable;
            if (enable)
            {
                properies.StaticWebsite.ErrorDocument404Path = ERRORDOCUMENT404PATH;
                properies.StaticWebsite.IndexDocument = INDEXDOCUMENT;
            }
        }
    }
}
