using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Willis_NPC
{
    public class Shopkeeper : NPC
    {
        [SerializeField]
        private GameObject storePanel;

        private void Start()
        {
            storePanel.SetActive(false);
        }

        public void ShowStore()
        {
            storePanel.SetActive(true);
        }
    }
}
