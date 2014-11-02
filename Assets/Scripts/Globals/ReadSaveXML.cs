using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System;

public static class ReadSaveXML {

    const string LevelFiles = @"Levels/";
    
    public static Level LoadDataFromLevel(string LevelPath, int LevelNumber)
    {
        string fullLenghtPath = LevelFiles + LevelPath + "/" +  Convert.ToString(LevelNumber);
        if (!File.Exists(@"Assets/Resources/" + fullLenghtPath + ".txt"))
            return null;

        TextAsset achTxt = (TextAsset)Resources.Load(fullLenghtPath);
        //TODO: decrypt Text

        string[] lines = achTxt.text.Split('\n');

        Level lvl = new Level(lines[0], lines[1], lines[2]);

        return lvl;
    }

    public static void SaveData(Level _data, string LevelPath, int LevelNumber)
    {
        string fullLenghtPath = @"Assets/Resources/" + LevelFiles + LevelPath + "/" + Convert.ToString(LevelNumber);
        FileInfo t = new FileInfo(fullLenghtPath + ".txt");
        if(t.Exists)
            t.Delete();

        //TODO: encrypt text

        using (StreamWriter sw = File.CreateText(fullLenghtPath))
        {
            sw.WriteLine("Points:" + Convert.ToString(_data.Points));
            sw.WriteLine("I");
            sw.WriteLine("am.");
        }

        Debug.Log("File written.");
    }
}

public class Level
{
    public int Points { get; set; }
    public int Unlock3StarsPoints { get; set; }
    public int UnlockedStars { get; set; }

    public Level(string _points, string _unlock3StarsPoints, string _unlockedStars)
    {
        string[] pointsInfo = _points.Split(':');
        Points = Convert.ToInt32(pointsInfo[1]);

        string[] unlock3StarsInfo = _unlock3StarsPoints.Split(':');
        Unlock3StarsPoints = Convert.ToInt32(unlock3StarsInfo[1]);

        string[] unlockedStarsInfo = _unlockedStars.Split(':');
        UnlockedStars = Convert.ToInt32(unlockedStarsInfo[1]);

    }
}
