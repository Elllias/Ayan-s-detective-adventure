using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("dialogue")]
public class Dialogue
{
    [XmlElement("text")]
    public string text;

    [XmlElement("node")]
    public Node[] nodes;

    public static Dialogue Load(TextAsset xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Dialogue));
        StringReader reader = new StringReader(xml.text);
        Dialogue dialogue = serializer.Deserialize(reader) as Dialogue;
        return dialogue;
    }
}