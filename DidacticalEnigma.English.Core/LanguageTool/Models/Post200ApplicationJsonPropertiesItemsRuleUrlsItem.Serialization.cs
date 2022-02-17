// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace DidacticalEnigma.English.LanguageTool.Models
{
    public partial class Post200ApplicationJsonPropertiesItemsRuleUrlsItem
    {
        internal static Post200ApplicationJsonPropertiesItemsRuleUrlsItem DeserializePost200ApplicationJsonPropertiesItemsRuleUrlsItem(JsonElement element)
        {
            Optional<string> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    value = property.Value.GetString();
                    continue;
                }
            }
            return new Post200ApplicationJsonPropertiesItemsRuleUrlsItem(value.Value);
        }
    }
}
