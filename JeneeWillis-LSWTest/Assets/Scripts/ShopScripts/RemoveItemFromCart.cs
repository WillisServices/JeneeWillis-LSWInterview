using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added
using System.Linq;

namespace Willis_Shop
{
    public class RemoveItemFromCart : MonoBehaviour
    {
        [SerializeField] private Button clickedButton;
        internal ShopManager shopManagerScript;

        internal GameObject cartItem;

        private void OnEnable()
        {
            clickedButton.onClick.AddListener(() => RemoveItem());
        }

        private void RemoveItem()
        {
            int index = cartItem.transform.GetSiblingIndex();

            shopManagerScript.totalCost -= shopManagerScript.shopItemsList[index].itemCost;
            shopManagerScript.newBalance += shopManagerScript.shopItemsList[index].itemCost;
            shopManagerScript.UpdateGoldText();

            foreach (ShopItems item in shopManagerScript.cartItems)
            {
                if (item.itemID == shopManagerScript.shopItemsList[index].itemID)
                {
                    shopManagerScript.cartItems.Remove(item);
                    break;
                }
            }

            cartItem.SetActive(true);
            Destroy(gameObject);
        }

        private void OnDisable()
        {
            clickedButton.onClick.RemoveAllListeners();
        }
    }
}
