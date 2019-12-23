using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureStorageAction.Test.Arguments.ArgumentAttribute
{
    class ArgumentAttributeTest
    {
        [Test]
        public void Constructor_With_NotNullValues_Return_SameValues()
        {
            string key = "-c";
            bool isRequired = true;
            AzureStorageAction.Arguments.ArgumentAttribute argument = new AzureStorageAction.Arguments.ArgumentAttribute(key, isRequired);

            Assert.AreEqual(key, argument.Key);
            Assert.AreEqual(isRequired, argument.IsRequired);
        }

        [Test]
        public void Constructor_With_NullValues_Return_SameValues()
        {
            string key = null;
            bool isRequired = true;
            AzureStorageAction.Arguments.ArgumentAttribute argument = new AzureStorageAction.Arguments.ArgumentAttribute(key, isRequired);

            Assert.AreEqual(key, argument.Key);
            Assert.AreEqual(isRequired, argument.IsRequired);
        }

    }
}
