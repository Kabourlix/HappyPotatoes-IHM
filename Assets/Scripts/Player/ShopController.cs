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
        private Rigidbody rb;
        [SerializeField] private Transform leftController;

        [Range(0.0f, 360.0f)] public float rotateBy = 10.0f;
        
        
        public bool isEnabled;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            showShopMenu.action.performed += ctx => ShowShopMenu();
            isEnabled = false;
        }
        
        /***
         * This function make the shop Menu appear in the user hands.
         */
        private void ShowShopMenu()
        {
            gameObject.SetActive(!gameObject.activeInHierarchy);
        }

        private void Update()
        {
            rb.MovePosition(leftController.position);
            //rb.MoveRotation(leftController.rotation*Quaternion.Euler(rotateBy,0,0));
        }
    }    
}

