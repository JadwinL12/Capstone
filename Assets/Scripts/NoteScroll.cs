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
        Debug.Log(myTrack.name);
        Debug.Log(myTrack.BPM);
        Debug.Log(myTrack.offset);
        beatTempo = myTrack.BPM / 60f;
        offset = myTrack.offset / 10000;
        myNotesList = JsonUtility.FromJson<NotesList>(textJSON.text);
        SpawnNotes();
    }

    private void SpawnNotes()
    {
        /* GameObject a = Instantiate(greenPrefab) as GameObject;
        a.transform.position = new Vector3(0f, 0f, myNotesList.notes[i].num); */
        for (int i = 0; i < myNotesList.notes.Length; i++)
        {
            if (myNotesList.notes[i].block == 0)
            {
                GameObject temp = Instantiate(greenPrefab, new Vector3((float)-1.8, 0.1f, (float)myNotesList.notes[i].num / 2 + 2 * offset), transform.rotation);
                temp.transform.SetParent(NoteHolder.transform);
            } else if (myNotesList.notes[i].block == 1)
            {
                GameObject temp = Instantiate(redPrefab, new Vector3((float)-0.6, 0.1f, (float)myNotesList.notes[i].num / 2 + 2 * offset), transform.rotation);
                temp.transform.SetParent(NoteHolder.transform);
            } else if (myNotesList.notes[i].block == 2)
            {
                GameObject temp = Instantiate(bluePrefab, new Vector3((float)0.6, 0.1f, (float)myNotesList.notes[i].num / 2 + 2 * offset), transform.rotation);
                temp.transform.SetParent(NoteHolder.transform);
            } else if (myNotesList.notes[i].block == 3)
            {
                GameObject temp = Instantiate(orangePrefab, new Vector3((float)1.8, 0.1f, (float)myNotesList.notes[i].num / 2 + 2 * offset), transform.rotation);
                temp.transform.SetParent(NoteHolder.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            if(Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        else
        {
            transform.position -= new Vector3(0f, 0f, 2 * beatTempo * Time.deltaTime);
        }
    }
}
