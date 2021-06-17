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
            SpawnShopItems(); 
        }

        private void OnEnable()
        {
            startBalance = playerInfoScript.goldAmount;
            newBalance = startBalance;

            UpdateGoldText();

            numberOfItems = shopItemsList.Count;
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

        public void ConfirmButton()
        {
            foreach (Transform child in cartScrollView)
            {
                
            }

            totalCost = 0;
            playerInfoScript.UpdateGold(newBalance);
            playerInfoScript.canMove = true;
            gameObject.SetActive(false);
        }
    }
}
