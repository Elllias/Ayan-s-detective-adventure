using UnityEngine;
using System.Xml.Serialization;

public class Answer
{
    [XmlAttribute("tonode")]
    public int nextNode;
    [XmlAttribute("emotion")]
    public string emotion;
    [XmlElement("text")]
    public string text;
    [XmlElement("end")]
    public string end;
}
