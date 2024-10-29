using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _timer;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _damage;
    [SerializeField] private LayerMask _obstacleMask;

    [SerializeField] private ParticleSystem _explosionEffect;

    private AudioHandler _audioHandler;
    private Transform _damageableTarget;


    private bool _isDamageableInRange = false;
    private bool _isDamageableVisible = false;

    public void Initialize(AudioHandler audioHandler)
    {
        _audioHandler = audioHandler;
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            _isDamageableInRange = true;
            _damageableTarget = other.transform;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_damageableTarget == null)
            return;

        CheckVisibility();
    }

    private void Update()
    {
        if (_isDamageableInRange == false || _isDamageableVisible == false)
            return;

        _timer -= Time.deltaTime;

        if(_timer <= 0)
            Explode();
    }

    private void Explode()
    {
        Instantiate(_explosionEffect, transform.position, Quaternion.identity);
        _audioHandler.PlaySound(1);
        
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

    private void CheckVisibility()
    {
        Vector3 directionToTarget = (_damageableTarget.position - transform.position).normalized;
        float distanceToTarget = Vector3.Distance(transform.position, _damageableTarget.position);

        if (Physics.Raycast(transform.position, directionToTarget, distanceToTarget, _obstacleMask) == false)
            _isDamageableVisible = true;
        else
            _isDamageableVisible = false;

        Debug.DrawRay(transform.position, directionToTarget, Color.green, distanceToTarget);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
}
