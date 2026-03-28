#nullable enable

namespace Upstage.JsonConverters
{
    /// <inheritdoc />
    public sealed class EmbeddingResponseObjectNullableJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::Upstage.EmbeddingResponseObject?>
    {
        /// <inheritdoc />
        public override global::Upstage.EmbeddingResponseObject? Read(
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
                        return global::Upstage.EmbeddingResponseObjectExtensions.ToEnum(stringValue);
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::Upstage.EmbeddingResponseObject)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::Upstage.EmbeddingResponseObject?);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::Upstage.EmbeddingResponseObject? value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            if (value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(global::Upstage.EmbeddingResponseObjectExtensions.ToValueString(value.Value));
            }
        }
    }
}
