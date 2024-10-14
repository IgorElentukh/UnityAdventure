using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController
{
    private Camera _mainCamera;

    private List<Rigidbody> _rigidbodies = new List<Rigidbody>();

    public WindController()
    {
        _mainCamera = Camera.main;
    }

    public void WindBlow(Vector3 windDirection, float windSpeed, float windAreaRadius, float windEffect)
    {   
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        Vector3 worldCenter = _mainCamera.ScreenToWorldPoint(new Vector3 (screenCenter.x, screenCenter.y, _mainCamera.nearClipPlane));

        Collider[] colliders = Physics.OverlapSphere(worldCenter, windAreaRadius);

        foreach(Collider collider in colliders)
        {
            Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

            if(rigidbody != null && _rigidbodies.Contains(rigidbody) == false)
                _rigidbodies.Add(rigidbody);
        }

        foreach(Rigidbody rigidbody in _rigidbodies)
        {
            rigidbody.AddForce(windDirection.normalized * windSpeed * windEffect * Time.deltaTime, ForceMode.Acceleration);
        }
    }

    
}
