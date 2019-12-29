using AzureStorageAction.Arguments;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureStorageAction.Test.Extensions.EnumExtension.GetArgumentAttribute
{
    public enum MockEnum
    {
        [Argument("m1", true)]
        Mock1,

        [Argument("m2", false)]
        Mock2,

        [Argument("m3", false)]
        Mock3,

        
        Mock4,
    }
}
