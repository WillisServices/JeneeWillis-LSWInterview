using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added
using Willis_Player; //added
using Willis_Inventory; //added

namespace Willis_Shop
{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField] PlayerInformation playerInfoScript;
        [SerializeField] internal List<ShopItems> shopItemsList = new List<ShopItems>();
        [SerializeField] internal Transform shopScrollView;
        [SerializeField] private Transform cartScrollView;

        [SerializeField] private Text totalBuyCostText;
        [SerializeField] private Text totalSellCostText;
        [SerializeField] private Text totalTransactionText;

        internal List<ShopItems> cartItems = new List<ShopItems>();

        internal int startBalance;
        internal int totalBuyCost = 0;
        internal int totalSellCost = 0;
        internal int totalTransaction = 0;

        private int numberOfItems;

        private void Start()
        {
            SpawnShopItems(); 
        }

        private void OnEnable()
        {
            startBalance = playerInfoScript.goldAmount;

            UpdateCosts();

            numberOfItems = shopItemsList.Count;
        }

        private void SpawnShopItems()
        {
            GameObject ItemButton = shopScrollView.GetChild(0).gameObject;

            for (int i = 0; i < numberOfItems; i++)
            {
                GameObject item = Instantiate(ItemButton, shopScrollView);
                item.transform.GetChild(0).GetComponent<Image>().sprite = shopItemsList[i].equipInformation[0].itemImage;
                item.transform.GetChild(1).GetComponent<Text>().text = shopItemsList[i].itemCost.ToString();
                shopItemsList[i].itemSellPrice = Mathf.RoundToInt(0.7f * shopItemsList[i].itemCost); //70% of original price
                shopItemsList[i].itemID = i;
            }

            Destroy(ItemButton);
        }

        internal void UpdateCosts()
        {
            totalSellCostText.text = (totalSellCost * -1).ToString();
            totalBuyCostText.text = (totalBuyCost * -1).ToString(); 
            totalTransactionText.text = totalTransaction.ToString();
        }

        public void ConfirmBuyButton()
        {
            foreach (Transform child in cartScrollView)
            {
                Destroy(child.gameObject);
            }

            AddToInventory(playerInfoScript.inventoryPanel, playerInfoScript.inventorySlot);

            cartItems.Clear();

            playerInfoScript.UpdatePlayerGold((totalTransaction * -1));

            totalSellCost = 0;
            totalBuyCost = 0;
            totalTransaction = 0;

            playerInfoScript.canMove = true;
            gameObject.transform.parent.gameObject.SetActive(false);
        }

        private void AddToInventory(GameObject inventoryItem, Transform slot)
        {
            for (int i = 0; i < cartItems.Count; i++)
            {
                GameObject item = Instantiate(inventoryItem, slot);
                item.transform.SetAsFirstSibling();
                item.transform.GetChild(0).GetComponent<Image>().sprite = cartItems[i].equipInformation[0].itemImage;

                item.GetComponent<EquipItems>().equipInformation = cartItems[i].equipInformation;

                playerInfoScript.inventoryItems.Add(cartItems[i]);
            }
        }
    }
}
