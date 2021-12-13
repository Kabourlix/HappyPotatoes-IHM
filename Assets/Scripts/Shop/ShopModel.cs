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

         private int[] startCatIndex = {0,3,4,5 }; // This give me the starting index of each category.
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

         public int GetItemIndexByPosition(int cat, int pos)
         {
             return startCatIndex[cat] + pos;
         }

         public int GetPrice(int itemIndex)
         {
             return items[itemIndex].Price;
         }

         public String GetName(int itemIndex)
         {
             return items[itemIndex].Name;
         }
        //

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

        
        private void Start()
        {
            
            
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

        public void SpawnBoughtItem(int itemIndex)
        {
            Item i = items[itemIndex];
            print("The index is " + itemIndex);
            print("Elements in items : " + items.Length);
            print("The selected item = " + items[itemIndex]);
            bool b = items[itemIndex].Prefab == null; //true
            print("The prefab is  = " + b.ToString() );
            //Transform parent = spawnPosition.transform;
            //Instantiate(o, parent.position + Vector3.down*2, Quaternion.identity,parent);
            Instantiate(i.Prefab, Vector3.forward, Quaternion.identity);
        }
        
        
        
        
    }
}
