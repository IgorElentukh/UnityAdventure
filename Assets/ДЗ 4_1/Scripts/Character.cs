using UnityEngine;

namespace Inventory2
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Transform _lootHolderPoint;
        [SerializeField] private LootCollector _collector;

        private LootHandler _lootHandler;

        private void Awake()
        {
            Inventory inventory = new Inventory(_lootHolderPoint);

            _collector.Initialize(inventory);
            _lootHandler = new LootHandler(inventory, gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
                if (_lootHandler.CanUseLoot())
                    _lootHandler.UseLoot();
        }
    }
}
