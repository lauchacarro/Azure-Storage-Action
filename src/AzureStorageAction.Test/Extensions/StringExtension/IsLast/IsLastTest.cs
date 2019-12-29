using AzureStorageAction.Extensions;

using NUnit.Framework;

using System;

namespace AzureStorageAction.Test.Extensions.StringExtension.IsLast
{
    class IsLastTest
    {
        [Test]
        public void IsLast_With_ArrayWithValues_Return_True()
        {
            string[] values = new string[] { "1", "2", "3", "4", "5" };

            Assert.IsTrue(values.IsLast(values.Length - 1));
        }

        [Test]
        public void IsLast_With_ArrayWithoutValues_Return_InvalidOperationException()
        {
            string[] values = new string[] { };

            Assert.Catch<InvalidOperationException>(() =>
            {
                values.IsLast(0);
            });
        }

        [Test]
        public void IsLast_With_Null_Return_ArgumentNullException()
        {
            string[] values = null;

            Assert.Catch<ArgumentNullException>(() =>
            {
                values.IsLast(0);
            });
        }
    }
}
