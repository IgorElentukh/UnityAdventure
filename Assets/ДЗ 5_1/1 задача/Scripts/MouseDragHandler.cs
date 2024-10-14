using UnityEngine;

public class MouseDragHandler
{
    private const int LeftMouseKey = 0;

    private GameObject _selectedObject;
    private Camera _mainCamera;
    private int _notInteractableLayer;

    public MouseDragHandler(int notInteractablelayer)
    {
        _mainCamera = Camera.main;
        _notInteractableLayer = notInteractablelayer;
    }

    public void Drag()
    {
        if(Input.GetMouseButton(LeftMouseKey))
        { 
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                _selectedObject = hitInfo.collider.gameObject;

                if (_selectedObject.layer == _notInteractableLayer)
                    return;

                Vector3 mousePositionInWorld = GetMousePosition();
                _selectedObject.transform.position = new Vector3(mousePositionInWorld.x, _selectedObject.transform.position.y,                                                                                         mousePositionInWorld.z);
            }
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition.z = _mainCamera.WorldToScreenPoint(_selectedObject.transform.position).z;

        return _mainCamera.ScreenToWorldPoint(mousePosition);
    }
}
