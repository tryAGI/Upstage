#nullable enable

namespace Upstage.JsonConverters
{
    /// <inheritdoc />
    public sealed class ChatCompletionToolTypeNullableJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::Upstage.ChatCompletionToolType?>
    {
        /// <inheritdoc />
        public override global::Upstage.ChatCompletionToolType? Read(
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
                        return global::Upstage.ChatCompletionToolTypeExtensions.ToEnum(stringValue);
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::Upstage.ChatCompletionToolType)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::Upstage.ChatCompletionToolType?);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::Upstage.ChatCompletionToolType? value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            if (value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(global::Upstage.ChatCompletionToolTypeExtensions.ToValueString(value.Value));
            }
        }
    }
}
