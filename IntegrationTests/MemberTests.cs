using APIModels;
using Data.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests
{
    [TestClass]
    public class MemberTests
    {
        private static WebApplicationFactory<Program> _factory;

        /// <summary>
        /// Get the required HttpContent for HttpClient.PostAsync()
        /// </summary>
        /// <param name="json"></param>
        /// <returns>ByteArrayContent</returns>
        private ByteArrayContent GetPostContent(string json)
        {
            var buffer = Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _factory = new WebApplicationFactory<Program>();
        }

        [TestMethod]
        public async Task ShouldCreateMemberSuccess()
        {
            var client = _factory.CreateClient();
            var req = new CreateMemberRequest("Test Member");
            var jsonContent = JsonConvert.SerializeObject(req);
            var response = await client.PostAsync("api/samples", GetPostContent(jsonContent));

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());

            var json = await response.Content.ReadAsStringAsync();
            var newMember = JsonConvert.DeserializeObject<Member>(json);

            Assert.AreEqual(req.Name, newMember.Name);
            Assert.IsNotNull(newMember.ID);
        }
    }
}