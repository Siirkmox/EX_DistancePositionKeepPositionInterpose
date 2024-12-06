
using UnityEngine;
namespace Steerings
{
    public class KeepDistance : SteeringBehaviour
    {

        public RotationalPolicy rotationalPolicy = RotationalPolicy.LWYGI;
        public GameObject target;
        public float requiredDistance;
       

        public override SteeringOutput GetSteering()
        {
            if (this.ownKS == null) this.ownKS = GetComponent<KinematicState>();

            SteeringOutput result = KeepDistance.GetSteering(this.ownKS, this.target, this.requiredDistance);

            base.applyRotationalPolicy(rotationalPolicy, result, target);

            return result;
        }

        public static SteeringOutput GetSteering(KinematicState _ownKS, GameObject _target, float _requiredDistance)
        {
           Vector3 directionFromTarget = _ownKS.transform.position - _target.transform.position;

            directionFromTarget.Normalize();

            Vector3 _requiredPosition = _target.transform.position + directionFromTarget * _requiredDistance;

            SURROGATE_TARGET.transform.position = _requiredPosition;

            return Arrive.GetSteering(_ownKS, SURROGATE_TARGET);
        }
    }

}
