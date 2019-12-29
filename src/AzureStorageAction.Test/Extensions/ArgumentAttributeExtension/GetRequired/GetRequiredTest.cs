using AzureStorageAction.Arguments;
using AzureStorageAction.Extensions;

using NUnit.Framework;

using System.Collections.Generic;

namespace AzureStorageAction.Test.Extensions.ArgumentAttributeExtension.GetRequired
{
    class GetRequiredTest
    {
        [Test]
        public void GetRequired_With_RequiredAndNoRequiredArguments_Return_OnlyRequired()
        {
            string[] keys = new string[] { "-a", "-b", "-c", "-d", "-e", "-f" };

            List<ArgumentAttribute> argumentsActual = new List<ArgumentAttribute>()
            {
                new ArgumentAttribute(keys[0], false),
                new ArgumentAttribute(keys[1], true),
                new ArgumentAttribute(keys[2], false),
                new ArgumentAttribute(keys[3], true),
                new ArgumentAttribute(keys[4], true),
                new ArgumentAttribute(keys[5], false)
            };

            List<ArgumentAttribute> argumentExpected = new List<ArgumentAttribute>()
            {
                new ArgumentAttribute(keys[1], true),
                new ArgumentAttribute(keys[3], true),
                new ArgumentAttribute(keys[4], true)
            };

            Assert.AreEqual(argumentExpected, argumentsActual.GetRequired());
        }

        [Test]
        public void GetRequired_With_RequiredAndNoRequiredArgumentsAndNullAndEmplyKeys_Return_OnlyRequired()
        {
            string[] keys = new string[] { "-a", null, "-c", string.Empty, "-e", "-f" };

            List<ArgumentAttribute> argumentsActual = new List<ArgumentAttribute>()
            {
                new ArgumentAttribute(keys[0], false),
                new ArgumentAttribute(keys[1], true),
                new ArgumentAttribute(keys[2], false),
                new ArgumentAttribute(keys[3], true),
                new ArgumentAttribute(keys[4], true),
                new ArgumentAttribute(keys[5], false)
            };

            List<ArgumentAttribute> argumentExpected = new List<ArgumentAttribute>()
            {
                new ArgumentAttribute(keys[1], true),
                new ArgumentAttribute(keys[3], true),
                new ArgumentAttribute(keys[4], true)
            };

            Assert.AreEqual(argumentExpected, argumentsActual.GetRequired());
        }

        [Test]
        public void GetRequired_With_NoRequiredArguments_Return_Emply()
        {
            string[] keys = new string[] { "-a", "-b", "-c", "-d", "-e", "-f" };

            List<ArgumentAttribute> arguments = new List<ArgumentAttribute>()
            {
                new ArgumentAttribute(keys[0], false),
                new ArgumentAttribute(keys[1], false),
                new ArgumentAttribute(keys[2], false),
                new ArgumentAttribute(keys[3], false),
                new ArgumentAttribute(keys[4], false),
                new ArgumentAttribute(keys[5], false)
            };

            Assert.IsEmpty(arguments.GetRequired());
        }

        [Test]
        public void GetRequired_With_Emply_Return_Emply()
        {
            List<ArgumentAttribute> arguments = new List<ArgumentAttribute>();

            Assert.IsEmpty(arguments.GetRequired());
        }

    }
}
