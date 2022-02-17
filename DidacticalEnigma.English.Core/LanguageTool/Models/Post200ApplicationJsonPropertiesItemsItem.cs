// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace DidacticalEnigma.English.LanguageTool.Models
{
    /// <summary> The Post200ApplicationJsonPropertiesItemsItem. </summary>
    public partial class Post200ApplicationJsonPropertiesItemsItem
    {
        /// <summary> Initializes a new instance of Post200ApplicationJsonPropertiesItemsItem. </summary>
        /// <param name="message"> Message about the error displayed to the user. </param>
        /// <param name="offset"> The 0-based character offset of the error in the text. </param>
        /// <param name="length"> The length of the error in characters. </param>
        /// <param name="replacements"> Replacements that might correct the error. The array can be empty, in this case there is no suggested replacement. </param>
        /// <param name="context"></param>
        /// <param name="sentence"> The sentence the error occurred in (since LanguageTool 4.0 or later). </param>
        /// <exception cref="ArgumentNullException"> <paramref name="message"/>, <paramref name="replacements"/>, <paramref name="context"/> or <paramref name="sentence"/> is null. </exception>
        internal Post200ApplicationJsonPropertiesItemsItem(string message, int offset, int length, IEnumerable<Post200ApplicationJsonPropertiesItemsReplacementsItem> replacements, PostResponses200ContentApplicationJsonSchemaMatchesItemContext context, string sentence)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            if (replacements == null)
            {
                throw new ArgumentNullException(nameof(replacements));
            }
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (sentence == null)
            {
                throw new ArgumentNullException(nameof(sentence));
            }

            Message = message;
            Offset = offset;
            Length = length;
            Replacements = replacements.ToList();
            Context = context;
            Sentence = sentence;
        }

        /// <summary> Initializes a new instance of Post200ApplicationJsonPropertiesItemsItem. </summary>
        /// <param name="message"> Message about the error displayed to the user. </param>
        /// <param name="shortMessage"> An optional shorter version of &apos;message&apos;. </param>
        /// <param name="offset"> The 0-based character offset of the error in the text. </param>
        /// <param name="length"> The length of the error in characters. </param>
        /// <param name="replacements"> Replacements that might correct the error. The array can be empty, in this case there is no suggested replacement. </param>
        /// <param name="context"></param>
        /// <param name="sentence"> The sentence the error occurred in (since LanguageTool 4.0 or later). </param>
        /// <param name="rule"></param>
        internal Post200ApplicationJsonPropertiesItemsItem(string message, string shortMessage, int offset, int length, IReadOnlyList<Post200ApplicationJsonPropertiesItemsReplacementsItem> replacements, PostResponses200ContentApplicationJsonSchemaMatchesItemContext context, string sentence, PostResponses200ContentApplicationJsonSchemaMatchesItemRule rule)
        {
            Message = message;
            ShortMessage = shortMessage;
            Offset = offset;
            Length = length;
            Replacements = replacements;
            Context = context;
            Sentence = sentence;
            Rule = rule;
        }

        /// <summary> Message about the error displayed to the user. </summary>
        public string Message { get; }
        /// <summary> An optional shorter version of &apos;message&apos;. </summary>
        public string ShortMessage { get; }
        /// <summary> The 0-based character offset of the error in the text. </summary>
        public int Offset { get; }
        /// <summary> The length of the error in characters. </summary>
        public int Length { get; }
        /// <summary> Replacements that might correct the error. The array can be empty, in this case there is no suggested replacement. </summary>
        public IReadOnlyList<Post200ApplicationJsonPropertiesItemsReplacementsItem> Replacements { get; }
        /// <summary> Gets the context. </summary>
        public PostResponses200ContentApplicationJsonSchemaMatchesItemContext Context { get; }
        /// <summary> The sentence the error occurred in (since LanguageTool 4.0 or later). </summary>
        public string Sentence { get; }
        /// <summary> Gets the rule. </summary>
        public PostResponses200ContentApplicationJsonSchemaMatchesItemRule Rule { get; }
    }
}
