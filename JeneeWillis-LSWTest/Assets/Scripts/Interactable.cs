using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Willis_Interactions
{
    /// <summary>
    /// CLASS: Interactable
    /// Author: Jenee Willis
    /// Description: Interactable objects will call event when clicked
    /// </summary>
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField]
        internal UnityEvent PlayerInteract;
    }
}
