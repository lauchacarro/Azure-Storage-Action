using AzureStorageAction.Arguments;
using AzureStorageAction.Extensions;

using NUnit.Framework;

using System.Collections.Generic;

namespace AzureStorageAction.Test.Extensions.ArgumentAttributeExtension.GetKeys
{
    public class GetKeysTest
    {
        [Test]
        public void GetKeys_With_ValidKeys_Return_SameKeys()
        {
            string[] keys = new string[] { "-a", "-b", "-c" };
            List<ArgumentAttribute> arguments = new List<ArgumentAttribute>()
            {
                new ArgumentAttribute(keys[0], false),
                new ArgumentAttribute(keys[1], false),
                new ArgumentAttribute(keys[2], false)
            };

            Assert.AreEqual(keys, arguments.GetKeys());
        }

        [Test]
        public void GetKeys_With_NullAndEmplyKeys_Return_SameKeys()
        {
            string[] keys = new string[] { "-a", string.Empty, "-b", null, "-c" };
            List<ArgumentAttribute> arguments = new List<ArgumentAttribute>()
            {
                new ArgumentAttribute(keys[0], false),
                new ArgumentAttribute(keys[1], false),
                new ArgumentAttribute(keys[2], false),
                new ArgumentAttribute(keys[3], false),
                new ArgumentAttribute(keys[4], false)
            };

            Assert.AreEqual(keys, arguments.GetKeys());
        }

        [Test]
        public void GetKeys_With_Emply_Return_Emply()
        {
            List<ArgumentAttribute> arguments = new List<ArgumentAttribute>();

            Assert.IsEmpty(arguments.GetKeys());
        }

    }
}
