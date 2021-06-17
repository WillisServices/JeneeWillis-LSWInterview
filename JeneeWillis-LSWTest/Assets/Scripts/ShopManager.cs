using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added
using Willis_Player;

namespace Willis_Shop
{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField] PlayerInformation playerInfoScript;
        [SerializeField] internal List<ShopItems> shopItemsList = new List<ShopItems>();
        [SerializeField] private Transform shopScrollView;
        [SerializeField] private Transform cartScrollView;

        [SerializeField] private Text totalCostText;
        [SerializeField] private Text newBalanceCostText ;

        internal List<ShopItems> cartItems = new List<ShopItems>();

        internal int startBalance;
        internal int totalCost = 0;
        internal int newBalance = 0;

        private GameObject ItemButton;
        private int numberOfItems;

        private GameObject item;

        private void Start()
        {
            startBalance = playerInfoScript.goldAmount;
            newBalance = startBalance;

            UpdateGoldText();

            numberOfItems = shopItemsList.Count;
            SpawnShopItems();
        }

        private void SpawnShopItems()
        {
            ItemButton = shopScrollView.GetChild(0).gameObject;

            for (int i = 0; i < numberOfItems; i++)
            {
                item = Instantiate(ItemButton, shopScrollView);
                item.transform.GetChild(0).GetComponent<Image>().sprite = shopItemsList[i].itemImage;
                item.transform.GetChild(1).GetComponent<Text>().text = shopItemsList[i].itemCost.ToString();
                shopItemsList[i].itemSellPrice = Mathf.RoundToInt(0.7f * shopItemsList[i].itemCost); //70% of original price
                shopItemsList[i].itemID = i;
            }

            Destroy(ItemButton);
        }

        internal void UpdateGoldText()
        {
            totalCostText.text = "Total Costs: " + totalCost.ToString();
            newBalanceCostText.text = "New Balance: " + newBalance.ToString();
        }

        private void ClearCart()
        {
            foreach (Transform child in cartScrollView)
            {
                child.gameObject.transform.SetParent(playerInfoScript.inventorySlot);
            }

            cartItems.Clear();
            gameObject.SetActive(false);
        }

        public void ConfirmButton()
        {
            playerInfoScript.inventoryItems.AddRange(cartItems);
            ClearCart();
        }
    }
}
