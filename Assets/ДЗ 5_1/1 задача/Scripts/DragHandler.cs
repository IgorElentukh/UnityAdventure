using UnityEngine;

public class DragHandler
{
    private GameObject _selectedObject;
    private Camera _mainCamera;
    private int _notInteractableLayer;

    public DragHandler(int notInteractablelayer)
    {
        _mainCamera = Camera.main;
        _notInteractableLayer = notInteractablelayer;
    }

    public void Drag(Vector3 rayPoint, Vector3 targetPosition)
    {
        Ray ray = _mainCamera.ScreenPointToRay(rayPoint);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            IGrabble grabble = hitInfo.collider.GetComponent<IGrabble>();

            if (grabble != null)
            {
                grabble.OnGrab();

                _selectedObject = hitInfo.collider.gameObject;

                if (_selectedObject.layer == _notInteractableLayer)
                    return;

                _selectedObject.transform.position = new Vector3(targetPosition.x, _selectedObject.transform.position.y, _selectedObject.transform.position.z);
            }
        }
    } 
}
