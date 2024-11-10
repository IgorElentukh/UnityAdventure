using UnityEngine;

namespace Delegates.Events
{
    public class Mover
    {
        private float _deadZone = 0.1f;

        public void MoveTo(Vector3 direction, float movementSpeed, CharacterController characterController)
        {
            if (direction.magnitude < _deadZone)
                return;

            characterController.Move(direction.normalized * movementSpeed * Time.deltaTime);
        }
    }
}
