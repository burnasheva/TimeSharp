namespace Timesharp.AcceptanceTests
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using Microsoft.Owin.Testing;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using Timesharp;
    using Timesharp.Models;
    using Timesharp.Providers;

    public class IntegrationTest
    {
        private TestServer server;

        [TestFixtureSetUp]
        public void FixtureInit()
        {
            server = TestServer.Create<Startup>();
        }

        [TestFixtureTearDown]
        public void FixtureDipose()
        {
            server.Dispose();
        }

        [Test]
        public void GetValues()
        {
            var response = server.HttpClient.GetAsync("/api/Values").Result;
            var result = response.Content.ReadAsAsync<JArray>().Result;

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.AreEqual(new JArray() {"value1", "value2"}, result);
        }

        [Test]
        public void GetToken()
        {
            HttpContent content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("password", "1337pa$$word"),
                    new KeyValuePair<string, string>("username", "admin"),
                });
            var response = server.HttpClient.PostAsync("/Token", content).Result;
            var result = response.Content.ReadAsAsync<JObject>().Result;

            Assert.AreEqual(new JArray() { "value1", "value2" }, response);
        }
    }
}