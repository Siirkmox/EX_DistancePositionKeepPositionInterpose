using System;
using UnityEngine;
using Steerings;

public class SliderListener : MonoBehaviour {

    private KinematicState ks;

    public void Awake()
    { 
        ks = GetComponent<KinematicState>();
    }

    public void AcceptInput(float userInput)
    {
        Debug.Log("alter me " + userInput);
        ks.maxAcceleration = userInput;
    }
}
