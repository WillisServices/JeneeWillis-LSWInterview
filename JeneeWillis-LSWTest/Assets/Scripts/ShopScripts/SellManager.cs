using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added
using Willis_Player; //added

namespace Willis_Shop
{
    public class SellManager : MonoBehaviour
    {
        [SerializeField] PlayerInformation playerInfoScript;

        [SerializeField] private Transform inventoryScrollbar;
        [SerializeField] private Transform sellingScrollView;

        internal List<ShopItems> sellItemsList = new List<ShopItems>();

        private GameObject ItemButton;

        private void OnEnable()
        {
            ItemButton = inventoryScrollbar.GetChild(0).gameObject;
            ItemButton.SetActive(true);
            SpawnInventoryItemsToSell();
        }

        private void SpawnInventoryItemsToSell()
        {
            for (int i = 0; i < playerInfoScript.inventoryItems.Count; i++)
            {
                GameObject item = Instantiate(ItemButton, inventoryScrollbar);

                item.transform.GetChild(0).GetComponent<Image>().sprite = playerInfoScript.inventoryItems[i].equipInformation[i].itemImage;
                item.transform.GetChild(1).GetComponent<Text>().text = playerInfoScript.inventoryItems[i].itemSellPrice.ToString();
                sellItemsList.Add(playerInfoScript.inventoryItems[i]);
            }

            ItemButton.SetActive(false);
        }

        private void OnDisable()
        {
            sellItemsList.Clear();
        }
    }
}
