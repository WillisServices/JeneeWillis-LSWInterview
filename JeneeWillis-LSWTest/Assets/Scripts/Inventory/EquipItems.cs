using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Willis_Shop;

namespace Willis_Inventory
{
    public class EquipItems : MonoBehaviour
    {
        [SerializeField] internal List<EquipInformation> equipInformation = new List<EquipInformation>();

        public void EquipItem()
        {
            for (int i = 0; i < equipInformation.Count; i++)
            {
                equipInformation[i].spriteToChange.sprite = equipInformation[i].itemImage;
            }
        }
    }
}
