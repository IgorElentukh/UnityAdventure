using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _timer;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _damage;

    [SerializeField] private ParticleSystem _explosionEffect;

    private bool _isDamageableInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
            _isDamageableInRange = true;

    }

    private void Update()
    {   
        if (_isDamageableInRange == false)
            return;

        _timer -= Time.deltaTime;

        if(_timer <= 0)
            Explode();
    }

    private void Explode()
    {
        Instantiate(_explosionEffect, transform.position, Quaternion.identity);
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider collider in colliders)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();

            if(damageable != null)
            {
                damageable.TakeDamage(_damage);
            }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
}
