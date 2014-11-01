using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public static class ReadSaveXML {

}

[XmlRoot("Levels")]
public class Levels
{
    [XmlIgnore]
    const string xmlFile = @"Assets/Resources/LevelsUnlock.xml";

    [XmlAttribute("Level")]
    public Level[] Level;

    public void Save()
    {
        if (File.Exists(xmlFile))
            File.Delete(xmlFile);

        var serializer = new XmlSerializer(typeof(Levels));
        using (var stream = new FileStream(xmlFile, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }
    public static Levels Load()
    {
        var serializer = new XmlSerializer(typeof(Levels));
        using (var stream = new FileStream(xmlFile, FileMode.Open))
        {
            return serializer.Deserialize(stream) as Levels;
        }
    }
}

[XmlRoot("Level")]
public class Level
{
    [XmlAttribute("number")]
    public int number;
    [XmlAttribute("Points")]
    public int Points;
    [XmlAttribute("Unlock3StarsPoints")]
    public int Unlock3StarsPoints;
    [XmlAttribute("UnlockedStars")]
    public int UnlockedStars;
}
