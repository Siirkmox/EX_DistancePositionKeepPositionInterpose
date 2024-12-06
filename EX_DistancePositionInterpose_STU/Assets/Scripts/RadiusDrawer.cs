
using UnityEngine;

public class RadiusDrawer : MonoBehaviour {

   
    public float radius_1, radius_2;
    private Vector3 up = new Vector3(0, 0, 1);
	
	// Update is called once per frame
	void Update () {
        DebugExtension.DebugCircle(transform.position, up, Color.blue, radius_1);
        DebugExtension.DebugCircle(transform.position, up, Color.red, radius_2);
    }
}
