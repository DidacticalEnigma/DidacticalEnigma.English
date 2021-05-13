using System;
using System.Xml.Serialization;

namespace DidacticalEnigma.English.Parsing.Models
{
    [XmlRoot("LexicalResource")]
    public class LexicalResource
    {
        [XmlElement("Lexicon")]
        public Lexicon[] Lexicons { get; set; } = Array.Empty<Lexicon>();
    }

    public class Lexicon
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("label")]
        public string Label { get; set; }

        [XmlAttribute("language")]
        public string Language { get; set; }

        [XmlAttribute("email")]
        public string Email { get; set; }

        [XmlAttribute("license")]
        public string License { get; set; }

        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlAttribute("url")]
        public string Url { get; set; }

        [XmlAttribute("citation")]
        public string Citation { get; set; }

        [XmlAttribute("contributor", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Contributor { get; set; }

        [XmlAttribute("coverage", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Coverage { get; set; }

        [XmlAttribute("creator", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Creator { get; set; }

        [XmlAttribute("date", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Date { get; set; }

        [XmlAttribute("description", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Description { get; set; }

        [XmlAttribute("format", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Format { get; set; }

        [XmlAttribute("identifier", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Identifier { get; set; }

        [XmlAttribute("publisher", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Publisher { get; set; }

        [XmlAttribute("relation", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Relation { get; set; }

        [XmlAttribute("rights", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Rights { get; set; }

        [XmlAttribute("source", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Source { get; set; }

        [XmlAttribute("subject", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Subject { get; set; }

        [XmlAttribute("title", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Title { get; set; }

        [XmlAttribute("type", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Type { get; set; }

        [XmlAttribute("status")]
        public string Status { get; set; }

        [XmlAttribute("note")]
        public string Note { get; set; }

        [XmlAttribute("confidenceScore")]
        public string ConfidenceScore { get; set; }

        [XmlElement("LexicalEntry")]
        public LexicalEntry[] LexicalEntries { get; set; } = Array.Empty<LexicalEntry>();
        
        [XmlElement("Synset")]
        public Synset[] Synsets { get; set; } = Array.Empty<Synset>();
    }
    
    public class LexicalEntry
    {
        [XmlElement("Lemma")]
        public Lemma Lemma { get; set; }

        [XmlElement("Form")]
        public Form[] Forms { get; set; } = Array.Empty<Form>();

        [XmlElement("Sense")]
        public Sense[] Senses { get; set; } = Array.Empty<Sense>();

        [XmlElement("SyntacticBehaviour")]
        public SyntacticBehaviour[] SyntacticBehaviours { get; set; } = Array.Empty<SyntacticBehaviour>();
    }

    public class Lemma
    {
        [XmlElement("Tag")]
        public Tag[] Tags { get; set; } = Array.Empty<Tag>();
        
        [XmlAttribute("writtenForm")]
        public string WrittenForm { get; set; }
        
        [XmlAttribute("script")]
        public string Script { get; set; }
        
        [XmlAttribute("partOfSpeech")]
        public PartOfSpeech PartOfSpeech { get; set; }
    }

    public class Tag
    {
        [XmlText]
        public string Text { get; set; }
        
        [XmlAttribute("category")]
        public string Category { get; set; }
    }

    public class Form
    {
        [XmlElement("Tag")]
        public Tag[] Tags { get; set; } = Array.Empty<Tag>();
    
        [XmlAttribute("writtenForm")]
        public string WrittenForm { get; set; }
            
        [XmlAttribute("script")]
        public string Script { get; set; }
    }

    public class Sense
    {
        [XmlElement("SenseRelation")]
        public SenseRelation[] SenseRelation { get; set; } = Array.Empty<SenseRelation>();

        [XmlElement("Example")]
        public Example[] Example { get; set; } = Array.Empty<Example>();

        [XmlElement("Count")]
        public Count[] Count { get; set; } = Array.Empty<Count>();
        
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("synset")]
        public string Synset { get; set; }

        [XmlAttribute("contributor", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Contributor { get; set; }

        [XmlAttribute("coverage", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Coverage { get; set; }

        [XmlAttribute("creator", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Creator { get; set; }

        [XmlAttribute("date", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Date { get; set; }

        [XmlAttribute("description", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Description { get; set; }

        [XmlAttribute("format", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Format { get; set; }

        [XmlAttribute("identifier", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Identifier { get; set; }

        [XmlAttribute("publisher", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Publisher { get; set; }

        [XmlAttribute("relation", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Relation { get; set; }

        [XmlAttribute("rights", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Rights { get; set; }

        [XmlAttribute("source", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Source { get; set; }

        [XmlAttribute("subject", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Subject { get; set; }

        [XmlAttribute("title", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Title { get; set; }

        [XmlAttribute("type", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Type { get; set; }

        [XmlAttribute("status")]
        public string Status { get; set; }

        [XmlAttribute("note")]
        public string Note { get; set; }

        [XmlAttribute("confidenceScore")]
        public string ConfidenceScore { get; set; }

        [XmlAttribute("lexicalized")]
        public string Lexicalized { get; set; }

        [XmlAttribute("adjposition")]
        public AdjPosition Adjposition { get; set; }
    }

    public class Count
    {
        [XmlAttribute("contributor", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Contributor { get; set; }

        [XmlAttribute("coverage", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Coverage { get; set; }

        [XmlAttribute("creator", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Creator { get; set; }

        [XmlAttribute("date", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Date { get; set; }

        [XmlAttribute("description", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Description { get; set; }

        [XmlAttribute("format", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Format { get; set; }

        [XmlAttribute("identifier", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Identifier { get; set; }

        [XmlAttribute("publisher", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Publisher { get; set; }

        [XmlAttribute("relation", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Relation { get; set; }

        [XmlAttribute("rights", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Rights { get; set; }

        [XmlAttribute("source", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Source { get; set; }

        [XmlAttribute("subject", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Subject { get; set; }

        [XmlAttribute("title", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Title { get; set; }

        [XmlAttribute("type", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Type { get; set; }

        [XmlAttribute("status")]
        public string Status { get; set; }

        [XmlAttribute("note")]
        public string Note { get; set; }

        [XmlAttribute("confidenceScore")]
        public string ConfidenceScore { get; set; }
    }

    public class SenseRelation
    {
        [XmlAttribute("target")]
        public string Target { get; set; }

        [XmlAttribute("relType")]
        public SenseRelationType RelType { get; set; }

        [XmlAttribute("contributor", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Contributor { get; set; }

        [XmlAttribute("coverage", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Coverage { get; set; }

        [XmlAttribute("creator", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Creator { get; set; }

        [XmlAttribute("date", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Date { get; set; }

        [XmlAttribute("description", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Description { get; set; }

        [XmlAttribute("format", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Format { get; set; }

        [XmlAttribute("identifier", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Identifier { get; set; }

        [XmlAttribute("publisher", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Publisher { get; set; }

        [XmlAttribute("relation", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Relation { get; set; }

        [XmlAttribute("rights", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Rights { get; set; }

        [XmlAttribute("source", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Source { get; set; }

        [XmlAttribute("subject", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Subject { get; set; }

        [XmlAttribute("title", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Title { get; set; }

        [XmlAttribute("type", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Type { get; set; }

        [XmlAttribute("status")]
        public string Status { get; set; }

        [XmlAttribute("note")]
        public string Note { get; set; }

        [XmlAttribute("confidenceScore")]
        public string ConfidenceScore { get; set; }
    }

    public class SyntacticBehaviour
    {
        [XmlAttribute("subcategorizationFrame")]
        public string SubcategorizationFrame { get; set;}

        [XmlAttribute("senses")]
        public string Senses { get; set;}
    }

    public class Synset
    {
        [XmlElement("Definition")]
        public Definition[] Definitions { get; set; } = Array.Empty<Definition>();

        [XmlElement("ILIDefinition")]
        public ILIDefinition ILIDefinition { get; set; }

        [XmlElement("SynsetRelation")]
        public SynsetRelation[] SynsetRelations { get; set; } = Array.Empty<SynsetRelation>();

        [XmlElement("Example")]
        public Example[] Examples { get; set; } = Array.Empty<Example>();
        
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("ili")]
        public string Ili { get; set; }

        [XmlAttribute("partOfSpeech")]
        public PartOfSpeech PartOfSpeech { get; set; }

        [XmlAttribute("contributor", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Contributor { get; set; }

        [XmlAttribute("coverage", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Coverage { get; set; }

        [XmlAttribute("creator", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Creator { get; set; }

        [XmlAttribute("date", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Date { get; set; }

        [XmlAttribute("description", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Description { get; set; }

        [XmlAttribute("format", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Format { get; set; }

        [XmlAttribute("identifier", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Identifier { get; set; }

        [XmlAttribute("publisher", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Publisher { get; set; }

        [XmlAttribute("relation", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Relation { get; set; }

        [XmlAttribute("rights", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Rights { get; set; }

        [XmlAttribute("source", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Source { get; set; }

        [XmlAttribute("subject", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Subject { get; set; }

        [XmlAttribute("title", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Title { get; set; }

        [XmlAttribute("type", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Type { get; set; }

        [XmlAttribute("status")]
        public string Status { get; set; }

        [XmlAttribute("note")]
        public string Note { get; set; }

        [XmlAttribute("confidenceScore")]
        public string ConfidenceScore { get; set; }

        [XmlAttribute("lexicalized")]
        public bool Lexicalized { get; set; }
    }

    public class Definition
    {
        [XmlText]
        public string Text { get; set; }
        
        [XmlAttribute("language")]
        public string Language { get; set; }

        [XmlAttribute("sourceSense")]
        public string SourceSense { get; set; }

        [XmlAttribute("contributor", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Contributor { get; set; }

        [XmlAttribute("coverage", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Coverage { get; set; }

        [XmlAttribute("creator", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Creator { get; set; }

        [XmlAttribute("date", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Date { get; set; }

        [XmlAttribute("description", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Description { get; set; }

        [XmlAttribute("format", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Format { get; set; }

        [XmlAttribute("identifier", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Identifier { get; set; }

        [XmlAttribute("publisher", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Publisher { get; set; }

        [XmlAttribute("relation", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Relation { get; set; }

        [XmlAttribute("rights", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Rights { get; set; }

        [XmlAttribute("source", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Source { get; set; }

        [XmlAttribute("subject", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Subject { get; set; }

        [XmlAttribute("title", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Title { get; set; }

        [XmlAttribute("type", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Type { get; set; }

        [XmlAttribute("status")]
        public string Status { get; set; }

        [XmlAttribute("note")]
        public string Note { get; set; }

        [XmlAttribute("confidenceScore")]
        public string ConfidenceScore { get; set; }
    }

    public class ILIDefinition
    {
        [XmlText]
        public string Text { get; set; }
        
        [XmlAttribute("contributor", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Contributor { get; set; }

        [XmlAttribute("coverage", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Coverage { get; set; }

        [XmlAttribute("creator", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Creator { get; set; }

        [XmlAttribute("date", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Date { get; set; }

        [XmlAttribute("description", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Description { get; set; }

        [XmlAttribute("format", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Format { get; set; }

        [XmlAttribute("identifier", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Identifier { get; set; }

        [XmlAttribute("publisher", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Publisher { get; set; }

        [XmlAttribute("relation", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Relation { get; set; }

        [XmlAttribute("rights", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Rights { get; set; }

        [XmlAttribute("source", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Source { get; set; }

        [XmlAttribute("subject", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Subject { get; set; }

        [XmlAttribute("title", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Title { get; set; }

        [XmlAttribute("type", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Type { get; set; }

        [XmlAttribute("status")]
        public string Status { get; set; }

        [XmlAttribute("note")]
        public string Note { get; set; }

        [XmlAttribute("confidenceScore")]
        public string ConfidenceScore { get; set; }
    }

    public class SynsetRelation
    {
        [XmlAttribute("target")]
        public string Target { get; set; }

        [XmlAttribute("relType")]
        public SynsetRelationType RelType { get; set; }

        [XmlAttribute("contributor", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Contributor { get; set; }

        [XmlAttribute("coverage", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Coverage { get; set; }

        [XmlAttribute("creator", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Creator { get; set; }

        [XmlAttribute("date", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Date { get; set; }

        [XmlAttribute("description", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Description { get; set; }

        [XmlAttribute("format", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Format { get; set; }

        [XmlAttribute("identifier", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Identifier { get; set; }

        [XmlAttribute("publisher", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Publisher { get; set; }

        [XmlAttribute("relation", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Relation { get; set; }

        [XmlAttribute("rights", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Rights { get; set; }

        [XmlAttribute("source", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Source { get; set; }

        [XmlAttribute("subject", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Subject { get; set; }

        [XmlAttribute("title", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Title { get; set; }

        [XmlAttribute("type", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Type { get; set; }

        [XmlAttribute("status")]
        public string Status { get; set; }

        [XmlAttribute("note")]
        public string Note { get; set; }

        [XmlAttribute("confidenceScore")]
        public string ConfidenceScore { get; set; }
    }

    public class Example
    {
        [XmlText]
        public string Text { get; set; }
        
        [XmlAttribute("language")]
        public string Language { get; set; }

        [XmlAttribute("contributor", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Contributor { get; set; }

        [XmlAttribute("coverage", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Coverage { get; set; }

        [XmlAttribute("creator", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Creator { get; set; }

        [XmlAttribute("date", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Date { get; set; }

        [XmlAttribute("description", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Description { get; set; }

        [XmlAttribute("format", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Format { get; set; }

        [XmlAttribute("identifier", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Identifier { get; set; }

        [XmlAttribute("publisher", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Publisher { get; set; }

        [XmlAttribute("relation", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Relation { get; set; }

        [XmlAttribute("rights", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Rights { get; set; }

        [XmlAttribute("source", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Source { get; set; }

        [XmlAttribute("subject", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Subject { get; set; }

        [XmlAttribute("title", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Title { get; set; }

        [XmlAttribute("type", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Type { get; set; }

        [XmlAttribute("status")]
        public string Status { get; set; }

        [XmlAttribute("note")]
        public string Note { get; set; }

        [XmlAttribute("confidenceScore")]
        public string ConfidenceScore { get; set; }
    }

    public enum PartOfSpeech
    {
        [XmlEnum(Name = "n")]
        Noun,
        [XmlEnum(Name = "v")]
        Verb,
        [XmlEnum(Name = "a")]
        Adjective,
        [XmlEnum(Name = "r")]
        Adverb,
        [XmlEnum(Name = "s")]
        AdjectiveSatellite,
        [XmlEnum(Name = "t")]
        TODO,
        [XmlEnum(Name = "c")]
        Conjunction,
        [XmlEnum(Name = "p")]
        Adposition,
        [XmlEnum(Name = "x")]
        Other,
        [XmlEnum(Name = "u")]
        Unknown,
    }

    public enum SenseRelationType
    {
        [XmlEnum("antonym")]
        Antonym,
        [XmlEnum("also")]
        Also,
        [XmlEnum("participle")]
        Participle,
        [XmlEnum("pertainym")]
        Pertainym,
        [XmlEnum("derivation")]
        Derivation,
        [XmlEnum("domain_topic")]
        DomainTopic,
        [XmlEnum("has_domain_topic")]
        HasDomainTopic,
        [XmlEnum("domain_region")]
        DomainRegion,
        [XmlEnum("has_domain_region")]
        HasDomainRegion,
        [XmlEnum("exemplifies")]
        Exemplifies,
        [XmlEnum("is_exemplified_by")]
        IsExemplifiedBy,
        [XmlEnum("similar")]
        Similar,
        [XmlEnum("other")]
        Other
    }

    public enum SynsetRelationType
    {
        [XmlEnum("agent")]
        agent,
        [XmlEnum("also")]
        also,
        [XmlEnum("attribute")]
        attribute,
        [XmlEnum("be_in_state")]
        be_in_state,
        [XmlEnum("causes")]
        causes,
        [XmlEnum("classified_by")]
        classified_by,
        [XmlEnum("classifies")]
        classifies,
        [XmlEnum("co_agent_instrument")]
        co_agent_instrument,
        [XmlEnum("co_agent_patient")]
        co_agent_patient,
        [XmlEnum("co_agent_result")]
        co_agent_result,
        [XmlEnum("co_instrument_agent")]
        co_instrument_agent,
        [XmlEnum("co_instrument_patient")]
        co_instrument_patient,
        [XmlEnum("co_instrument_result")]
        co_instrument_result,
        [XmlEnum("co_patient_agent")]
        co_patient_agent,
        [XmlEnum("co_patient_instrument")]
        co_patient_instrument,
        [XmlEnum("co_result_agent")]
        co_result_agent,
        [XmlEnum("co_result_instrument")]
        co_result_instrument,
        [XmlEnum("co_role")]
        co_role,
        [XmlEnum("direction")]
        direction,
        [XmlEnum("domain_region")]
        domain_region,
        [XmlEnum("domain_topic")]
        domain_topic,
        [XmlEnum("exemplifies")]
        exemplifies,
        [XmlEnum("entails")]
        entails,
        [XmlEnum("eq_synonym")]
        eq_synonym,
        [XmlEnum("has_domain_region")]
        has_domain_region,
        [XmlEnum("has_domain_topic")]
        has_domain_topic,
        [XmlEnum("is_exemplified_by")]
        is_exemplified_by,
        [XmlEnum("holo_location")]
        holo_location,
        [XmlEnum("holo_member")]
        holo_member,
        [XmlEnum("holo_part")]
        holo_part,
        [XmlEnum("holo_portion")]
        holo_portion,
        [XmlEnum("holo_substance")]
        holo_substance,
        [XmlEnum("holonym")]
        holonym,
        [XmlEnum("hypernym")]
        hypernym,
        [XmlEnum("hyponym")]
        hyponym,
        [XmlEnum("in_manner")]
        in_manner,
        [XmlEnum("instance_hypernym")]
        instance_hypernym,
        [XmlEnum("instance_hyponym")]
        instance_hyponym,
        [XmlEnum("instrument")]
        instrument,
        [XmlEnum("involved")]
        involved,
        [XmlEnum("involved_agent")]
        involved_agent,
        [XmlEnum("involved_direction")]
        involved_direction,
        [XmlEnum("involved_instrument")]
        involved_instrument,
        [XmlEnum("involved_location")]
        involved_location,
        [XmlEnum("involved_patient")]
        involved_patient,
        [XmlEnum("involved_result")]
        involved_result,
        [XmlEnum("involved_source_direction")]
        involved_source_direction,
        [XmlEnum("involved_target_direction")]
        involved_target_direction,
        [XmlEnum("is_caused_by")]
        is_caused_by,
        [XmlEnum("is_entailed_by")]
        is_entailed_by,
        [XmlEnum("location")]
        location,
        [XmlEnum("manner_of")]
        manner_of,
        [XmlEnum("mero_location")]
        mero_location,
        [XmlEnum("mero_member")]
        mero_member,
        [XmlEnum("mero_part")]
        mero_part,
        [XmlEnum("mero_portion")]
        mero_portion,
        [XmlEnum("mero_substance")]
        mero_substance,
        [XmlEnum("meronym")]
        meronym,
        [XmlEnum("similar")]
        similar,
        [XmlEnum("other")]
        other,
        [XmlEnum("patient")]
        patient,
        [XmlEnum("restricted_by")]
        restricted_by,
        [XmlEnum("restricts")]
        restricts,
        [XmlEnum("result")]
        result,
        [XmlEnum("role")]
        role,
        [XmlEnum("source_direction")]
        source_direction,
        [XmlEnum("state_of")]
        state_of,
        [XmlEnum("target_direction")]
        target_direction,
        [XmlEnum("subevent")]
        subevent,
        [XmlEnum("is_subevent_of")]
        is_subevent_of,
        [XmlEnum("antonym")]
        antonym,
    }

    public enum AdjPosition
    {
        [XmlEnum("a")]
        A,
        [XmlEnum("ip")]
        Ip,
        [XmlEnum("p")]
        P,
    }
}
