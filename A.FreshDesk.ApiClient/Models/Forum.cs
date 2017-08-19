using A.FreshDesk.ApiClient.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.FreshDesk.ApiClient.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Forum
    {

        /// <summary>
        /// If the forum_visibility property is set to 4, the forum is only visible to users belonging to certain companies. This property is an array of those company IDs.
        /// </summary>
        [JsonProperty(PropertyName = "company_ids", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> CompanyIds { get; set; }

        /// <summary>
        /// A short description of the forum
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// ID of the category to which this forum belongs
        /// </summary>
        [JsonProperty(PropertyName = "forum_category_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ForumCategoryId { get; set; }

        /// <summary>
        /// Denotes the type of forum (Supported types can be seen in the Forum properties table below)
        /// </summary>
        [JsonProperty(PropertyName = "forum_type", NullValueHandling = NullValueHandling.Ignore)]
        public ForumType ForumType { get; set; }

        /// <summary>
        /// Denotes the visibility level of the forum (See the Forum Visibility table below for supported levels)
        /// </summary>
        [JsonProperty(PropertyName = "forum_visibility", NullValueHandling = NullValueHandling.Ignore)]
        public ForumVisibility ForumVisibility { get; set; }

        /// <summary>
        /// ID of the forum
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        /// <summary>
        /// Name of the forum (MANDATORY)
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Controls the order in which the forums are displayed in the web page
        /// </summary>
        [JsonProperty(PropertyName = "position", NullValueHandling = NullValueHandling.Ignore)]
        public long? Position { get; set; }

        /// <summary>
        /// The total number of posts in the forum
        /// </summary>
        [JsonProperty(PropertyName = "posts_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? PostsCount { get; set; }

        /// <summary>
        /// The total number of topics in the forum
        /// </summary>
        [JsonProperty(PropertyName = "topics_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? TopicsCount { get; set; }

        /// <summary>
        /// The total number of comments in the forum
        /// </summary>
        [JsonProperty(PropertyName = "comments_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? CommentsCount { get; set; }

    }
}
