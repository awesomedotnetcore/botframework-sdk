// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Bot.Builder.Luis.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Luis entity recommendation. Look at https://www.luis.ai/Help for more
    /// information.
    /// </summary>
    public partial class EntityRecommendation
    {
        /// <summary>
        /// Initializes a new instance of the EntityRecommendation class.
        /// </summary>
        public EntityRecommendation() { }

        /// <summary>
        /// Initializes a new instance of the EntityRecommendation class.
        /// </summary>
        public EntityRecommendation(string type, string role = default(string), string entity = default(string), int? startIndex = default(int?), int? endIndex = default(int?), double? score = default(double?), IDictionary<string, object> resolution = default(IDictionary<string, object>))
        {
            Role = role;
            Entity = entity;
            Type = type;
            StartIndex = startIndex;
            EndIndex = endIndex;
            Score = score;
            Resolution = resolution;
        }

        /// <summary>
        /// Role of the entity.
        /// </summary>
        [JsonProperty(PropertyName = "role")]
        public string Role { get; set; }

        /// <summary>
        /// Entity extracted by LUIS.
        /// </summary>
        [JsonProperty(PropertyName = "entity")]
        public string Entity { get; set; }

        /// <summary>
        /// Type of the entity.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Start index of the entity in the LUIS query string.
        /// </summary>
        [JsonProperty(PropertyName = "startIndex")]
        public int? StartIndex { get; set; }

        /// <summary>
        /// End index of the entity in the LUIS query string.
        /// </summary>
        [JsonProperty(PropertyName = "endIndex")]
        public int? EndIndex { get; set; }

        /// <summary>
        /// Score assigned by LUIS to detected entity.
        /// </summary>
        [JsonProperty(PropertyName = "score")]
        public double? Score { get; set; }

        /// <summary>
        /// A machine interpretable resolution of the entity.  For example the
        /// string "one thousand" would have the resolution "1000".  The
        /// exact form of the resolution is defined by the entity type and is
        /// documented here: https://www.luis.ai/Help#PreBuiltEntities.
        /// </summary>
        [JsonProperty(PropertyName = "resolution", ItemConverterType = typeof(ResolutionConverter))]
        public IDictionary<string, object> Resolution { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (Type == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Type");
            }
        }

        internal class ResolutionConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return (objectType == typeof(IDictionary<string, object>));
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                JToken token = JToken.Load(reader);

                if (token.Type == JTokenType.Array)
                {
                    var children = token.Children();

                    if (children.Count() == 1)
                    {
                        return children.First().ToObject<IDictionary<string, object>>();
                    }

                    return null;
                }
                else
                {
                    return token.ToObject<object>();
                }
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
        }
    }
}
