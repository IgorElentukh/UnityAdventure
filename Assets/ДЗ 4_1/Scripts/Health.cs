using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;

    public float HealthValue
    {
        get => _health;

        set
        {
            if (value > 0)
                _health = value;

            if (value < 0)
                Debug.Log("Я умер.");
        }
    }


}
