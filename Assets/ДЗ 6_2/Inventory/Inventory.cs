using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Inventory.Refactoring
{
    public class Inventory
    {
        private List<Item> _items = new();
        public int CurrentSize => _items.Count;

        public int MaxSize;

        public Inventory(List<Item> items, int maxSize)
        {
            _items = items;
            MaxSize = maxSize;
        }

        public void Add(Item item)
        {
            if (CurrentSize >= MaxSize)
                throw new ArgumentOutOfRangeException();

            _items.Add(item);
        }

        public List<Item> GetItemsBy(int id, int count)
        {
            List<Item> itemsWithId = _items.Where(item => item.Id == id).ToList();

            if (itemsWithId.Count < count)
                throw new ArgumentOutOfRangeException();

            List<Item> itemsToRetrieve = itemsWithId.Take(count).ToList();

            foreach (var item in itemsToRetrieve)
                _items.Remove(item);

            return itemsToRetrieve;
        }

        public IReadOnlyList<Item> GetAllItems()
        {
            return _items.AsReadOnly();
        }
    }

    public class Item
    {
        public int Id { get; private set; }

        public Item(int id)
        {
            Id = id;
        }
    }
}
