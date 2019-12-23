using AzureStorageAction.Arguments;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureStorageAction.Test.Arguments.ArgumentManager.MapArguments
{
    class MapArgumentsTest
    {
        [SetUp]
        public void SetUp()
        {
            AzureStorageAction.Arguments.ArgumentManager.Clear();
        }

        [Test]
        public void MapArguments_With_ValidParameters_Return_CorrespondentEnumFields()
        {
            string[] args = new string[] { "-c", "connectionstring", "-f", "foldername" };
            AzureStorageAction.Arguments.ArgumentManager.MapArguments(args);

            Assert.AreEqual("connectionstring", AzureStorageAction.Arguments.ArgumentManager.GetValue(ArgumentEnum.ConnectionString));
            Assert.AreEqual("foldername", AzureStorageAction.Arguments.ArgumentManager.GetValue(ArgumentEnum.FolderName));

            AzureStorageAction.Arguments.ArgumentManager.Clear();
        }

        [Test]
        public void MapArguments_With_InvalidParameters_Return_CorrespondentEnumFields()
        {
            string[] args = new string[] { "-c", "connectionstring", "-f", "foldername", "-n", "-a" };
            AzureStorageAction.Arguments.ArgumentManager.MapArguments(args);

            Assert.AreEqual("connectionstring", AzureStorageAction.Arguments.ArgumentManager.GetValue(ArgumentEnum.ConnectionString));
            Assert.AreEqual("foldername", AzureStorageAction.Arguments.ArgumentManager.GetValue(ArgumentEnum.FolderName));
            Assert.AreEqual(string.Empty, AzureStorageAction.Arguments.ArgumentManager.GetValue(ArgumentEnum.ContainerName));

            AzureStorageAction.Arguments.ArgumentManager.Clear();
        }

        [Test]
        public void MapArguments_With_InvalidParametersNullValue_Return_CorrespondentEnumFields()
        {
            string[] args = new string[] { "-c", "connectionstring", "-f", null, "-n" };
            AzureStorageAction.Arguments.ArgumentManager.MapArguments(args);

            Assert.AreEqual("connectionstring", AzureStorageAction.Arguments.ArgumentManager.GetValue(ArgumentEnum.ConnectionString));
            Assert.AreEqual(string.Empty, AzureStorageAction.Arguments.ArgumentManager.GetValue(ArgumentEnum.FolderName));
            Assert.AreEqual(string.Empty, AzureStorageAction.Arguments.ArgumentManager.GetValue(ArgumentEnum.ContainerName));

            AzureStorageAction.Arguments.ArgumentManager.Clear();
        }
    }
}
