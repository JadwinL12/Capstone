using UnityEngine;

public class TapButton : MonoBehaviour
{
    public MeshRenderer mR;
    public Material colorNotTapped;
    public Material colorTapped;
    public float tapped = 0.07f;
    public float unTapped = -0.07f;

    void OnMouseDown()
    {
        mR.material = colorTapped;
        transform.position = new Vector3(transform.position.x, tapped, transform.position.z);
    }

    private void OnMouseUp()
    {
        mR.material = colorNotTapped;
        transform.position = new Vector3(transform.position.x, unTapped, transform.position.z);
    }

}
