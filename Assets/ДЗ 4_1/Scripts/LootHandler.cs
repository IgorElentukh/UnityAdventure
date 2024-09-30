using UnityEngine;

public class LootHandler
{
    private Inventory _inventory;
    private GameObject _owner;

    public LootHandler(Inventory inventory, GameObject owner)
    {
        _inventory = inventory;
        _owner = owner;
    }

    public bool CanUseLoot() => _inventory.HasLoot();

    public void UseLoot()
    {
        if(CanUseLoot() == false)
        {
            Debug.LogError("Не могу использовать");
            return;
        }

        Loot loot = _inventory.GetLoot();
        loot.Use(_owner);
        Object.Destroy(loot.gameObject);
    }
}
