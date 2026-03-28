
#nullable enable

#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS3016 // Arrays as attribute arguments is not CLS-compliant

namespace Upstage
{
    /// <summary>
    /// 
    /// </summary>
    [global::System.Text.Json.Serialization.JsonSourceGenerationOptions(
        DefaultIgnoreCondition = global::System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        Converters = new global::System.Type[]
        {
            typeof(global::Upstage.JsonConverters.ChatCompletionRequestToolChoiceJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatCompletionRequestToolChoiceNullableJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatMessageRoleJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatMessageRoleNullableJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatContentPartTypeJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatContentPartTypeNullableJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatContentPartImageUrlDetailJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatContentPartImageUrlDetailNullableJsonConverter),

            typeof(global::Upstage.JsonConverters.ResponseFormatTypeJsonConverter),

            typeof(global::Upstage.JsonConverters.ResponseFormatTypeNullableJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatCompletionToolTypeJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatCompletionToolTypeNullableJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatCompletionNamedToolChoiceTypeJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatCompletionNamedToolChoiceTypeNullableJsonConverter),

            typeof(global::Upstage.JsonConverters.ToolCallTypeJsonConverter),

            typeof(global::Upstage.JsonConverters.ToolCallTypeNullableJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatCompletionResponseObjectJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatCompletionResponseObjectNullableJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatCompletionChoiceFinishReasonJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatCompletionChoiceFinishReasonNullableJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatCompletionMessageRoleJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatCompletionMessageRoleNullableJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatCompletionChunkResponseObjectJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatCompletionChunkResponseObjectNullableJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatCompletionChunkChoiceFinishReasonJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatCompletionChunkChoiceFinishReasonNullableJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatCompletionDeltaRoleJsonConverter),

            typeof(global::Upstage.JsonConverters.ChatCompletionDeltaRoleNullableJsonConverter),

            typeof(global::Upstage.JsonConverters.ToolCallChunkTypeJsonConverter),

            typeof(global::Upstage.JsonConverters.ToolCallChunkTypeNullableJsonConverter),

            typeof(global::Upstage.JsonConverters.EmbeddingResponseObjectJsonConverter),

            typeof(global::Upstage.JsonConverters.EmbeddingResponseObjectNullableJsonConverter),

            typeof(global::Upstage.JsonConverters.EmbeddingDataObjectJsonConverter),

            typeof(global::Upstage.JsonConverters.EmbeddingDataObjectNullableJsonConverter),

            typeof(global::Upstage.JsonConverters.DocumentElementTypeJsonConverter),

            typeof(global::Upstage.JsonConverters.DocumentElementTypeNullableJsonConverter),

            typeof(global::Upstage.JsonConverters.LayoutElementTypeJsonConverter),

            typeof(global::Upstage.JsonConverters.LayoutElementTypeNullableJsonConverter),

            typeof(global::Upstage.JsonConverters.DocumentParseRequestOcrJsonConverter),

            typeof(global::Upstage.JsonConverters.DocumentParseRequestOcrNullableJsonConverter),

            typeof(global::Upstage.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>),

            typeof(global::Upstage.JsonConverters.OneOfJsonConverter<global::Upstage.ChatCompletionRequestToolChoice?, global::Upstage.ChatCompletionNamedToolChoice>),

            typeof(global::Upstage.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<global::Upstage.ChatContentPart>>),

            typeof(global::Upstage.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>),

            typeof(global::Upstage.JsonConverters.UnixTimestampJsonConverter),
        })]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.JsonSerializerContextTypes))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatCompletionRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(string))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Upstage.ChatMessage>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatMessage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(double))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(int))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.OneOf<string, global::System.Collections.Generic.IList<string>>), TypeInfoPropertyName = "OneOfStringIListString2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<string>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(bool))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ResponseFormat))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Upstage.ChatCompletionTool>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatCompletionTool))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.OneOf<global::Upstage.ChatCompletionRequestToolChoice?, global::Upstage.ChatCompletionNamedToolChoice>), TypeInfoPropertyName = "OneOfChatCompletionRequestToolChoiceChatCompletionNamedToolChoice2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatCompletionRequestToolChoice), TypeInfoPropertyName = "ChatCompletionRequestToolChoice2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatCompletionNamedToolChoice))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatMessageRole), TypeInfoPropertyName = "ChatMessageRole2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.OneOf<string, global::System.Collections.Generic.IList<global::Upstage.ChatContentPart>>), TypeInfoPropertyName = "OneOfStringIListChatContentPart2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Upstage.ChatContentPart>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatContentPart))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Upstage.ToolCall>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ToolCall))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatContentPartType), TypeInfoPropertyName = "ChatContentPartType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatContentPartImageUrl))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatContentPartImageUrlDetail), TypeInfoPropertyName = "ChatContentPartImageUrlDetail2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ResponseFormatType), TypeInfoPropertyName = "ResponseFormatType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatCompletionToolType), TypeInfoPropertyName = "ChatCompletionToolType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.FunctionDefinition))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(object))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatCompletionNamedToolChoiceType), TypeInfoPropertyName = "ChatCompletionNamedToolChoiceType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatCompletionNamedToolChoiceFunction))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ToolCallType), TypeInfoPropertyName = "ToolCallType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ToolCallFunction))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatCompletionResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatCompletionResponseObject), TypeInfoPropertyName = "ChatCompletionResponseObject2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.DateTimeOffset))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Upstage.ChatCompletionChoice>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatCompletionChoice))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.Usage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatCompletionMessage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatCompletionChoiceFinishReason), TypeInfoPropertyName = "ChatCompletionChoiceFinishReason2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatCompletionMessageRole), TypeInfoPropertyName = "ChatCompletionMessageRole2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatCompletionChunkResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatCompletionChunkResponseObject), TypeInfoPropertyName = "ChatCompletionChunkResponseObject2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Upstage.ChatCompletionChunkChoice>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatCompletionChunkChoice))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatCompletionDelta))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatCompletionChunkChoiceFinishReason), TypeInfoPropertyName = "ChatCompletionChunkChoiceFinishReason2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ChatCompletionDeltaRole), TypeInfoPropertyName = "ChatCompletionDeltaRole2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Upstage.ToolCallChunk>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ToolCallChunk))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ToolCallChunkType), TypeInfoPropertyName = "ToolCallChunkType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ToolCallChunkFunction))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.EmbeddingRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.EmbeddingResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.EmbeddingResponseObject), TypeInfoPropertyName = "EmbeddingResponseObject2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Upstage.EmbeddingData>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.EmbeddingData))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.EmbeddingUsage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.EmbeddingDataObject), TypeInfoPropertyName = "EmbeddingDataObject2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<double>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.DocumentParseResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.DocumentParseContent))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.DocumentParseUsage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Upstage.DocumentElement>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.DocumentElement))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.DocumentElementType), TypeInfoPropertyName = "DocumentElementType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.DocumentElementContent))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Upstage.DocumentElementCoordinate>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.DocumentElementCoordinate))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.OcrResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Upstage.OcrPage>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.OcrPage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.OcrUsage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Upstage.OcrWord>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.OcrWord))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.OcrWordBoundingBox))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.LayoutAnalysisResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Upstage.LayoutElement>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.LayoutElement))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Upstage.LayoutPage>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.LayoutPage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.LayoutAnalysisUsage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.LayoutElementType), TypeInfoPropertyName = "LayoutElementType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.LayoutElementBoundingBox))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.GroundednessCheckRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.GroundednessCheckResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.TranslationRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.TranslationResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.TranslationResponseOutput))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ErrorResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.ErrorResponseError))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.DocumentParseRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(byte[]))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.DocumentParseRequestOcr), TypeInfoPropertyName = "DocumentParseRequestOcr2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.DocumentOcrRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.LayoutAnalysisRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Upstage.ChatMessage>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.OneOf<string, global::System.Collections.Generic.List<string>>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<string>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Upstage.ChatCompletionTool>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Upstage.OneOf<string, global::System.Collections.Generic.List<global::Upstage.ChatContentPart>>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Upstage.ChatContentPart>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Upstage.ToolCall>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Upstage.ChatCompletionChoice>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Upstage.ChatCompletionChunkChoice>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Upstage.ToolCallChunk>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Upstage.EmbeddingData>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<double>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Upstage.DocumentElement>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Upstage.DocumentElementCoordinate>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Upstage.OcrPage>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Upstage.OcrWord>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Upstage.LayoutElement>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Upstage.LayoutPage>))]
    public sealed partial class SourceGenerationContext : global::System.Text.Json.Serialization.JsonSerializerContext
    {
    }
}