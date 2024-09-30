using UnityEngine;

public class HealthLoot : Loot
{
    [SerializeField] private float _value;

    public override void Use(GameObject owner)
    {
        PlayerController2 controller = owner.GetComponentInChildren<PlayerController2>();

        if (controller != null)
            controller.Health += _value;

        base.Use(owner);
    }
}
