using AzureStorageAction.Arguments;
using AzureStorageAction.Extensions;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;

namespace AzureStorageAction.Test.Extensions.EnumExtension.GetArgumentAttributes
{
    class GetArgumentAttributesTest
    {
        [Test]
        public void GetArgumentAttributes_With_3Fields_Return_Array3ArgumentAttribute()
        {
            List<ArgumentEnum> fields = new List<ArgumentEnum>() { ArgumentEnum.ConnectionString, ArgumentEnum.ContainerName, ArgumentEnum.EnableStaticWebSite };
            IEnumerable<ArgumentAttribute> arguments = fields.GetArgumentAttributes();

            Assert.AreEqual(3, arguments.Count());
        }

        [Test]
        public void GetArgumentAttributes_With_Emply_Return_Emply()
        {
            List<ArgumentEnum> fields = new List<ArgumentEnum>();
            IEnumerable<ArgumentAttribute> arguments = fields.GetArgumentAttributes();

            Assert.IsEmpty(arguments);
        }

        [Test]
        public void GetArgumentAttributes_With_Null_Return_ArgumentNullException()
        {
            List<ArgumentEnum> fields = null;

            Assert.Catch<ArgumentNullException>(() =>
            {
                fields.GetArgumentAttributes();
            });
        }
    }
}
