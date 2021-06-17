using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Willis_Interactions; //added

namespace Willis_Player
{
    /// <summary>
    /// CLASS: PlayerClick
    /// Author: Jenee Willis
    /// Description: Checks where player clicks and whether it is interactable
    /// </summary>
    internal class PlayerClick : MonoBehaviour
    {
        [Header("Script References")]
        [Tooltip("PlayerMovement script")]
        [SerializeField] private PlayerInformation playerInfoScript;

        [Header("Interactable Settings")]
        [Tooltip("What players can interact with")]
        [SerializeField] private LayerMask interactableGameobjects;
        [Tooltip("How far character stops from the interactable gameobject")]
        [SerializeField] private float stopDistanceFromInteractables = 2f;

        private GameObject hitObject;
        private bool canInteract = false;

        private void Update()
        {
            //checks if player has clicked on an interactable object with right mouse button
            if (Input.GetMouseButton(1))
            {
                RaycastHit2D hit = CheckPlayerClick.GetHit(interactableGameobjects);

                if (hit.collider != null)
                {
                    hitObject = hit.collider.gameObject;
                    canInteract = true;
                }
                else
                {
                    canInteract = false;
                }
            }

            //stop player at a certain distance if they clicked on an interactable object
            if (canInteract == true)
            {
                StopPlayerMovement();
            }
        }

        /// <summary>
        /// METHOD: StopPlayerMovement()
        /// Desscription: Stop player when they are close to interactable gameobject
        /// </summary> 
        private void StopPlayerMovement()
        {
            //check distance between player and the interactable gameobject to see how close they are to each other
            if (Vector2.Distance(transform.position, hitObject.transform.position) <= stopDistanceFromInteractables)
            {
                playerInfoScript.canMove = false;

                hitObject.GetComponent<Interactable>().PlayerInteract.Invoke();

                canInteract = false;
            }
            else
            {
                playerInfoScript.canMove = true;
            }

        }
    }

    /// <summary>
    /// CLASS: PlayerClick
    /// Author: Jenee Willis
    /// Description: Get information about what gameobject the player has clicked on
    /// </summary>
    internal static class CheckPlayerClick
    {
        internal static RaycastHit2D GetHit(LayerMask mask)
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 rayOrigin = new Vector2(clickPosition.x, clickPosition.y);

            //return clicked gameobject
            return Physics2D.Raycast(rayOrigin, Vector2.zero, Mathf.Infinity, mask);
        }
    }
}
