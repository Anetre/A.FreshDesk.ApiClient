using Newtonsoft.Json;
using System;

namespace A.FreshDesk.ApiClient.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Comment
    {
        /// <summary>
        /// ID of the comment
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        /// <summary>
        /// Content of the comment in Text
        /// </summary>
        [JsonProperty(PropertyName = "body_text")]
        public string BodyText { get; set; }

        /// <summary>
        /// Content of the comment in HTML
        /// </summary>
        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        /// <summary>
        /// ID of the topic in which the comment was posted
        /// </summary>
        [JsonProperty(PropertyName = "topic_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? TopicId { get; set; }

        /// <summary>
        /// ID of the forum in which the comment was posted
        /// </summary>
        [JsonProperty(PropertyName = "forum_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ForumId { get; set; }

        /// <summary>
        /// ID of the user who posted the comment
        /// </summary>
        [JsonProperty(PropertyName = "user_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserId { get; set; }

        /// <summary>
        /// Indicates if the comment is marked as the answer(for forum topics of type "Question")
        /// </summary>
        [JsonProperty(PropertyName = "answer", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Answer { get; set; }

        /// <summary>
        /// Indicates if the comment is being published (allowed by moderators)
        /// </summary>
        [JsonProperty(PropertyName = "published", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Published { get; set; }

        /// <summary>
        /// Indicates if the comment is marked as spam
        /// </summary>
        [JsonProperty(PropertyName = "spam", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Spam { get; set; }

        /// <summary>
        /// Indicates if the Comment is marked as deleted
        /// </summary>
        [JsonProperty(PropertyName = "trash", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Trash { get; set; }

        /// <summary>
        /// Comment creation timestamp
        /// </summary>
        [JsonProperty(PropertyName = "created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Comment updated timestamp
        /// </summary>
        [JsonProperty(PropertyName = "updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdatedAt { get; set; }
    }
}
