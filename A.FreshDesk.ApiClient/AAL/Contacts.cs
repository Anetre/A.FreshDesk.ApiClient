using A.FreshDesk.ApiClient.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace A.FreshDesk.ApiClient.AAL
{
    public class Contacts
    {
        public const string ApiUrl = "/api/v2/contacts";

        internal ApiClient ApiClient { get; set; }

        public List<Contact> Search(string email)
        {
            var result = ApiClient.ExecuteRequest($"{ApiUrl}?email={email}", Method.GET);
            return result.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<List<Contact>>(result.Content) : new List<Contact>();
        }

        public Contact Create(Contact contact)
        {
            contact.Active = null;
            contact.Deleted = null;
            contact.CreatedAt = null;

            var result = ApiClient.ExecuteRequest(ApiUrl, Method.POST, contact);
            return result.StatusCode == HttpStatusCode.Created ? JsonConvert.DeserializeObject<Contact>(result.Content) : null;
        }
        public Contact View(string contactId)
        {
            if (string.IsNullOrWhiteSpace(contactId))
            {
                throw new Exception("Id is missing or empty");
            }
            var result = ApiClient.ExecuteRequest($"{ApiUrl}/{contactId}", Method.GET);
            return result.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<Contact>(result.Content) : null;
        }

        public Contact Update(Contact contact)
        {
            if (contact.Id <= 0)
            {
                throw new Exception("Contact Id is missing");
            }
            var result = ApiClient.ExecuteRequest($"{ApiUrl}/{contact.Id}", Method.PUT, contact);
            return result.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<Contact>(result.Content) : null;
        }
        public bool Delete(string contactId)
        {
            if (string.IsNullOrWhiteSpace(contactId))
            {
                throw new Exception("Id is missing or empty");
            }
            var result = ApiClient.ExecuteRequest($"{ApiUrl}/{contactId}", Method.DELETE);
            return result.StatusCode == HttpStatusCode.NoContent;
        }

        public List<Contact> ListAll(int per_page = 30, int page = 1)
        {
            string pagination = $"?per_page={per_page}&page={page}";
            var result = ApiClient.ExecuteRequest($"{ApiUrl}{pagination}", Method.GET);
            return result.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<List<Contact>>(result.Content) : new List<Contact>();
        }
    }
}
