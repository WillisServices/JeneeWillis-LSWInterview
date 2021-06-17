using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Willis_Interactions;

namespace Willis_NPC
{
    /// <summary>
    /// CLASS: NPC
    /// Author: Jenee Willis
    /// Description: Information about non-player characters
    /// </summary>
    public abstract class NPC : Interactable
    {
        [SerializeField]
        private string npcName = "";
        [SerializeField]
        private List<string> PassbyDialogue = new List<string>();
    }
}
