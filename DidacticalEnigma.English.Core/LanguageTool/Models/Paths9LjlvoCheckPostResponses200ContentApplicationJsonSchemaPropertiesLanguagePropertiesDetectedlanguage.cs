// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace DidacticalEnigma.English.LanguageTool.Models
{
    /// <summary> The automatically detected text language (might be different from the language actually used for checking). </summary>
    public partial class Paths9LjlvoCheckPostResponses200ContentApplicationJsonSchemaPropertiesLanguagePropertiesDetectedlanguage
    {
        /// <summary> Initializes a new instance of Paths9LjlvoCheckPostResponses200ContentApplicationJsonSchemaPropertiesLanguagePropertiesDetectedlanguage. </summary>
        /// <param name="name"> Language name like &apos;French&apos; or &apos;English (US)&apos;. </param>
        /// <param name="code"> ISO 639-1 code like &apos;en&apos;, &apos;en-US&apos;, or &apos;ca-ES-valencia&apos;. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="code"/> is null. </exception>
        internal Paths9LjlvoCheckPostResponses200ContentApplicationJsonSchemaPropertiesLanguagePropertiesDetectedlanguage(string name, string code)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (code == null)
            {
                throw new ArgumentNullException(nameof(code));
            }

            Name = name;
            Code = code;
        }

        /// <summary> Language name like &apos;French&apos; or &apos;English (US)&apos;. </summary>
        public string Name { get; }
        /// <summary> ISO 639-1 code like &apos;en&apos;, &apos;en-US&apos;, or &apos;ca-ES-valencia&apos;. </summary>
        public string Code { get; }
    }
}