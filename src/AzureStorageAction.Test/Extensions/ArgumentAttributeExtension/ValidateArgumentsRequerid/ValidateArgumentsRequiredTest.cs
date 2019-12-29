using AzureStorageAction.Arguments;
using AzureStorageAction.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureStorageAction.Test.Extensions.ArgumentAttributeExtension.ValidateArgumentsRequerid
{
    class ValidateArgumentsRequiredTest
    {
        [Test]
        public void ValidateArgumentsRequerid_With_RequeridArgument_Return_NoHaveMissingRequeridArgument()
        {
            Dictionary<ArgumentEnum, string> keyValues = new Dictionary<ArgumentEnum, string>()
            {
                { ArgumentEnum.ConnectionString, "-c" },
                { ArgumentEnum.EnableStaticWebSite, "-s" },
                { ArgumentEnum.ContainerName, "-n" },
            };

            ArgumentEnum? argumentMissingRequerid = keyValues.ValidateArgumentsRequerid();

            Assert.IsFalse(argumentMissingRequerid.HasValue);
        }

        [Test]
        public void ValidateArgumentsRequerid_With_NoRequeridArgument_HaveMissingRequeridArgument()
        {
            Dictionary<ArgumentEnum, string> keyValues = new Dictionary<ArgumentEnum, string>()
            {
                { ArgumentEnum.FolderName, "-f" },
                { ArgumentEnum.EnableStaticWebSite, "-s" },
                { ArgumentEnum.ContainerName, "-n" },
            };

            ArgumentEnum? argumentMissingRequerid = keyValues.ValidateArgumentsRequerid();

            Assert.IsTrue(argumentMissingRequerid.HasValue);
            Assert.AreEqual(ArgumentEnum.ConnectionString, argumentMissingRequerid.Value);
        }

        [Test]
        public void ValidateArgumentsRequerid_Success_IsEmply()
        {
            Dictionary<ArgumentEnum, string> keyValues = new Dictionary<ArgumentEnum, string>();

            ArgumentEnum? argumentMissingRequerid = keyValues.ValidateArgumentsRequerid();

            Assert.IsTrue(argumentMissingRequerid.HasValue);
            Assert.AreEqual(ArgumentEnum.ConnectionString, argumentMissingRequerid.Value);
        }
    }
}
