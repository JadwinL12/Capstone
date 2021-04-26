using UnityEngine;

public class TapButton : MonoBehaviour
{
    public MeshRenderer mR;
    public Material colorNotTapped;
    public Material colorTapped;
    public float tapped = 0.07f;
    public float unTapped = -0.07f;

    public KeyCode keyMap;

    void Start ()
    {
        mR = GetComponent<MeshRenderer>();
    }

    void Update ()
    {
        if(Input.GetKeyDown(keyMap))
        {
            mR.material = colorTapped;
            transform.position = new Vector3(transform.position.x, tapped, transform.position.z);
        }

        if(Input.GetKeyUp(keyMap))
        {
            mR.material = colorNotTapped;
            transform.position = new Vector3(transform.position.x, unTapped, transform.position.z);
        }
    }

}
