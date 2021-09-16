using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DAL.Models
{
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Xml
    {
        [JsonProperty("@version")] public string Version { get; set; }

        [JsonProperty("@encoding")] public string Encoding { get; set; }
    }

    public class Image
    {
        [JsonProperty("url")] public string Url { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("link")] public string Link { get; set; }
    }

    public class Description
    {
        [JsonProperty("#cdata-section")] public string Section { get; set; }
    }

    public class Item
    {
        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("description")] public Description Description { get; set; }

        [JsonProperty("pubDate")] public string PubDate { get; set; }

        [JsonProperty("link")] public string Link { get; set; }

        [JsonProperty("guid")] public string Guid { get; set; }

        [JsonProperty("slash:comments")] public string Comments { get; set; }
    }

    public class Channel
    {
        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("image")] public Image Image { get; set; }

        [JsonProperty("pubDate")] public string PubDate { get; set; }

        [JsonProperty("generator")] public string Generator { get; set; }

        [JsonProperty("link")] public string Link { get; set; }

        [JsonProperty("item")] public List<Item> Item { get; set; }
    }

    public class Rss
    {
        [JsonProperty("@version")] public string Version { get; set; }

        [JsonProperty("@xmlns:slash")] public string Slash { get; set; }

        [JsonProperty("channel")] public Channel Channel { get; set; }
    }

    public class Root
    {
        [JsonProperty("?xml")] public Xml Xml { get; set; }

        [JsonProperty("rss")] public Rss Rss { get; set; }
    }
}