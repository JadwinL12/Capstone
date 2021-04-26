using UnityEngine;

public class TapButton : MonoBehaviour
{
    public MeshRenderer mR;
    public Material colorNotTapped;
    public Material colorTapped;
    public float tapped = 0.07f;
    public float unTapped = -0.07f;

    public KeyCode keyMap;

    public AudioSource audioSource;
    public AudioClip clip;

    void Start ()
    {
        mR = GetComponent<MeshRenderer>();
    }

    void Update ()
    {
        if(Input.GetKeyDown(keyMap))
        {
            mR.material = colorTapped;
            var transform1 = transform;
            var position = transform1.position;
            position = new Vector3(position.x, tapped, position.z);
            transform1.position = position;
            audioSource.PlayOneShot(clip);
            Debug.Log("I PRESSED");
        }

        if(Input.GetKeyUp(keyMap))
        {
            mR.material = colorNotTapped;
            var transform1 = transform;
            var position = transform1.position;
            position = new Vector3(position.x, unTapped, position.z);
            transform1.position = position;
        }
    }

}
