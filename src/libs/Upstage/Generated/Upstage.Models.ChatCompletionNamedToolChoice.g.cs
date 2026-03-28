
#nullable enable

namespace Upstage
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ChatCompletionNamedToolChoice
    {
        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("type")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Upstage.JsonConverters.ChatCompletionNamedToolChoiceTypeJsonConverter))]
        public global::Upstage.ChatCompletionNamedToolChoiceType Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("function")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Upstage.ChatCompletionNamedToolChoiceFunction Function { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatCompletionNamedToolChoice" /> class.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="function"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ChatCompletionNamedToolChoice(
            global::Upstage.ChatCompletionNamedToolChoiceFunction function,
            global::Upstage.ChatCompletionNamedToolChoiceType type)
        {
            this.Function = function ?? throw new global::System.ArgumentNullException(nameof(function));
            this.Type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatCompletionNamedToolChoice" /> class.
        /// </summary>
        public ChatCompletionNamedToolChoice()
        {
        }
    }
}