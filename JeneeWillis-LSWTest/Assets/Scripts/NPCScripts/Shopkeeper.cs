using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Willis_NPC
{
    /// <summary>
    /// CLASS: NPC
    /// Author: Jenee Willis
    /// Description: Information about shopkeepers
    /// </summary>
    public class Shopkeeper : NPC
    {
        [Header("Shopkeeper Information")]
        [SerializeField] private GameObject storePanel;

        private void Start()
        {
            storePanel.SetActive(false);
        }

        //Show store when character is clicked on
        public void ShowStore()
        {
            storePanel.SetActive(true);
        }
    }
}
