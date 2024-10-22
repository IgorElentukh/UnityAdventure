using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _timer;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _damage;

    [SerializeField] private ParticleSystem _explosionEffect;

    private bool _isPlayerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
            _isPlayerInRange = true;

    }

    private void Update()
    {   
        if (_isPlayerInRange == false)
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
            Player player = collider.GetComponent<Player>();

            if(player != null)
            {
                player.Health.TakeDamage(_damage);

                if (player.Health.CurrentHealth <= HealthComponent.MaxHealth * Player.LimitForInjuredLayer)
                    player.View.SwitchInjuredLayer();

                if(player.Health.CurrentHealth <= 0)
                    player.View.Die();
                else
                    player.View.GetHit();

                Debug.Log(player.Health.CurrentHealth);
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
