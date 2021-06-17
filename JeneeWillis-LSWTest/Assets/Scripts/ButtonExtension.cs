using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Willis_Shop;
using Willis_Player;

public class ButtonExtension : MonoBehaviour
{
    //[SerializeField] private ShopManager shopManagerBuy;
    //[SerializeField] private ShopManager shopManagerSell;
    //[SerializeField] private Transform buyScrollView;
    //[SerializeField] private Transform sellScrollView;

    //[SerializeField] GameObject itemPanel;

    //private GameObject item;

    //public void BuyItem(Transform buttonTransform)
    //{
    //    item = Instantiate(itemPanel, buyScrollView);
    //    int index = buttonTransform.GetSiblingIndex();
    //    item.transform.GetChild(0).GetComponent<Image>().sprite = shopManagerBuy.shopItemsList[index].itemImage;
    //}

    [SerializeField] private PlayerStatistics playStatsScript;
    private int totalCost;

    private void ButtonCallBack()
    {
        
    }

    public void FilterItem()
    {

    }
}
