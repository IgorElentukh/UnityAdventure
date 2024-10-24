using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent
{
    public const float MaxHealth = 100;

    public float CurrentHealth { get; private set; }

    public HealthComponent()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage <= 0)
            return;

        CurrentHealth -= damage;

        if(CurrentHealth <= 0)
        {
            CurrentHealth = 0;
        }
    }

}
