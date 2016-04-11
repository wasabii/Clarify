using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Clarify.Tests
{

    [TestClass]
    public class UnitTest1
    {

        const string API_KEY = "";
        ClarifyApiClient api = new ClarifyApiClient(API_KEY);

        [TestMethod]
        public async Task Test_GetBundleAsync()
        {
            var bundle = await api.GetBundleAsync(new Guid("16b3fbddab324fafbcac805915c26a8c"));
        }

    }

}
