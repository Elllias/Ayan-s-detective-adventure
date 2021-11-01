using System.Collections;
using System.Collections.Generic;
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

    public static Dialogue Load(TextAsset xml) // Инициализация диалогов
    {
        XmlSerializer ser = new XmlSerializer(typeof(Dialogue));
        StringReader reader = new StringReader(xml.text);
        Dialogue dialogue = ser.Deserialize(reader) as Dialogue;
        return dialogue;
    }

    [System.Serializable]
    public class Node
    {
        [XmlElement("npctext")]
        public string npctext;

        [XmlArray("answers")]
        [XmlArrayItem("answer")]
        public Answer[] answers;
    }

    public class Answer
    {
        [XmlAttribute("tonode")]
        public int nextNode;
        [XmlElement("text")]
        public string text;
        [XmlElement("end")]
        public string end;
    }

}
