using AzureStorageAction.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureStorageAction.Test.Extensions.NullExtension.IsNull
{
    class IsNullTest
    {
        [Test]
        public void IsNull_With_NullValue_Return_True()
        {
            string value = null;

            Assert.IsTrue(value.IsNull());
        }

        [Test]
        public void IsNull_With_NullValue_Return_False()
        {
            string value = string.Empty;

            Assert.IsFalse(value.IsNull());
        }
    }
}
