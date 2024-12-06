using UnityEngine;
namespace Steerings
{
    public class KeepPosition : SteeringBehaviour
    {

        public RotationalPolicy rotationalPolicy = RotationalPolicy.LWYGI;
        public GameObject target;
        public float requiredDistance;
        public float requiredAngle;


        public override SteeringOutput GetSteering()
        {
            if (this.ownKS == null) this.ownKS = GetComponent<KinematicState>();

            SteeringOutput result = KeepPosition.GetSteering(this.ownKS, this.target, this.requiredDistance, this.requiredAngle);

            base.applyRotationalPolicy(rotationalPolicy, result, target);

            return result;
        }

        public static SteeringOutput GetSteering(KinematicState _ownKS, GameObject _target, float _distance, float _angle)
        {
            // Calculate the direction from the target to the current position
            Vector3 directionFromTarget = Quaternion.Euler(0, 0, _angle) * Vector3.right;

            // Calculate the desired position based on the distance and angle
            Vector3 requiredPosition = _target.transform.position + directionFromTarget * _distance;

            // Use the surrogate target to represent the desired position
            SURROGATE_TARGET.transform.position = requiredPosition;

            // Use the Arrive behavior to get the steering output
            return Arrive.GetSteering(_ownKS, SURROGATE_TARGET);
        }
    }

}
