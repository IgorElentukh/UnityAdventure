using UnityEngine;

public class SpeedLoot : Loot
{
    [SerializeField] private float _minValue;
    [SerializeField] private float _maxValue;

    private float _value;

    private void Awake()
    {
        _value = Random.Range(_minValue, _maxValue);
    }

    public override void Use(GameObject owner)
    {
        PlayerController2 controller = owner.GetComponentInChildren<PlayerController2>();

        if(controller != null)
            controller.MoveSpeed += _value;

        base.Use(owner);
    }
}
