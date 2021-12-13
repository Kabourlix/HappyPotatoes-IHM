using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Shop
{
    public class ShopUIInteraction : MonoBehaviour
    {
        //UI Objects
        [SerializeField] private Text currencyText;

        private List<GameObject> shopItemList;
        // end
        
        
        
        
        private List<GameObject> children;
        private SettingsManagers manager;
        private ShopModel model;

        private int currentCategory;
        private void Start()
        {
            manager = SettingsManagers.Instance;
            model = ShopModel.Instance;
            
            children = new List<GameObject>();
            Transform[] allChildren = GetComponentsInChildren<Transform>();
            foreach (Transform child in transform)
            {
                if (child.CompareTag("shopMenu"))
                {
                    children.Add(child.gameObject);
                }
            }

            foreach (GameObject child in children)
            {
                child.SetActive(false);
            }
            model.ModeActive = 0;
            children[model.ModeActive].SetActive(true);
            
            //Subscription
            manager.OnCurrencyChange += UpdateCurrencyText;
            
            //Get the specific items 
            foreach (Transform child in children[1].GetComponentInChildren<Transform>()
                         .GetComponentsInChildren<Transform>())
            {
                shopItemList.Add(child.gameObject);
            }
        }
        
        private void PerformSwitchMode(int mode)
        {
            foreach (GameObject child in children)
            {
                child.SetActive(false);
            }

            model.ModeActive = mode;
            children[model.ModeActive].SetActive(true);
        }
        
        // Switching interface
        public void GoToBuyPage(int i) // mode = 1
        {
            foreach (GameObject shopList in shopItemList)
            {
                shopList.SetActive(false);
            }

            currentCategory = i;
            shopItemList[currentCategory].SetActive(true);
            PerformSwitchMode(1);
        }

        public void GoToWelcomePage() //Mode = 0
        {
            PerformSwitchMode(0);
        }

        public void GoToSellPage() // mode = 2
        {
            PerformSwitchMode(2);
        }
        
        
        // Link functions for models and so on
        private void UpdateCurrencyText(int value)
        {
            currencyText.text = value.ToString();
        }

        public void BuyItem(int position)
        {
            Item i = model.GetItemByPosition(currentCategory, position);
            
            //Adjust the player's currency
            manager.Currency -= i.Price;
            
            //Deal with the bought item spawning.
            model.SpawnBoughtItem(i);
        }
    }
    
}
