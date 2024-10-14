using UnityEngine;

public class MouseExplosionHandler
{
    private const int RightMouseButton = 1;

    private float _explosionRadius;
    private float _explosionForce;
    private float _upwardsModifier;

    private Camera _mainCamera;
    private ParticleSystem _explosionEffect;

    public MouseExplosionHandler(float explosionRadius, float explosionForce, float upwardsModifier, ParticleSystem explosionEffect)
    {
        _explosionRadius = explosionRadius;
        _explosionForce = explosionForce;
        _mainCamera = Camera.main;
        _upwardsModifier = upwardsModifier;
        _explosionEffect = explosionEffect;
    }

    public void CheckExplosion()
    {
        if(Input.GetMouseButtonDown(RightMouseButton))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hitinfo))
            {
                CreateExplosion(hitinfo.point);
            }
        }  
    }

    private void CreateExplosion(Vector3 explosionPosition)
    {
        MonoBehaviour.Instantiate(_explosionEffect, explosionPosition, Quaternion.identity);

        Collider[] colliders = Physics.OverlapSphere(explosionPosition, _explosionRadius);

        foreach(Collider collider in colliders)
        {
            Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

            if (rigidbody != null)
                rigidbody.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius, _upwardsModifier, ForceMode.Impulse);
            
        }
    }
}
