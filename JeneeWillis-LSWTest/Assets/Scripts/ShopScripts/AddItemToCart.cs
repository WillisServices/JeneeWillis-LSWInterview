using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added
using Willis_Player; //added

namespace Willis_Shop
{
    public class AddItemToCart : MonoBehaviour
    {
        [SerializeField] ShopManager shopManagerScript;
        [SerializeField] private PlayerInformation playerStatsScript;

        [SerializeField] private Button clickedButton;
        [SerializeField] private Transform scrollView;

        [SerializeField] private GameObject addedItemPanel;

        private GameObject item;

        private void OnEnable()
        {
            clickedButton.onClick.AddListener(() => AddItem(clickedButton.transform, scrollView));
        }

        public void AddItem(Transform buttonTransform, Transform scrollView)
        {
            int index = buttonTransform.GetSiblingIndex();

            if (shopManagerScript.shopItemsList[index].itemCost <= shopManagerScript.newBalance)
            {
                item = Instantiate(addedItemPanel, scrollView);
                item.GetComponent<RemoveItemFromCart>().cartItem = this.gameObject;
                item.GetComponent<RemoveItemFromCart>().shopManagerScript = shopManagerScript;
                item.transform.GetChild(0).GetComponent<Image>().sprite = shopManagerScript.shopItemsList[index].itemImage;

                shopManagerScript.totalCost += shopManagerScript.shopItemsList[index].itemCost;
                shopManagerScript.newBalance -= shopManagerScript.shopItemsList[index].itemCost;

                shopManagerScript.cartItems.Add(shopManagerScript.shopItemsList[index]);

                shopManagerScript.UpdateGoldText();

                gameObject.SetActive(false);
            }
        }

        private void OnDisable()
        {
            clickedButton.onClick.RemoveAllListeners();
        }
    }
}
