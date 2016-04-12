using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Clarify.Tests
{

    [TestClass]
    public class UnitTest1
    {

        const string API_KEY = "aAqsHXrf3SqW/hQpP75WU5A/nkIq0d/RGmDFmmtUA911w";
        ClarifyApiClient api = new ClarifyApiClient(API_KEY);

        [TestMethod]
        public async Task Test_GetBundle()
        {
            var bundle = await api.GetBundleAsync(new Guid("16b3fbddab324fafbcac805915c26a8c"));
        }

        [TestMethod]
        public async Task Test_PostBundle()
        {
            var bnd = await api.PostBundleAsync(new BundlePostRequest()
            {
                MediaUrl = new Uri("https://drive.google.com/uc?export=download&id=0Bz69ubgLdcLTT0lNSl8yMThMMms"),
                AudioLanguage = AudioLanguage.en_US,
            });
        }

    }

}
