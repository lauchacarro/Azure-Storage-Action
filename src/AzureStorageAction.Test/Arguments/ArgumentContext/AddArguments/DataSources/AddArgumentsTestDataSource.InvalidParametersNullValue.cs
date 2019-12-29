using System.Collections;

namespace AzureStorageAction.Test.Arguments.ArgumentContext.AddArguments.DataSources
{
    public partial class AddArgumentsTestDataSource
    {
        public class InvalidParametersNullValue : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new string[] { "-c", "connectionstring", "-f", null, "-n" };
            }
        }

    }
}
