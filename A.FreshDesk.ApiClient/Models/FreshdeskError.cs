using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.FreshDesk.ApiClient.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Errors : Exception
    {
        /// <summary>
        /// Description of the error
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// List of errors
        /// </summary>
        [JsonProperty(PropertyName = "errors", NullValueHandling = NullValueHandling.Ignore)]
        public List<Error> ErrorList { get; set; }
    }

    public class Error
    {
        /// <summary>
        /// Field that is having problem
        /// </summary>
        [JsonProperty(PropertyName = "field", NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; set; }

        /// <summary>
        /// Detail of the error in the field.
        /// </summary>
        [JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        /// <summary>
        /// Missing Field
        /// </summary>
        [JsonProperty(PropertyName = "code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }
    }
}
