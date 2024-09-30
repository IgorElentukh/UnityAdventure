using UnityEngine;

public class LootCollector : MonoBehaviour
{
    private Inventory _inventory;

    public void Initialize(Inventory inventory)
    {
        _inventory = inventory;
    }

    private void OnTriggerEnter(Collider other)
    {
        Loot loot = other.GetComponent<Loot>();

        if (loot == null)
            return;

        if(_inventory.HasLoot() == false)
            _inventory.PlaceLoot(loot);
    }

}
