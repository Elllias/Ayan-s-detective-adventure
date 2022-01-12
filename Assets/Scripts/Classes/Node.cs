using UnityEngine;
using System.Xml.Serialization;

public class Node
{
    [XmlElement("ucw")]
    public string ucw; //UnCommonWindow

    [XmlElement("npcname")]
    public string npcname;

    [XmlElement("sound")]
    public string sound;

    [XmlElement("background")]
    public string background;

    [XmlElement("npctext")]
    public string npctext;

    [XmlArray("answers")]
    [XmlArrayItem("answer")]
    public Answer[] answers;
}
