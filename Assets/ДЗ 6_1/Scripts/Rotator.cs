using UnityEngine;

namespace Delegates.Events
{
    public class Rotator
    {
        public void RotateTo(Vector3 direction, float rotationSpeed, Transform owner)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction.normalized);
            float step = rotationSpeed * Time.deltaTime;

            owner.rotation = Quaternion.RotateTowards(owner.rotation, lookRotation, step);
        }
    }
}
