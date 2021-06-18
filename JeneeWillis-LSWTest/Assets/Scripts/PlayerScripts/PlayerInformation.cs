using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added
using Willis_Shop; //added

namespace Willis_Player
{
    public class PlayerInformation : MonoBehaviour
    {
        [Header("General Information")]
        [SerializeField] internal int goldAmount;

        [Header("UI Component References")]
        [SerializeField] private Text goldText;

        internal List<ShopItems> inventoryItems = new List<ShopItems>();

        [SerializeField] internal GameObject inventoryPanel;
        [SerializeField] internal Transform inventorySlot;

        internal bool canMove = true;

        private void Start()
        {
            goldText.text = goldAmount.ToString();
        }

        internal void UpdatePlayerGold(int newAmount)
        {
            goldAmount = goldAmount - newAmount;
            goldText.text = goldAmount.ToString();
        }
    }
}
