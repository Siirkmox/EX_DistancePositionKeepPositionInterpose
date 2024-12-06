using UnityEngine;
using Steerings;

public class MemorizeInitialPosition : MonoBehaviour {

    private Vector3 initialPosition;
    private float initialOrientation;

	// Use this for initialization
	void Awake () {
        initialPosition = transform.position;
        initialOrientation = transform.eulerAngles.z;
	}
	
	public void RePosition ()
    {
        transform.position = initialPosition;
        KinematicState ks = GetComponent<KinematicState>();
        ks.position = initialPosition;
        ks.orientation = initialOrientation;
        transform.rotation = Quaternion.Euler(0, 0, initialOrientation);
    }

     public void onClick()
    {
        // search all repositionable gameObjects and move them back to their initial positions
        foreach (MemorizeInitialPosition gm in Object.FindObjectsOfType<MemorizeInitialPosition>() )
        {
            gm.RePosition();       
        }
        
    }
}
