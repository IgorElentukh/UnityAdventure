using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates.Events
{
    public class Bullet : MonoBehaviour
    {
        private int _damage;

        public void Launch(float shootForce, Vector3 direction, int damage)
        {
            _damage = damage;
            GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.Impulse);
            Destroy(gameObject, 3);
        }

        private void OnCollisionEnter(Collision collision)
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

            if(damageable != null && damageable is Enemy) // хотел через дженерик сделать, но какие-то ошибки при создании пуль
            {
                damageable.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}
