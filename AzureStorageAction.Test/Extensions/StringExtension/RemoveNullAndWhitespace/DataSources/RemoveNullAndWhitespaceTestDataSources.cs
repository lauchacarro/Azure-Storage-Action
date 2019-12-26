using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AzureStorageAction.Test.Extensions.StringExtension.RemoveNullAndWhitespace.DataSources
{
    class RemoveNullAndWhitespaceTestDataSources : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new string[] { "Hello", "World" };
            yield return Array.Empty<string>();
            yield return new string[] { "Hello", "World", "   ", "!!!" };
            yield return new string[] { "Hello", "World", "   ", "!!!" };
            yield return new string[] { "Hello", null, "World", "   ", "!!!" };
            yield return new string[] { string.Empty };
            yield return new string[] { null };
            yield return new string[] { "  " };
        }
    }
}
