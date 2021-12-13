using UnityEngine;

namespace Shop
{
    public class Item
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