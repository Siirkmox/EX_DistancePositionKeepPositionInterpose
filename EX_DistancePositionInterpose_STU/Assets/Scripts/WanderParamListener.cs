
using UnityEngine;
using Steerings;

public class WanderParamListener : MonoBehaviour {

    private Wander wander;

    void Awake ()
    {
        wander = GetComponent<Wander>();
    }

    public void onWanderRateChanged (float wr)
    {
        wander.wanderRate = wr;
    }

    public void onWanderRadiusChanged(float wr)
    {
        wander.wanderRadius = wr;
    }

    public void onWanderOffsetChanged(float wo)
    {
        wander.wanderOffset = wo;
    }


}
