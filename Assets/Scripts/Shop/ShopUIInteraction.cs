using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    public class ShopUIInteraction : MonoBehaviour
    {

        private List<GameObject> children;
        private int modeActive;
        private void Start()
        {
            children = new List<GameObject>();
            Transform[] allChildren = GetComponentsInChildren<Transform>();
            foreach (Transform child in transform)
            {
                if (child.CompareTag("ControllerMode"))
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

        public void GoToBuyPage()
        {
            
        }

        public void GoToWelcomePage()
        {
            
        }

        public void GoToSellPage()
        {
            
        }
    }
}
