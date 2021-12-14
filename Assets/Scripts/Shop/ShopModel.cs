using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

namespace Shop
{
    public class ShopModel : MonoBehaviour
    {
        // Data in the shop, we store it here since it's tiny data
        [SerializeField] private GameObject[] prefabList;
        //[SerializeField] private GameObject spawnPosition;
        private readonly Item[] items = 
        {
            new Item(0,"tree","path",15),
            new Item(0, "potatoes", "path", 3),
            new Item(0, "strawberries", "path", 8),
            
            new Item(1, "beeHive", "path", 200),
            
            new Item(2, "greenHouse", "path", 800),
            
            new Item(3, "shovel", "path", 60),
            new Item(3,"wateringCan","path",80)
        }; // TODO : Make it editable in the editor directly.

        public Item GetItemByPosition(int category, int position)
         {
             List<Item> categoryList = LoadItemFromCategory(category);
             return categoryList[position];
         }

         public int ModeActive { get; set; }

        public static ShopModel Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }

            Instance = this;
            // We set up all the prefabs.
            for (int j = 0; j < items.Length; j++)
            {
                print(j);
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

       
        
        
        
        
    }
}
