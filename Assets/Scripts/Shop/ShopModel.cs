using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    public class ShopModel : MonoBehaviour
    {
        // Data in the shop, we store it here since it's tiny data
        private List<Item> items;
        private Item seed = new Item("Tree Seed","monChemin","Une petite graine d'un grand arbre du futur.", 10);
        
        //

        public int ModeActive { get; set; }

        public static ShopModel Instance { get; private set; }

        public ShopModel(){} // For users who try to instanciate such function

        private void Awake()
        {
            if (Instance != null & Instance != this)
            {
                Destroy(gameObject);
            }

            Instance = this;
        }
        
        struct Item
        {
            private int id;
            private string Name { get; }
            private bool isSellable; // Initially on true 
            public string Path { get; }
            public string Info { get; }
            public int Price { get; }

            public Item(string name,string imgPath, string info, int price)
            {
                id = Instance.items.Count+1;
                this.Name = name;
                isSellable = true;
                Path = imgPath; //! This might causes issue in the future (if the image is not loaded for example)
                this.Info = info; //Initialisation
                this.Price = price;
            }
        
            public void SetSellable(bool b)
            {
                isSellable = b;
            }
            
        
        }
    }
}
