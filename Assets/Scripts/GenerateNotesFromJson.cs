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
    public GameObject myPrefab;

    public GameObject newobj;
    
    // Start is called before the first frame update
    private void Start ()
    {
        filePath = Directory.GetCurrentDirectory();

        filePath += @"\Assets\Sounds\test.json";
        Debug.Log(filePath);
        Debug.Log("p");
        var jsonContents = File.ReadAllText(filePath);
        var mainData = JsonUtility.FromJson<MainData>(jsonContents);
        Debug.Log("name: " + mainData.name);
        Debug.Log("maxBlock: " + mainData.maxBlock);
        Debug.Log("BPM: " + mainData.BPM);
        Debug.Log("offset: " + mainData.offset);
        Debug.Log("LPB: " + mainData.notes[0].LPB);
        Debug.Log("Amount of Notes: " + mainData.notes.Count);
        foreach (var note in mainData.notes)
        {
            double block = note.block;
            Debug.Log("Note: " + note.num);
            Debug.Log("Block: " + note.block);
            block = block switch
            {
                1 => -3.6,
                2 => -1.2,
                3 => 1.2,
                4 => 3.6,
                _ => 1.2
            };
            // no way this works
            var newobj = Instantiate (myPrefab, 
                new Vector3 ((float) block, (float) 0.1, (float) note.num),
                Quaternion.identity);
        }
    }
}