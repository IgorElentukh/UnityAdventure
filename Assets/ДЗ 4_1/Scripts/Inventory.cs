using UnityEngine;

public class Inventory
{
    [SerializeField] private Transform _lootPoint;

    private Loot _loot;

    public Inventory(Transform lootPoint)
    {
        _lootPoint = lootPoint;
    }

    public bool HasLoot() => _loot != null;

    public Loot GetLoot()
    {
        if (HasLoot() == false)
        {
            Debug.LogError("Нет предмета!");
            return null;
        }
        
        _loot.transform.SetParent(null);
        Loot selectedLoot = _loot;
        _loot = null;
        return selectedLoot;
    }

    public void PlaceLoot(Loot loot)
    {
        if (HasLoot())
        {
            Debug.LogError("Уже есть предмет.");
            return;
        }

        _loot = loot;
        _loot.transform.SetParent(_lootPoint);
        _loot.transform.position = _lootPoint.position;
    }
}
