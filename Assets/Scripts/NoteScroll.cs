using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroll : MonoBehaviour
{
    public float beatTempo;
    public float offset;
    public bool hasStarted;

    public GameObject greenPrefab;
    public GameObject redPrefab;
    public GameObject bluePrefab;
    public GameObject orangePrefab;

    public OptionsMenu options;
    public int speedSetting = 2;
    public bool spawnFlag = false;

    public TextAsset textJSON;

    [System.Serializable]
    public class Track
    {
        public string name;
        public float BPM;
        public float offset;
    }

    public Track myTrack = new Track();

    [System.Serializable]
    public class Notes
    {
        public int num;
        public int block;
        public int type;
    }

    [System.Serializable]
    public class NotesList
    {
        public Notes[] notes;
    }

    public NotesList myNotesList = new NotesList();

    // PARENT
    public GameObject NoteHolder;
    // Start is called before the first frame update
    void Start()
    {
        myTrack = JsonUtility.FromJson<Track>(textJSON.text);

        beatTempo = myTrack.BPM / 60f;
        offset = myTrack.offset / 10000;
        myNotesList = JsonUtility.FromJson<NotesList>(textJSON.text);
    }

    private void SpawnNotes(int var)
    {
        for (int i = 0; i < myNotesList.notes.Length; i++)
        {
            if (myNotesList.notes[i].block == 0)
            {
                GameObject temp = Instantiate(greenPrefab, new Vector3((float)-1.8, 0.1f, (float)myNotesList.notes[i].num / (4 / var) + var * offset), transform.rotation);
                temp.transform.SetParent(NoteHolder.transform);
            } else if (myNotesList.notes[i].block == 1)
            {
                GameObject temp = Instantiate(redPrefab, new Vector3((float)-0.6, 0.1f, (float)myNotesList.notes[i].num / (4 / var) + var * offset), transform.rotation);
                temp.transform.SetParent(NoteHolder.transform);
            } else if (myNotesList.notes[i].block == 2)
            {
                GameObject temp = Instantiate(bluePrefab, new Vector3((float)0.6, 0.1f, (float)myNotesList.notes[i].num / (4 / var) + var * offset), transform.rotation);
                temp.transform.SetParent(NoteHolder.transform);
            } else if (myNotesList.notes[i].block == 3)
            {
                GameObject temp = Instantiate(orangePrefab, new Vector3((float)1.8, 0.1f, (float)myNotesList.notes[i].num / (4 / var) + var * offset), transform.rotation);
                temp.transform.SetParent(NoteHolder.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawnFlag)
        {
            SpawnNotes(options.scrollSpeed);
            spawnFlag = true;
        }
        if (!hasStarted)
        {
            if(Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        else
        {
            transform.position -= new Vector3(0f, 0f, options.scrollSpeed * beatTempo * Time.deltaTime);
        }
    }
}
