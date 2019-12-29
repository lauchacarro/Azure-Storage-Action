using AzureStorageAction.Arguments;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AzureStorageAction.Test.Arguments.ArgumentContext.GetValue
{
    class GetValueTest
    {
        [SetUp]
        public void SetUp()
        {
            AzureStorageAction.Arguments.ArgumentContext.Instance.Clear();
            string[] args = new string[] { "-c", "connectionstring", "-f", "foldername" };
            AzureStorageAction.Arguments.ArgumentContext.Instance.AddArguments(args);
        }

        [Test]
        public void GetValue_With_ValidEnum_Return_SameArgument()
        {
            var value = AzureStorageAction.Arguments.ArgumentContext.Instance.GetValue(ArgumentEnum.ConnectionString);

            Assert.AreEqual("connectionstring", value);
        }

        [Test]
        public void GetValue_With_InvalidEnum_Return_Emply()
        {
            var value = AzureStorageAction.Arguments.ArgumentContext.Instance.GetValue(ArgumentEnum.PublicAccessPolicy);

            Assert.AreEqual(string.Empty, value);
        }


        [Test]
        public void GetValue_With_InexistentEnum_Return_Emply()
        {
            var value = AzureStorageAction.Arguments.ArgumentContext.Instance.GetValue((ArgumentEnum)(-1));

            Assert.AreEqual(string.Empty, value);
        }
    }
}
