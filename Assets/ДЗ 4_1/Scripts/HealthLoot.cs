using UnityEngine;

public class HealthLoot : Loot
{
    [SerializeField] private float _value;

    public override void Use(GameObject owner)
    {
        Health health = owner.GetComponentInChildren<Health>();

        if (health != null)
            health.HealthValue += _value;

        base.Use(owner);
    }
}
