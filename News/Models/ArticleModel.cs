using System.Collections.Generic;
using System.Xml.Serialization;

namespace News.Models
{
    [XmlRoot(ElementName = "img")]
    public class Img
    {
        [XmlAttribute(AttributeName = "src")] public string Src { get; set; }

        [XmlAttribute(AttributeName = "alt")] public string Alt { get; set; }
    }

    [XmlRoot(ElementName = "description")]
    public class Description
    {
        [XmlElement(ElementName = "img")] public Img Img { get; set; }

        [XmlElement(ElementName = "p")] public string P { get; set; }
    }

    [XmlRoot(ElementName = "item")]
    public class Item
    {
        public int Id { get; set; }

        [XmlElement(ElementName = "link")] public string Link { get; set; }

        [XmlElement(ElementName = "title")] public string Title { get; set; }

        [XmlElement(ElementName = "author")] public string Author { get; set; }

        [XmlElement(ElementName = "pubDate")] public string PubDate { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        public string Img { get; set; }

        [XmlElement(ElementName = "category")] public string Category { get; set; }

        public Source Source { get; set; }
    }

    [XmlRoot(ElementName = "channel")]
    public class Channel
    {
        [XmlElement(ElementName = "link")] public string Link { get; set; }

        [XmlElement(ElementName = "title")] public string Title { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "pubDate")] public string PubDate { get; set; }

        [XmlElement(ElementName = "generator")]
        public string Generator { get; set; }

        [XmlElement(ElementName = "copyright")]
        public string Copyright { get; set; }

        [XmlElement(ElementName = "lastBuildDate")]
        public string LastBuildDate { get; set; }

        [XmlElement(ElementName = "language")] public string Language { get; set; }

        [XmlElement(ElementName = "item")] public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "rss")]
    public class Rss
    {
        [XmlElement(ElementName = "channel")] public Channel Channel { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
    }

    public enum Source
    {
        NT,
        Expressen,
        SVD
    }
}