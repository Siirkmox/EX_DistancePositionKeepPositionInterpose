using UnityEngine;

public class GoToClick : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 click = Input.mousePosition;
            Vector3 wantedPosition = Camera.main.ScreenToWorldPoint(new Vector3(click.x, click.y, 1f));
            wantedPosition.z = transform.position.z;
            transform.position = wantedPosition;
        }
	}
}
