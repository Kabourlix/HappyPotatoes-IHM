using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    public class ShopUIInteraction : MonoBehaviour
    {
        //UI Objects
        
        
        // end
        
        
        
        
        private List<GameObject> children;
        private int modeActive;
        private void Start()
        {
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
            modeActive = 0;
            children[modeActive].SetActive(true);
        }
        
        private void PerformSwitchMode(int mode)
        {
            foreach (GameObject child in children)
            {
                child.SetActive(false);
            }

            modeActive = mode;
            children[modeActive].SetActive(true);
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
    }
}
