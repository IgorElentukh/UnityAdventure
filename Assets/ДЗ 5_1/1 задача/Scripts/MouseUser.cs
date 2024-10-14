using UnityEngine;

public class MouseUser : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _upwardsModifier;
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private string _notInteractableLayer; // не нашел способа как передать числовое значение для сравнения в MouseDragHandler
    
    private MouseDragHandler _dragHandler;
    private MouseExplosionHandler _explosionHandler;

    private void Awake()
    {
        _dragHandler = new MouseDragHandler(LayerMask.NameToLayer(_notInteractableLayer));
        _explosionHandler = new MouseExplosionHandler(_explosionRadius, _explosionForce, _upwardsModifier, _explosionEffect);
    }

    private void Update()
    {
        _dragHandler.Drag();
        _explosionHandler.CheckExplosion();
    }
}
