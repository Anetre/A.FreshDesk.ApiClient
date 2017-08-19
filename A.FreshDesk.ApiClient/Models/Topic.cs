using A.FreshDesk.ApiClient.Models.Enums;
using Newtonsoft.Json;
using System;

namespace A.FreshDesk.ApiClient.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Topic
    {

        /// <summary>
        /// ID of the topic
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        /// <summary>
        /// Title of the topic (MANDATORY)
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Message of the topic (MANDATORY) message given in the create request will be added as the first comment/post to the topic
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// ID of the forum to which this topic belongs
        /// </summary>
        [JsonProperty(PropertyName = "forum_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ForumId { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        [JsonProperty(PropertyName = "user_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserId { get; set; }

        /// <summary>
        /// Set to true if the topic has been marked as locked
        /// </summary>
        [JsonProperty(PropertyName = "locked", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Locked { get; set; }

        /// <summary>
        /// Set to true if the topic has been marked as published
        /// </summary>
        [JsonProperty(PropertyName = "published", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Published { get; set; }

        /// <summary>
        /// Denotes the type of topic
        /// </summary>
        [JsonProperty(PropertyName = "stamp_type", NullValueHandling = NullValueHandling.Ignore)]
        public TopicType? TopicType { get; set; }

        /// <summary>
        /// ID of the user who made the latest comment in that topic
        /// </summary>
        [JsonProperty(PropertyName = "replied_by", NullValueHandling = NullValueHandling.Ignore)]
        public long? RepliedByUserId { get; set; }

        /// <summary>
        /// Number of posts in that topic
        /// </summary>
        [JsonProperty(PropertyName = "posts_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? PostsCount { get; set; }

        /// <summary>
        /// Number of views of that topic
        /// </summary>
        [JsonProperty(PropertyName = "hits", NullValueHandling = NullValueHandling.Ignore)]
        public long? Hits { get; set; }

        /// <summary>
        /// Number of votes in the topic
        /// </summary>
        [JsonProperty(PropertyName = "user_votes", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserVotes { get; set; }

        /// <summary>
        /// ID of the topic to which it is merged into
        /// </summary>
        [JsonProperty(PropertyName = "merged_topic_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? MergedTopicId { get; set; }

        /// <summary>
        /// Set to true if the topic should stay on top of the forum for additional visibility
        /// </summary>
        [JsonProperty(PropertyName = "sticky", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Sticky { get; set; }

        /// <summary>
        /// Forum Topic creation timestamp
        /// </summary>
        [JsonProperty(PropertyName = "created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Forum Topic updated timestamp
        /// </summary>
        [JsonProperty(PropertyName = "updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Timestamp of the latest comment made in the topic
        /// </summary>
        [JsonProperty(PropertyName = "replied_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? RepliedAt { get; set; }
    }
}
