using AzureStorageAction.Arguments;
using AzureStorageAction.Extensions;

using NUnit.Framework;

using System.Collections.Generic;

namespace AzureStorageAction.Test.Extensions.ArgumentAttributeExtension.ToEnums
{
    class ToEnumsTest
    {
        [Test]
        public void ToEnums_With_ValidKeys_Return_SameKeys()
        {
            string[] keys = new string[] { "-n", "-c", "-s" };

            List<ArgumentAttribute> argumentsActual = new List<ArgumentAttribute>()
            {
                new ArgumentAttribute(keys[0], false),
                new ArgumentAttribute(keys[1], true),
                new ArgumentAttribute(keys[2], false)
            };

            List<ArgumentEnum> argumentExpected = new List<ArgumentEnum>()
            {
                ArgumentEnum.ContainerName,
                ArgumentEnum.ConnectionString,
                ArgumentEnum.EnableStaticWebSite
            };

            Assert.AreEqual(argumentExpected, argumentsActual.ToEnums());
        }

        [Test]
        public void ToEnums_With_KeysInexistent_Return_Emply()
        {
            string[] keys = new string[] { "t-z", null, "t-t", string.Empty, "t-o", "t-p" };

            List<ArgumentAttribute> argumentsActual = new List<ArgumentAttribute>()
            {
                new ArgumentAttribute(keys[0], false),
                new ArgumentAttribute(keys[1], true),
                new ArgumentAttribute(keys[2], false),
                new ArgumentAttribute(keys[3], true),
                new ArgumentAttribute(keys[4], true),
                new ArgumentAttribute(keys[5], false)
            };

            Assert.IsEmpty(argumentsActual.ToEnums());
        }

        [Test]
        public void ToEnums_With_Emply_Return_Emply()
        {
            List<ArgumentAttribute> argumentsActual = new List<ArgumentAttribute>();

            Assert.IsEmpty(argumentsActual.ToEnums());
        }
    }
}
