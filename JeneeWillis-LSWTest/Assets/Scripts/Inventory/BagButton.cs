using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Willis_Inventory
{
    /// <summary>
    /// CLASS: BagButton
    /// Author: Jenee Willis
    /// Description: Shows and hides inventory
    /// </summary>
    public class BagButton : MonoBehaviour
    {
        [SerializeField] internal GameObject inventoryPanel;

        internal bool isOpen = false;

        private void Start()
        {
            inventoryPanel.SetActive(false);
        }

        public void OpenInventory()
        {
            if (isOpen == false)
            {
                inventoryPanel.SetActive(true);
                isOpen = true;
            }
            else
            {
                inventoryPanel.SetActive(false);
                isOpen = false;
            }
        }
    }
}
