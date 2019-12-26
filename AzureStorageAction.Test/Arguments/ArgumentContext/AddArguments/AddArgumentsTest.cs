using AzureStorageAction.Arguments;
using AzureStorageAction.Test.Arguments.ArgumentContext.AddArguments.DataSources;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AzureStorageAction.Test.Arguments.ArgumentContext.AddArguments
{
    [TestFixture]
    class AddArgumentsTest
    {
        [SetUp]
        public void SetUp()
        {
            AzureStorageAction.Arguments.ArgumentContext.Instance.Clear();
        }

        [TestCaseSource(typeof(AddArgumentsTestDataSource.ValidParameters))]
        public void AddArguments_With_ValidParameters_Return_CorrespondentEnumFields(string[] args)
        {
            AzureStorageAction.Arguments.ArgumentContext.Instance.AddArguments(args);

            Assert.AreEqual("connectionstring", AzureStorageAction.Arguments.ArgumentContext.Instance.GetValue(ArgumentEnum.ConnectionString));
            Assert.AreEqual("foldername", AzureStorageAction.Arguments.ArgumentContext.Instance.GetValue(ArgumentEnum.FolderName));

            AzureStorageAction.Arguments.ArgumentContext.Instance.Clear();
        }

        [TestCaseSource(typeof(AddArgumentsTestDataSource.InvalidParameters))]
        public void AddArguments_With_InvalidParameters_Return_CorrespondentEnumFields(string[] args)
        {
            AzureStorageAction.Arguments.ArgumentContext.Instance.AddArguments(args);

            Assert.AreEqual("connectionstring", AzureStorageAction.Arguments.ArgumentContext.Instance.GetValue(ArgumentEnum.ConnectionString));
            Assert.AreEqual("foldername", AzureStorageAction.Arguments.ArgumentContext.Instance.GetValue(ArgumentEnum.FolderName));
            Assert.AreEqual(string.Empty, AzureStorageAction.Arguments.ArgumentContext.Instance.GetValue(ArgumentEnum.ContainerName));

            AzureStorageAction.Arguments.ArgumentContext.Instance.Clear();
        }

        [TestCaseSource(typeof(AddArgumentsTestDataSource.InvalidParametersNullValue))]
        public void AddArguments_With_InvalidParametersNullValue_Return_CorrespondentEnumFields(string[] args)
        {
            AzureStorageAction.Arguments.ArgumentContext.Instance.AddArguments(args);

            Assert.AreEqual("connectionstring", AzureStorageAction.Arguments.ArgumentContext.Instance.GetValue(ArgumentEnum.ConnectionString));
            Assert.AreEqual(null, AzureStorageAction.Arguments.ArgumentContext.Instance.GetValue(ArgumentEnum.FolderName));
            Assert.AreEqual(string.Empty, AzureStorageAction.Arguments.ArgumentContext.Instance.GetValue(ArgumentEnum.ContainerName));

            AzureStorageAction.Arguments.ArgumentContext.Instance.Clear();
        }
    }
}
