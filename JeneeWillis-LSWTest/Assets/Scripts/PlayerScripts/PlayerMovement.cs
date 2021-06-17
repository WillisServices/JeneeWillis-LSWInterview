using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Willis_Animation;

namespace Willis_Player
{
    /// <summary>
    /// CLASS: PlayerMovement
    /// Author: Jenee Willis
    /// Description: Makes player character move to where the player clicks
    /// </summary>
    internal class PlayerMovement : MonoBehaviour
    {
        [Header("Movement Settings")]
        [Tooltip("How fast character moves")]
        [SerializeField] private float movementSpeed = 5f;
        [Tooltip("Where character can walk")]
        [SerializeField] private LayerMask walkable;

        [SerializeField] internal Animator playerAnimator;

        private PlayerAnimation anim;
        private PlayerInformation playerInfoScript;

        internal Vector2 destination;
        private bool isMoving = false;

        private void Start()
        {
            anim = GetComponent<PlayerAnimation>();
            playerInfoScript = GetComponent<PlayerInformation>();
        }

        private void Update()
        {
            //resets player destination
            if (playerInfoScript.canMove == false)
            {
                destination = transform.position;
            }

            //Move when right mouse button is clicked
            if (Input.GetMouseButton(1))
            {
                //check if clicked area is walkable
                RaycastHit2D hit = CheckPlayerClick.GetHit(walkable);

                if (hit.collider != null)
                {
                    //get position of where the character has to move to
                    GetTargetPosition();
                }
            }

            //Move player when position has been set

            if (isMoving == true)
            {
                playerAnimator.SetBool("isWalking", isMoving);
                MovePlayer();
            }
        }

        /// <summary>
        /// METHOD: GetTargetPosition()
        /// Desscription: Get world position of where the player clicks
        /// </summary> 
        private void GetTargetPosition()
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (playerInfoScript.canMove == true)
            {
                playerAnimator = anim.GetAnimator(ConvertToVector2(transform.position), destination);
                isMoving = true;
            }
        }

        /// <summary>
        /// METHOD: GetTargetPosition()
        /// Desscription: Move player towards target position until they reach there
        /// </summary> 
        private void MovePlayer()
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime);

            //check if player has reached destination
            if (ConvertToVector2(transform.position) == destination)
            {
                //stop moving if reached
                isMoving = false;
                playerAnimator.SetBool("isWalking", isMoving);
            }
        }

        /// <summary>
        /// METHOD: ConvertToVector2()
        /// Desscription: convert vector3 into vector2
        /// </summary> 
        internal Vector2 ConvertToVector2(Vector3 vector3)
        {
            return (new Vector2(vector3.x, vector3.y));
        }
    }
}
