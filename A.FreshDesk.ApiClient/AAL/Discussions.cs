using A.FreshDesk.ApiClient.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace A.FreshDesk.ApiClient.AAL
{
    public class Discussions
    {
        public const string ApiUrl = "/api/v2/discussions";
        public const string ApiUrlCategories = ApiUrl + "/categories";
        public const string ApiUrlForums = ApiUrl + "/forums";
        public const string ApiUrlTopics = ApiUrl + "/topics";
        public const string ApiUrlComments = ApiUrl + "/comments";



        internal ApiClient ApiClient { get; set; }

        //public List<Forum> Search(string email)
        //{
        //    var result = ApiClient.ExecuteRequest($"{ApiUrl}?email={email}", Method.GET);
        //    return result.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<List<Forum>>(result.Content) : new List<Forum>();
        //}

        //public Forum Create(Forum forum)
        //{
        //    forum.Active = null;
        //    forum.Deleted = null;
        //    forum.CreatedAt = null;

        //    var result = ApiClient.ExecuteRequest(ApiUrl, Method.POST, forum);
        //    return result.StatusCode == HttpStatusCode.Created ? JsonConvert.DeserializeObject<Forum>(result.Content) : null;
        //}
        public Forum ForumsView(long? forumId)
        {
            if (!forumId.HasValue || forumId.Value <= 0)
            {
                throw new Exception("Forum Id is missing or not valid");
            }
            var result = ApiClient.ExecuteRequest($"{ApiUrlForums}/{forumId}", Method.GET);
            return result.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<Forum>(result.Content) : null;
        }

        public List<Topic> TopicsListAll(long? forumId, int per_page = 30, int page = 1)
        {
            if (!forumId.HasValue || forumId.Value <= 0)
            {
                throw new Exception("Forum Id is missing or not valid");
            }

            string pagination = $"?per_page={per_page}&page={page}";

            var result = ApiClient.ExecuteRequest($"{ApiUrlForums}/{forumId}/topics{pagination}", Method.GET);
            return result.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<List<Topic>>(result.Content) : null;
        }

        public List<Comment> CommentsListAll(long? topicId, int per_page = 30, int page = 1)
        {
            if (!topicId.HasValue || topicId.Value <= 0)
            {
                throw new Exception("Topic Id is missing or not valid");
            }

            string pagination = $"?per_page={per_page}&page={page}";

            var result = ApiClient.ExecuteRequest($"{ApiUrlTopics}/{topicId}/comments{pagination}", Method.GET);
            return result.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<List<Comment>>(result.Content) : null;
        }

        //public Forum Update(Forum forum)
        //{
        //    if (forum.Id <= 0)
        //    {
        //        throw new Exception("Forum Id is missing");
        //    }
        //    var result = ApiClient.ExecuteRequest($"{ApiUrl}/{forum.Id}", Method.PUT, forum);
        //    return result.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<Forum>(result.Content) : null;
        //}
        //public bool Delete(string id)
        //{
        //    if (string.IsNullOrWhiteSpace(id))
        //    {
        //        throw new Exception("Id is missing or empty");
        //    }
        //    var result = ApiClient.ExecuteRequest($"{ApiUrl}/{id}", Method.DELETE);
        //    return result.StatusCode == HttpStatusCode.NoContent;
        //}

        //public List<Forum> ListAll()
        //{
        //    var result = ApiClient.ExecuteRequest(ApiUrl, Method.GET);
        //    return result.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<List<Forum>>(result.Content) : new List<Forum>();
        //}
    }
}
