using System;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Clarify.Profiles;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Clarify.Tests
{

    [TestClass]
    public class UnitTest1
    {

        const string API_KEY = "";
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

        [TestMethod]
        public async Task Test_GetTranscriptR4()
        {
            var t = await api.GetBundleInsightAsync<TranscriptR4Insight>(new Guid("1577e8f9d42c4d12a762f53cd9f4188c"), new Guid("22c929380bb242329de1076426ec0e4b"));
            var s = new DataContractSerializer(typeof(TranscriptR4Transcript));
            var m = new StringBuilder();
            var w = XmlWriter.Create(m);
            s.WriteObject(w, t.TrackData[0].Transcript);
            w.Flush();
        }

        [TestMethod]
        public async Task Test_GetTracks()
        {
            var tracks = await  api.GetBundleTracksAsync(new Guid("0776e112-2fbc-4355-8085-2a6e66484920"));
        }

    }

}
