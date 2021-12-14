using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Player
{
    public class ShopController : MonoBehaviour
    {
        public InputActionProperty showShopMenu;

        [SerializeField] private GameObject teleportController;
        [SerializeField] private GameObject shopController;
        private void Start()
        {
            showShopMenu.action.performed += ctx => ShowShopMenu();
        }
        
        /***
         * This function make the shop Menu appear in the user hands.
         */
        private void ShowShopMenu()
        {
            teleportController.SetActive(!teleportController.activeInHierarchy);
            shopController.SetActive(!shopController.activeInHierarchy);
            //gameObject.SetActive(!gameObject.activeInHierarchy);
        }

    }    
}

