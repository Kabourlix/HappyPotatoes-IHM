using System;
using UnityEngine;

namespace Shop
{
    public class ShopModel : MonoBehaviour
    {
        // Data in the shop, we store it here since it's tiny data
        
        
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
    }
}
