using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added

namespace Willis_Shop
{
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
            int index = sellCartItem.transform.GetSiblingIndex();

            shopManagerScript.totalSellCost -= sellManagerScript.sellItemsList[index].itemSellPrice;
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

