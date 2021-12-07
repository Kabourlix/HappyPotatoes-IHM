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

        [SerializeField]
        private GameObject menuObject;

        [SerializeField] private GameObject leftController;
        public float moveSpeed = 10.0f;
        
        private bool isAppearing;

        private void Start()
        {
            showShopMenu.action.performed += ctx => ShowShopMenu();
            isAppearing = false;
        }

        private void ShowShopMenu()
        {
            if (!isAppearing)
            {
                //TODO : Enhance the interaction to make the book coming into the player hand and attach it.
                //menuObject.transform.position = transform.position;
                //var position = menuObject.transform.position;
                menuObject.SetActive(true);
                isAppearing = true;
            }
            else
            {
                menuObject.SetActive(false);
                isAppearing = false;
            }
        }

        private void Update()
        {
            if (isAppearing)
            {
                
                Vector3 leftCtrlPos = leftController.transform.position;
                menuObject.transform.position = Vector3.MoveTowards(menuObject.transform.position,
                    leftCtrlPos, moveSpeed);
                if (menuObject.transform.position == leftCtrlPos)
                {
                    isAppearing = false;
                }
            }
        }
    }    
}

