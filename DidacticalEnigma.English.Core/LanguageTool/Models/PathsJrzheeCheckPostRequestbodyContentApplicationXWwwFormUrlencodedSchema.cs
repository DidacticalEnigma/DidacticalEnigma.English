// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace DidacticalEnigma.English.LanguageTool.Models
{
    /// <summary> The PathsJrzheeCheckPostRequestbodyContentApplicationXWwwFormUrlencodedSchema. </summary>
    internal partial class PathsJrzheeCheckPostRequestbodyContentApplicationXWwwFormUrlencodedSchema
    {
        /// <summary> Initializes a new instance of PathsJrzheeCheckPostRequestbodyContentApplicationXWwwFormUrlencodedSchema. </summary>
        /// <param name="language"> A language code like `en-US`, `de-DE`, `fr`, or `auto` to guess the language automatically (see `preferredVariants` below). For languages with variants (English, German, Portuguese) spell checking will only be activated when you specify the variant, e.g. `en-GB` instead of just `en`. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="language"/> is null. </exception>
        internal PathsJrzheeCheckPostRequestbodyContentApplicationXWwwFormUrlencodedSchema(string language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(nameof(language));
            }

            Language = language;
        }

        /// <summary> The text to be checked. This or &apos;data&apos; is required. </summary>
        public string Text { get; }
        /// <summary>
        /// The text to be checked, given as a JSON document that specifies what&apos;s text and what&apos;s markup. This or &apos;text&apos; is required. Markup will be ignored when looking for errors. Example text: &lt;pre&gt;A &amp;lt;b&gt;test&amp;lt;/b&gt;&lt;/pre&gt;JSON for the example text: &lt;pre&gt;{&quot;annotation&quot;:[
        ///  {&quot;text&quot;: &quot;A &quot;},
        ///  {&quot;markup&quot;: &quot;&amp;lt;b&gt;&quot;},
        ///  {&quot;text&quot;: &quot;test&quot;},
        ///  {&quot;markup&quot;: &quot;&amp;lt;/b&gt;&quot;}
        /// ]}&lt;/pre&gt; &lt;p&gt;If you have markup that should be interpreted as whitespace, like &lt;tt&gt;&amp;lt;p&amp;gt;&lt;/tt&gt; in HTML, you can have it interpreted like this: &lt;pre&gt;{&quot;markup&quot;: &quot;&amp;lt;p&amp;gt;&quot;, &quot;interpretAs&quot;: &quot;\n\n&quot;}&lt;/pre&gt;&lt;p&gt;The &apos;data&apos; feature is not limited to HTML or XML, it can be used for any kind of markup. Entities will need to be expanded in this input.
        /// </summary>
        public string Data { get; }
        /// <summary> A language code like `en-US`, `de-DE`, `fr`, or `auto` to guess the language automatically (see `preferredVariants` below). For languages with variants (English, German, Portuguese) spell checking will only be activated when you specify the variant, e.g. `en-GB` instead of just `en`. </summary>
        public string Language { get; }
        /// <summary> Set to get Premium API access: Your username/email as used to log in at languagetool.org. </summary>
        public string Username { get; }
        /// <summary> Set to get Premium API access: &lt;a target=&apos;_blank&apos; href=&apos;https://languagetool.org/editor/settings/api&apos;&gt;your API key&lt;/a&gt;. </summary>
        public string ApiKey { get; }
        /// <summary> Comma-separated list of dictionaries to include words from; uses special default dictionary if this is unset. </summary>
        public string Dicts { get; }
        /// <summary> A language code of the user&apos;s native language, enabling false friends checks for some language pairs. </summary>
        public string MotherTongue { get; }
        /// <summary> Comma-separated list of preferred language variants. The language detector used with `language=auto` can detect e.g. English, but it cannot decide whether British English or American English is used. Thus this parameter can be used to specify the preferred variants like `en-GB` and `de-AT`. Only available with `language=auto`. You should set variants for at least German and English, as otherwise the spell checking will not work for those, as no spelling dictionary can be selected for just `en` or `de`. </summary>
        public string PreferredVariants { get; }
        /// <summary> IDs of rules to be enabled, comma-separated. </summary>
        public string EnabledRules { get; }
        /// <summary> IDs of rules to be disabled, comma-separated. </summary>
        public string DisabledRules { get; }
        /// <summary> IDs of categories to be enabled, comma-separated. </summary>
        public string EnabledCategories { get; }
        /// <summary> IDs of categories to be disabled, comma-separated. </summary>
        public string DisabledCategories { get; }
        /// <summary> If true, only the rules and categories whose IDs are specified with `enabledRules` or `enabledCategories` are enabled. </summary>
        public bool? EnabledOnly { get; }
        /// <summary> If set to `picky`, additional rules will be activated, i.e. rules that you might only find useful when checking formal text. </summary>
        public PostContentSchemaLevel? Level { get; }
    }
}