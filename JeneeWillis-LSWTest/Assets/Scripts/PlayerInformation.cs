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

        [SerializeField] internal Transform inventorySlot;
        internal List<ShopItems> inventoryItems = new List<ShopItems>();

        private void Start()
        {
            goldText.text = goldAmount.ToString();
        }
    }
}
