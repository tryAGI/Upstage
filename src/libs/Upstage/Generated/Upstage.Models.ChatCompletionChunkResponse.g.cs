
#nullable enable

namespace Upstage
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ChatCompletionChunkResponse
    {
        /// <summary>
        /// A unique identifier for the chat completion chunk.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// The object type, always "chat.completion.chunk".
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("object")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Upstage.JsonConverters.ChatCompletionChunkResponseObjectJsonConverter))]
        public global::Upstage.ChatCompletionChunkResponseObject? Object { get; set; }

        /// <summary>
        /// The Unix timestamp of when the chunk was created.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("created")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Upstage.JsonConverters.UnixTimestampJsonConverter))]
        public global::System.DateTimeOffset? Created { get; set; }

        /// <summary>
        /// The model used for the chat completion.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("model")]
        public string? Model { get; set; }

        /// <summary>
        /// A list of chat completion chunk choices.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("choices")]
        public global::System.Collections.Generic.IList<global::Upstage.ChatCompletionChunkChoice>? Choices { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("usage")]
        public global::Upstage.Usage? Usage { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatCompletionChunkResponse" /> class.
        /// </summary>
        /// <param name="id">
        /// A unique identifier for the chat completion chunk.
        /// </param>
        /// <param name="object">
        /// The object type, always "chat.completion.chunk".
        /// </param>
        /// <param name="created">
        /// The Unix timestamp of when the chunk was created.
        /// </param>
        /// <param name="model">
        /// The model used for the chat completion.
        /// </param>
        /// <param name="choices">
        /// A list of chat completion chunk choices.
        /// </param>
        /// <param name="usage"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ChatCompletionChunkResponse(
            string? id,
            global::Upstage.ChatCompletionChunkResponseObject? @object,
            global::System.DateTimeOffset? created,
            string? model,
            global::System.Collections.Generic.IList<global::Upstage.ChatCompletionChunkChoice>? choices,
            global::Upstage.Usage? usage)
        {
            this.Id = id;
            this.Object = @object;
            this.Created = created;
            this.Model = model;
            this.Choices = choices;
            this.Usage = usage;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatCompletionChunkResponse" /> class.
        /// </summary>
        public ChatCompletionChunkResponse()
        {
        }
    }
}