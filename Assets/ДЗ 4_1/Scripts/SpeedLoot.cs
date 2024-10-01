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
        Mover3 mover = owner.GetComponentInChildren<Mover3>();

        if (mover != null)
            mover.MoveSpeed += _value;

        base.Use(owner);
    }
}
