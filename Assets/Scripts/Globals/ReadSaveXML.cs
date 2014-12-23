using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System;
using System.Security;
using System.Security.Cryptography;

public static class ReadSaveXML {

    private static string filePathRoot = Application.persistentDataPath + "/Levels/";

    static ReadSaveXML()
    {
    }

    public static Level LoadDataFromLevel(string LevelPath, int LevelNumber)
    {
        string fullLenghtPath = LevelPath + "/" + Convert.ToString(LevelNumber); ;
        string[] lines;

        if (File.Exists(filePathRoot + fullLenghtPath + ".txt"))
        {
            System.IO.StreamReader file = new System.IO.StreamReader(filePathRoot + fullLenghtPath + ".txt");

            lines = file.ReadToEnd().Split('\n');
        }else
        {
            TextAsset achTxt = (TextAsset)Resources.Load("Levels/" + fullLenghtPath);
            lines = achTxt.text.Split('\n');
        }
        
        Level lvl;
        if (lines[3].Contains("isEncrypted: 1"))
            lvl = new Level(Decrypt(lines[0]), Decrypt(lines[1]), Decrypt(lines[2]), lines[3]);
        else
            lvl = new Level(lines[0], lines[1], lines[2], lines[3]);
        
        return lvl;
    }

    public static void SaveData(Level _data, string LevelPath, int LevelNumber)
    {
        string lastFolderPath = filePathRoot + LevelPath;
        if (!Directory.Exists(lastFolderPath))
            Directory.CreateDirectory(lastFolderPath);

        //string fullLenghtPath = filePathRoot + LevelPath + "/" + Convert.ToString(LevelNumber);

        //FileInfo t = new FileInfo(fullLenghtPath);
        //if(t.Exists)
        //    t.Delete();

        //using (StreamWriter sw = File.CreateText(fullLenghtPath + ".txt"))
        //{
        //    sw.WriteLine(Encrypt("Points:" + Convert.ToString(_data.Points)));
        //    sw.WriteLine(Encrypt("Unlock3StarsPoints:" + Convert.ToString(_data.Unlock3StarsPoints)));
        //    sw.WriteLine(Encrypt("UnlockedStars:" + Convert.ToString(_data.UnlockedStars)));
        //    sw.WriteLine("isEncrypted: 1");
        //}
    }

    static string Encrypt(string clearText)
    {
        //string EncryptionKey = "MAKV2SPBNI99212";
        //byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);

        //using (Aes encryptor = Aes.Create())
        //{
        //    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //    encryptor.Key = pdb.GetBytes(32);
        //    encryptor.IV = pdb.GetBytes(16);
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
        //        {
        //            cs.Write(clearBytes, 0, clearBytes.Length);
        //            cs.Close();
        //        }
        //        clearText = Convert.ToBase64String(ms.ToArray());
        //    }
        //}

        return clearText;

    }
    static string Decrypt(string cipherText)
    {
        //string EncryptionKey = "MAKV2SPBNI99212";
        //byte[] cipherBytes = Convert.FromBase64String(cipherText);
        //using (Aes encryptor = Aes.Create())
        //{
        //    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //    encryptor.Key = pdb.GetBytes(32);
        //    encryptor.IV = pdb.GetBytes(16);
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
        //        {
        //            cs.Write(cipherBytes, 0, cipherBytes.Length);
        //            cs.Close();
        //        }
        //        cipherText = Encoding.Unicode.GetString(ms.ToArray());
        //    }
        //}
        return cipherText;
    }
}

public class Level
{
    public int Points { get; set; }
    public int Unlock3StarsPoints { get; set; }
    public int UnlockedStars { get; set; }
    public int isEncrypted { get; set; }
    
    public Level(string _points, string _unlock3StarsPoints, string _unlockedStars, string _isEncrypted)
    {
        string[] pointsInfo = _points.Split(':');
        Points = Convert.ToInt32(pointsInfo[1]);

        string[] unlock3StarsInfo = _unlock3StarsPoints.Split(':');
        Unlock3StarsPoints = Convert.ToInt32(unlock3StarsInfo[1]);

        string[] unlockedStarsInfo = _unlockedStars.Split(':');
        UnlockedStars = Convert.ToInt32(unlockedStarsInfo[1]);

        string[] isEncryptedInfo = _isEncrypted.Split(':');
        isEncrypted = Convert.ToInt32(isEncryptedInfo[1]);

    }
}