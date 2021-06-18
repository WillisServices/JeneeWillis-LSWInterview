using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added

namespace Willis_Shop
{
    public class RemoveItemFromCart : MonoBehaviour
    {
        [SerializeField] private Button clickedButton;
        internal ShopManager shopManagerScript;

        internal GameObject cartItem;

        private void OnEnable()
        {
            clickedButton.onClick.AddListener(() => RemoveFromBuyCart());
        }

        private void RemoveFromBuyCart()
        {
            int index = cartItem.transform.GetSiblingIndex();

            shopManagerScript.totalCost -= shopManagerScript.shopItemsList[index].itemCost;
            shopManagerScript.totalTransaction += shopManagerScript.shopItemsList[index].itemCost;
            shopManagerScript.UpdateCosts();

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
