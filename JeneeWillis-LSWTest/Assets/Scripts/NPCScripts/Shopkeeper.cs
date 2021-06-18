using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Willis_Inventory; //added

namespace Willis_NPC
{
    /// <summary>
    /// CLASS: NPC
    /// Author: Jenee Willis
    /// Description: Information about shopkeepers
    /// </summary>
    public class Shopkeeper : NPC
    {
        [Header("Script References")]
        [SerializeField] private BagButton bagButtonScript;

        [Header("Shopkeeper Information")]
        [SerializeField] private GameObject storePanel;

        private void Start()
        {
            storePanel.SetActive(false);
        }

        //Show store when character is clicked on
        public void ShowStore()
        {
            //hide inventory
            bagButtonScript.inventoryPanel.SetActive(false);
            bagButtonScript.isOpen = false;

            storePanel.SetActive(true);
        }
    }
}
