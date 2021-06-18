using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added
using Willis_Player; //added

namespace Willis_Shop
{
    /// <summary>
    /// CLASS: SellManager
    /// Author: Jenee Willis
    /// Description: Controls what player sells in their inventory
    /// </summary>
    public class SellManager : MonoBehaviour
    {
        [SerializeField] PlayerInformation playerInfoScript;
        [SerializeField] ShopManager shopManagerScript;

        [SerializeField] private Transform inventoryScrollbar;
        [SerializeField] private Transform sellingScrollView;

        internal List<ShopItems> sellItemsList = new List<ShopItems>();
        internal List<ShopItems> sellCartItems = new List<ShopItems>();

        private string firstItemName;
        private GameObject ItemButton;

        private void OnEnable()
        {
            ItemButton = inventoryScrollbar.GetChild(0).gameObject;
            firstItemName = ItemButton.name;
            ItemButton.SetActive(true);
            SpawnInventoryItemsToSell();
        }

        private void SpawnInventoryItemsToSell()
        {
            for (int i = 0; i < playerInfoScript.inventoryItems.Count; i++)
            {
                GameObject item = Instantiate(ItemButton, inventoryScrollbar);

                item.transform.GetChild(0).GetComponent<Image>().sprite = playerInfoScript.inventoryItems[i].equipInformation[0].itemImage;
                item.transform.GetChild(1).GetComponent<Text>().text = playerInfoScript.inventoryItems[i].itemSellPrice.ToString();
                sellItemsList.Add(playerInfoScript.inventoryItems[i]);
            }

            ItemButton.SetActive(false);
        }

        public void ConfirmSellButton()
        {
            foreach (Transform child in inventoryScrollbar)
            {
                if (child.gameObject.name != firstItemName)
                {
                    Destroy(child.gameObject);
                }
            }

            foreach (Transform child in sellingScrollView)
            {
                if (child.gameObject.name != firstItemName)
                {
                    Destroy(child.gameObject);
                }
            }

            RemoveFromInventory();
            AddToShop();
            sellItemsList.Clear();
        }

        private void RemoveFromInventory()
        {
            foreach (Transform child in playerInfoScript.inventorySlot)
            {
                for (int i = 0; i < sellCartItems.Count; i++)
                {
                    if (child.transform.GetChild(0).GetComponent<Image>().sprite == sellCartItems[i].equipInformation[0].itemImage)
                    {
                        Destroy(child.gameObject);
                    }
                }
            }

            if (sellCartItems.Count > 0)
            {
                List<ShopItems> newItems = new List<ShopItems>();

                foreach (ShopItems item in playerInfoScript.inventoryItems)
                {
                    for (int i = 0; i < sellCartItems.Count; i++)
                    {
                        if (item.equipInformation[0].itemImage != sellCartItems[i].equipInformation[0].itemImage)
                        {
                            newItems.Add(item);
                        }
                    }
                }
                playerInfoScript.inventoryItems = newItems;
            }
        }

        private void AddToShop()
        {
            foreach (Transform child in shopManagerScript.shopScrollView)
            {
                for (int i = 0; i < sellCartItems.Count; i++)
                {
                    if (child.transform.GetChild(0).GetComponent<Image>().sprite == sellCartItems[i].equipInformation[0].itemImage)
                    {
                        child.gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}
