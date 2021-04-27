using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Serialization;

[Serializable]
public class MainData
{
    public string name;
    public int maxBlock;
    public int BPM;
    public int offset;
    public List<Note> notes;
}

[Serializable]

public class Note
{
    public int LPB;
    public int num;
    public int block;
    public int type;
    public List<Note> notes;
}
public class GenerateNotesFromJson: MonoBehaviour
{
    [FormerlySerializedAs("FilePath")] public string filePath;
    // Start is called before the first frame update
    void Start ()
    {
        Debug.Log("HHUH");
        filePath = Directory.GetCurrentDirectory();

        filePath += @"\Assets\Sounds\test.json";
        Debug.Log(filePath);
        Debug.Log("p");
        string json_contents = File.ReadAllText(filePath);
        MainData fumen = JsonUtility.FromJson<MainData>(json_contents);
        Debug.Log("peee");
        Debug.Log("name: " + fumen.name);
        Debug.Log("maxBlock: " + fumen.maxBlock);
        Debug.Log("BPM: " + fumen.BPM);
        Debug.Log("offset: " + fumen.offset);
        Debug.Log("LPB: " + fumen.notes[0].LPB);
    }
}