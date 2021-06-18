using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Willis_Animation 
{
    /// <summary>
    /// CLASS: PlayerAnimation
    /// Author: Jenee Willis
    /// Description: Controls player animation
    /// </summary>
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] float minDistanceToTurn = 1f;
        [SerializeField] GameObject[] playerSprites = new GameObject[4];

        /// <summary>
        /// MEHOTD: GetAnimator()
        /// Author: Jenee Willis
        /// Description: Gets sprite depending on which direction player is moving 
        /// </summary>
        internal Animator GetAnimator(Vector2 playerPosition, Vector2 playerDestination)
        {
            int index = 0;

            if (Mathf.Abs(playerPosition.x - playerDestination.x) < minDistanceToTurn)
            {
                if (playerPosition.y <= playerDestination.y)
                {
                    index = 1; //backward
                }
                else
                {
                    index = 0; //forward
                }
            }
            else
            {
                if (playerPosition.x <= playerDestination.x)
                {
                    index = 3; //left
                }
                else
                {
                    index = 2; //right
                }
            }

            Animator anim = playerSprites[index].GetComponent<Animator>();

            //change sprite in game
            for (int i = 0; i < playerSprites.Length; i++)
            {
                if (i == index)
                {
                    playerSprites[i].SetActive(true);
                }
                else
                {
                    playerSprites[i].SetActive(false);
                }
            }

            return anim;
        }
    }
}
