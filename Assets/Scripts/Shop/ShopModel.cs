using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

namespace Shop
{
    public class ShopModel : MonoBehaviour
    {
        // Data in the shop, we store it here since it's tiny data
        [SerializeField] private GameObject[] prefabList;
        [SerializeField] private GameObject spawnPosition;
         private Item[] items =
        {
            new Item(0,"tree","path",15),
            new Item(0, "potatoes", "path", 3),
            new Item(0, "strawberries", "path", 8),
            
            new Item(1, "beeHive", "path", 200),
            
            new Item(2, "greenHouse", "path", 800),
            
            new Item(3, "shovel", "path", 60),
            new Item(3,"wateringCan","path",80)
        }; // TODO : Make it editable in the editor directly.

         public Item GetItemByName(String name)
         {
             foreach (Item i in items)
             {
                 if (i.Name.Equals(name)) return i;
             }

             return new Item(-1,"undefined","path",-5); // We return a senseless item.
         }

         public Item GetItemByPosition(int category, int position)
         {
             List<Item> categoryList = LoadItemFromCategory(category);
             return categoryList[position];
         }
        //

        public int ModeActive { get; set; }

        public static ShopModel Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null & Instance != this)
            {
                Destroy(gameObject);
            }

            Instance = this;
        }

        private void Start()
        {
            // We set up all the prefabs.
            for (int j = 0; j < items.Length; j++)
            {
                items[j].Prefab = prefabList[j];
            }
        }

        private List<Item> LoadItemFromCategory(int category)
        {
            List<Item> toReturn = new List<Item>();
            foreach (Item item in items)
            {
                if(item.Category == category) toReturn.Add(item);
            }

            return toReturn;
        }

        public void SpawnBoughtItem(Item i)
        {
            GameObject o = i.Prefab;
            Transform parent = spawnPosition.transform;
            Instantiate(o, parent.position - Vector3.down*5, Quaternion.identity, parent);
        }
        
        
        
        public struct Item
        {
            public int Category { get; } // 0 Seed, 1 Bee Hive, 2 GreenHouse, 3 Weapons
            public string Name { get; }
            private bool isSellable; // Initially on true 
            public string Path { get; }
            public int Price { get; }

            private GameObject prefab;

            public GameObject Prefab
            {
                get => prefab;
                set => prefab = value;
            }

            public Item(int category, string name,string imgPath, int price)
            {
                this.Category = category;
                this.Name = name;
                isSellable = true;
                Path = imgPath; //! This might causes issue in the future (if the image is not loaded for example)
                this.Price = price;
                prefab = null;
            }
            
        
            public void SetSellable(bool b)
            {
                isSellable = b;
            }
            
        
        }
    }
}
