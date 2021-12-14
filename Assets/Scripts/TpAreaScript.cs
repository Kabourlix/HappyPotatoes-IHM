using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpAreaScript : MonoBehaviour
{
   public bool isPlayerEntered = false;
   [SerializeField] private GameObject player;
   private void OnTriggerEnter(Collider other)
   {
      isPlayerEntered = true;
   }

   private void OnTriggerExit(Collider other)
   {
      isPlayerEntered = false;
   }
}
