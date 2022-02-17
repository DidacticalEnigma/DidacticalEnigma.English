// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace DidacticalEnigma.English.LanguageTool.Models
{
    /// <summary> The Post200ApplicationJsonPropertiesItemsRuleCategory. </summary>
    public partial class Post200ApplicationJsonPropertiesItemsRuleCategory
    {
        /// <summary> Initializes a new instance of Post200ApplicationJsonPropertiesItemsRuleCategory. </summary>
        internal Post200ApplicationJsonPropertiesItemsRuleCategory()
        {
        }

        /// <summary> Initializes a new instance of Post200ApplicationJsonPropertiesItemsRuleCategory. </summary>
        /// <param name="id"> A category&apos;s identifier that&apos;s unique for this language. </param>
        /// <param name="name"> A short description of the category. </param>
        internal Post200ApplicationJsonPropertiesItemsRuleCategory(string id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary> A category&apos;s identifier that&apos;s unique for this language. </summary>
        public string Id { get; }
        /// <summary> A short description of the category. </summary>
        public string Name { get; }
    }
}
