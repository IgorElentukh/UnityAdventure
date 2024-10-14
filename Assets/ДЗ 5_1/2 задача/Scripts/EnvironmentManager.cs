using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnvironmentManager : MonoBehaviour
{
    [SerializeField] private float _windAreaRadius;
    [SerializeField] private Image _windDirectionImage;
    [SerializeField] private Ship _ship;
    [SerializeField] private TMP_Text _velocityText;

    private WindController _windController;
    private Visualizator _visualizator;

    private float _windEffect;

    [field: SerializeField] public Vector3 WindDirection { get; private set; }
    [field: SerializeField] public float WindSpeed { get; private set; }

    private void Awake()
    {
        _windController = new WindController();
        _visualizator = new Visualizator(_windDirectionImage, _velocityText);
    }

    private void Update()
    {
        _visualizator.ShowDirection(WindDirection);
        _visualizator.ShowVelocity(_ship.Rigidbody.velocity.magnitude);

        _windEffect = CalculateWindEffect();

        Debug.Log(_windEffect);
        
        if (Input.GetKey(KeyCode.Space))
        {
            _windController.WindBlow(WindDirection, WindSpeed, _windAreaRadius, _windEffect);
        }
    }

    public float CalculateWindEffect()
    {
        Vector3 sailNormal = _ship.SailTransform.forward.normalized;
        Vector3 shipForward = _ship.transform.forward;

        float effectOnSail = Mathf.Abs(Vector3.Dot(WindDirection.normalized, sailNormal));
        float effectOnShip = Mathf.Abs(Vector3.Dot(WindDirection.normalized, shipForward));

        Debug.Log(effectOnSail);
        Debug.Log(effectOnShip);

        float windEffect = effectOnSail * effectOnShip;

        return windEffect;
    }
}
