using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added
using Willis_Player; //added

namespace Willis_Shop
{
    public class AddItemToSell : MonoBehaviour
    {
        [SerializeField] ShopManager shopManagerScript;
        [SerializeField] SellManager sellManagerScript;
        [SerializeField] private PlayerInformation playerStatsScript;

        [SerializeField] private Button clickedButton;
        [SerializeField] private Transform scrollView;

        [SerializeField] private GameObject addedItemPanel;

        private void OnEnable()
        {
            clickedButton.onClick.AddListener(() => AddToSellCart(clickedButton.transform, scrollView));
        }

        public void AddToSellCart(Transform buttonTransform, Transform scrollView)
        {
            int index = (buttonTransform.GetSiblingIndex()) - 1;

            GameObject item = Instantiate(addedItemPanel, scrollView);
            item.transform.SetAsFirstSibling();
            item.transform.GetChild(0).GetComponent<Image>().sprite = buttonTransform.GetChild(0).GetComponent<Image>().sprite;

            item.GetComponent<RemoveItemFromSelling>().sellCartItem = this.gameObject;
            item.GetComponent<RemoveItemFromSelling>().shopManagerScript = shopManagerScript;
            item.GetComponent<RemoveItemFromSelling>().sellManagerScript = sellManagerScript;

            shopManagerScript.totalSellCost -= sellManagerScript.sellItemsList[index].itemSellPrice;
            shopManagerScript.totalTransaction += sellManagerScript.sellItemsList[index].itemSellPrice;

            sellManagerScript.sellCartItems.Add(sellManagerScript.sellItemsList[index]);

            shopManagerScript.UpdateCosts();

            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            clickedButton.onClick.RemoveAllListeners();
        }
    }
}
