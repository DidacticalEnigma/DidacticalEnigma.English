// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace DidacticalEnigma.English.LanguageTool.Models
{
    public partial class PathsWjwd9LWordsDeletePostResponses200ContentApplicationJsonSchema
    {
        internal static PathsWjwd9LWordsDeletePostResponses200ContentApplicationJsonSchema DeserializePathsWjwd9LWordsDeletePostResponses200ContentApplicationJsonSchema(JsonElement element)
        {
            Optional<bool> deleted = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("deleted"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    deleted = property.Value.GetBoolean();
                    continue;
                }
            }
            return new PathsWjwd9LWordsDeletePostResponses200ContentApplicationJsonSchema(Optional.ToNullable(deleted));
        }
    }
}