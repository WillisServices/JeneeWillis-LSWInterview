using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added
using Willis_Player; //added

namespace Willis_Shop
{
    /// <summary>
    /// CLASS: AddItemToCart
    /// Author: Jenee Willis
    /// Description: Add items into shopping cart so player can make sure they want the item before buying
    /// </summary>
    public class AddItemToCart : MonoBehaviour
    {
        [SerializeField] ShopManager shopManagerScript;
        [SerializeField] private PlayerInformation playerStatsScript;

        [SerializeField] private Button clickedButton;
        [SerializeField] private Transform scrollView;

        [SerializeField] private GameObject addedItemPanel;

        private void OnEnable()
        {
            clickedButton.onClick.AddListener(() => AddToBuyCart(clickedButton.transform, scrollView));
        }

        public void AddToBuyCart(Transform buttonTransform, Transform scrollView)
        {
            int index = buttonTransform.GetSiblingIndex();

            if ((shopManagerScript.shopItemsList[index].itemCost + shopManagerScript.totalTransaction) <= shopManagerScript.startBalance)
            {
                GameObject item = Instantiate(addedItemPanel, scrollView);
                item.transform.SetAsFirstSibling();
                item.transform.GetChild(0).GetComponent<Image>().sprite = shopManagerScript.shopItemsList[index].equipInformation[0].itemImage;

                item.GetComponent<RemoveItemFromCart>().cartItem = this.gameObject;
                item.GetComponent<RemoveItemFromCart>().shopManagerScript = shopManagerScript;

                shopManagerScript.totalBuyCost += shopManagerScript.shopItemsList[index].itemCost;
                shopManagerScript.totalTransaction -= shopManagerScript.shopItemsList[index].itemCost;

                shopManagerScript.shopItemsList[index].canSell = true;
                shopManagerScript.cartItems.Add(shopManagerScript.shopItemsList[index]);

                shopManagerScript.UpdateCosts();

                gameObject.SetActive(false);
            }
        }

        private void OnDisable()
        {
            clickedButton.onClick.RemoveAllListeners();
        }
    }
}
