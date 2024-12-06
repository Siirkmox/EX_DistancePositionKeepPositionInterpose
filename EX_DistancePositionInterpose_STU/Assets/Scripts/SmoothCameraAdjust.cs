using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraAdjust : MonoBehaviour {

    public GameObject target;
    public float speed = 10f;
    public float threshold1 = 200;
    public float threshold2 = 50;
    public enum States {RESTING, MOVING};
    public States state = States.RESTING;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 directionToTarget = target.transform.position - transform.position;
        
        float distance = directionToTarget.magnitude;
        switch (state)
        {
            case States.RESTING:
                if (distance > threshold1) state = States.MOVING;
                break;
            case States.MOVING:
                if (distance < threshold2) state = States.RESTING;
                else transform.position += (Vector3)directionToTarget.normalized * speed * Time.deltaTime;
                break;
        }
	}
}
