
using UnityEngine;

namespace Steerings
{
    public class Interpose : SteeringBehaviour
    {

        public RotationalPolicy rotationalPolicy = RotationalPolicy.LWYGI;
        public GameObject target1;
        public GameObject target2;

        public override SteeringOutput GetSteering()
        {
            if (this.ownKS == null) this.ownKS = GetComponent<KinematicState>();

            SteeringOutput result = Interpose.GetSteering(this.ownKS, this.target1, this.target2);

            base.applyRotationalPolicy(rotationalPolicy, result, target1);

            return result;
        }

        public static SteeringOutput GetSteering(KinematicState _ownKS, GameObject _target1, GameObject _target2)
        {
            // Calculate the midpoint between the two targets
            Vector3 midpoint = (_target1.transform.position + _target2.transform.position) / 2;

            // Use the surrogate target to represent the midpoint
            SURROGATE_TARGET.transform.position = midpoint;

            // Use the Arrive behavior to get the steering output
            return Arrive.GetSteering(_ownKS, SURROGATE_TARGET);
        }
    }
}
