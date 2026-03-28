#nullable enable

namespace Upstage.JsonConverters
{
    /// <inheritdoc />
    public sealed class ChatCompletionChunkResponseObjectNullableJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::Upstage.ChatCompletionChunkResponseObject?>
    {
        /// <inheritdoc />
        public override global::Upstage.ChatCompletionChunkResponseObject? Read(
            ref global::System.Text.Json.Utf8JsonReader reader,
            global::System.Type typeToConvert,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case global::System.Text.Json.JsonTokenType.String:
                {
                    var stringValue = reader.GetString();
                    if (stringValue != null)
                    {
                        return global::Upstage.ChatCompletionChunkResponseObjectExtensions.ToEnum(stringValue);
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::Upstage.ChatCompletionChunkResponseObject)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::Upstage.ChatCompletionChunkResponseObject?);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::Upstage.ChatCompletionChunkResponseObject? value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            if (value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(global::Upstage.ChatCompletionChunkResponseObjectExtensions.ToValueString(value.Value));
            }
        }
    }
}
