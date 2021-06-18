using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added

namespace Willis_Shop
{
    /// <summary>
    /// CLASS: RemoveItemFromSelling
    /// Author: Jenee Willis
    /// Description: Put item back in inventory so it does not sell when player confirms
    /// </summary>
    public class RemoveItemFromSelling : MonoBehaviour
    {
        [SerializeField] private Button clickedButton;
        internal ShopManager shopManagerScript;
        internal SellManager sellManagerScript;

        internal GameObject sellCartItem;

        private void OnEnable()
        {
            clickedButton.onClick.AddListener(() => RemoveFromBuyCart());
        }

        private void RemoveFromBuyCart()
        {
            int index = sellCartItem.transform.GetSiblingIndex() - 1;

            shopManagerScript.totalSellCost += sellManagerScript.sellItemsList[index].itemSellPrice;
            shopManagerScript.totalTransaction -= sellManagerScript.sellItemsList[index].itemSellPrice;
            shopManagerScript.UpdateCosts();

            foreach (ShopItems item in sellManagerScript.sellCartItems)
            {
                if (item.itemID == sellManagerScript.sellItemsList[index].itemID)
                {
                    sellManagerScript.sellCartItems.Remove(item);
                    break;
                }
            }

            sellCartItem.SetActive(true);
            Destroy(gameObject);
        }

        private void OnDisable()
        {
            clickedButton.onClick.RemoveAllListeners();
        }
    }
}

