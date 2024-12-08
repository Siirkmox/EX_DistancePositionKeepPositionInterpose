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
            // get the target's orientation (as an angle)...
            float targetOrientation = _target.transform.rotation.eulerAngles.z;

            // ... add the required angle
            float requiredOrientation = targetOrientation + _angle;

            // convert the orientation into a direction (convert from angle to vector)
            Vector3 requiredDirection = Utils.OrientationToVector(requiredOrientation).normalized;

            // determine required position
            Vector3 requiredPosition = _target.transform.position + requiredDirection * _distance;

            // place surrogate target in required position
            SURROGATE_TARGET.transform.position = requiredPosition;

            //return Seek.GetSteering(me, SURROGATE_TARGET);
            return Arrive.GetSteering(_ownKS, SURROGATE_TARGET, 0, 5);
        }
    }

}
