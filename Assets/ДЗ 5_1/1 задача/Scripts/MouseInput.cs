using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _upwardsModifier;
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private string _notInteractableLayer; // не нашел способа как передать числовое значение для сравнения в MouseDragHandler

    private const int LeftMouseKey = 0;

    private DragHandler _dragHandler;
    private MouseExplosionHandler _explosionHandler;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;

        _dragHandler = new DragHandler(LayerMask.NameToLayer(_notInteractableLayer));
        _explosionHandler = new MouseExplosionHandler(_explosionRadius, _explosionForce, _upwardsModifier, _explosionEffect);
    }

    private void Update()
    {
        if (Input.GetMouseButton(LeftMouseKey))
            _dragHandler.Drag(Input.mousePosition, GetMousePosition());


        _explosionHandler.CheckExplosion();
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;

        //mousePosition.z = _mainCamera.WorldToScreenPoint(_selectedObject.transform.position).z;

        return _mainCamera.ScreenToWorldPoint(mousePosition);
    }
}
