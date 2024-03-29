// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace DidacticalEnigma.English.LanguageTool.Models
{
    public partial class PathsBppw8BCheckPostResponses200ContentApplicationJsonSchemaPropertiesLanguage
    {
        internal static PathsBppw8BCheckPostResponses200ContentApplicationJsonSchemaPropertiesLanguage DeserializePathsBppw8BCheckPostResponses200ContentApplicationJsonSchemaPropertiesLanguage(JsonElement element)
        {
            string name = default;
            string code = default;
            Paths9LjlvoCheckPostResponses200ContentApplicationJsonSchemaPropertiesLanguagePropertiesDetectedlanguage detectedLanguage = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("code"))
                {
                    code = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("detectedLanguage"))
                {
                    detectedLanguage = Paths9LjlvoCheckPostResponses200ContentApplicationJsonSchemaPropertiesLanguagePropertiesDetectedlanguage.DeserializePaths9LjlvoCheckPostResponses200ContentApplicationJsonSchemaPropertiesLanguagePropertiesDetectedlanguage(property.Value);
                    continue;
                }
            }
            return new PathsBppw8BCheckPostResponses200ContentApplicationJsonSchemaPropertiesLanguage(name, code, detectedLanguage);
        }
    }
}
