using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added
using Willis_Player; //added

public class SellManager : MonoBehaviour
{
    [SerializeField] PlayerInformation playerInfoScript;

    [SerializeField] private Transform inventoryScrollbar;
    [SerializeField] private Transform sellingScrollView;

    private void Start()
    {
        SpawnInventoryItemsToSell();
    }

    private void SpawnInventoryItemsToSell()
    {
        GameObject ItemButton = inventoryScrollbar.GetChild(0).gameObject;

        for (int i = 0; i < playerInfoScript.inventoryItems.Count; i++)
        {
            GameObject item = Instantiate(ItemButton, inventoryScrollbar);

            item.transform.GetChild(0).GetComponent<Image>().sprite = playerInfoScript.inventoryItems[i].equipInformation[i].itemImage;
            item.transform.GetChild(1).GetComponent<Text>().text = playerInfoScript.inventoryItems[i].itemSellPrice.ToString();
        }

        Destroy(ItemButton);
    }
}
