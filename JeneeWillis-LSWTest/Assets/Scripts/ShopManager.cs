using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Willis_Shop
{
    public class ShopManager : MonoBehaviour
    {
        [System.Serializable]
        internal class ShopItem
        {
            public Sprite itemImage;
            public int itemPrice;
            public bool isClicked = false;
            public int itemSellPrice;
        }

        [SerializeField] internal List<ShopItem> shopItemsList = new List<ShopItem>();
        [SerializeField] private Transform shopScrollView;
        [SerializeField] private GameObject ItemButton;
        private int numberOfItems;

        private GameObject item;

        private void Start()
        {
            numberOfItems = shopItemsList.Count;
            SpawnShopItems();
        }

        private void SpawnShopItems()
        {
            for (int i = 0; i < numberOfItems; i++)
            {
                item = Instantiate(ItemButton, shopScrollView);
                item.transform.GetChild(0).GetComponent<Image>().sprite = shopItemsList[i].itemImage;
                item.transform.GetChild(1).GetComponent<Text>().text = shopItemsList[i].itemPrice.ToString();
                shopItemsList[i].itemSellPrice = Mathf.RoundToInt(0.7f * shopItemsList[i].itemPrice); //70% of original price
            }
        }
    }
}
