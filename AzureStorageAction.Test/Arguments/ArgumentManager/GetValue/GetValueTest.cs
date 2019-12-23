using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AzureStorageAction.Test.Arguments.ArgumentManager.GetValue
{
    class GetValueTest
    {
        [SetUp]
        public void SetUp()
        {
            AzureStorageAction.Arguments.ArgumentManager.Clear();
        }

        [Test]
        public void GetValue_With_ValidEnum_Return_SameArgument()
        {
            string[] args = new string[] { "-c", "connectionstring", "-f", "foldername" };
            AzureStorageAction.Arguments.ArgumentManager.MapArguments(args);

            var value = AzureStorageAction.Arguments.ArgumentManager.GetValue(AzureStorageAction.Arguments.ArgumentEnum.ConnectionString);

            Assert.AreEqual("connectionstring", value);

            AzureStorageAction.Arguments.ArgumentManager.Clear();
        }

        [Test]
        public void GetValue_With_InvalidEnum_Return_Emply()
        {
            string[] args = new string[] { "-c", "connectionstring", "-f", "foldername" };
            AzureStorageAction.Arguments.ArgumentManager.MapArguments(args);

            var value = AzureStorageAction.Arguments.ArgumentManager.GetValue(AzureStorageAction.Arguments.ArgumentEnum.PublicAccessPolicy);

            Assert.AreEqual(string.Empty, value);

            AzureStorageAction.Arguments.ArgumentManager.Clear();
        }


        [Test]
        public void GetValue_With_InexistentEnum_Return_Emply()
        {
            string[] args = new string[] { "-c", "connectionstring", "-f", "foldername" };
            AzureStorageAction.Arguments.ArgumentManager.MapArguments(args);

            var value = AzureStorageAction.Arguments.ArgumentManager.GetValue((AzureStorageAction.Arguments.ArgumentEnum)(-1));

            Assert.AreEqual(string.Empty, value);

            AzureStorageAction.Arguments.ArgumentManager.Clear();
        }
    }
}
