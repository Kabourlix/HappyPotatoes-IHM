using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

namespace Shop
{
    public class ShopUIInteraction : MonoBehaviour
    {
        //UI Objects
        [SerializeField] private Text currencyText;
        
        // end
        
        
        
        
        private List<GameObject> children;

        private SettingsManagers manager;
        private ShopModel model;
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
        public void GoToBuyPage() // mode = 1
        {
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
    }
}
