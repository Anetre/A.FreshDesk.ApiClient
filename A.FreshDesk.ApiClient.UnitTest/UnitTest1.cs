using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace A.FreshDesk.ApiClient.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private FreshdeskClient _client;

        [TestInitialize]
        public void Init()
        {
            _client = new FreshdeskClient("iF1tBQWmH2iu23zhEO0", "https://integrationsoftware.freshdesk.com");
        }

        [TestMethod]
        public void Contacts_ListAll()
        {
            var contacts = _client.Contacts.ListAll(50, 1);
        }

        [TestMethod]
        public void Forums_View()
        {
            var forum = _client.Forums.ForumsView(1000227207);
        }


        [TestMethod]
        public void Topics_ListAll()
        {
            var topics = _client.Forums.TopicsListAll(1000227207, 50, 1);
        }


        [TestMethod]
        public void Comments_ListAll()
        {
            var topics = _client.Forums.TopicsListAll(1000227207, 1, 1);
            var topic = topics.Single();
            var comments = _client.Forums.CommentsListAll(topic.Id, 1, 1);

        }
    }
}
