using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Willis_Player;

namespace Willis_Animation 
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] float minDistanceToTurn = 1f;
        [SerializeField] GameObject[] playerSprites = new GameObject[4];

        internal Animator GetAnimator(Vector2 playerPosition, Vector2 playerDestination)
        {
            int index = 0;

            if (Mathf.Abs(playerPosition.x - playerDestination.x) < minDistanceToTurn)
            {
                if (playerPosition.y <= playerDestination.y)
                {
                    index = 1;
                }
                else
                {
                    index = 0;
                }
            }
            else
            {
                if (playerPosition.x <= playerDestination.x)
                {
                    index = 3; 
                }
                else
                {
                    index = 2; 
                }
            }

            Animator anim = playerSprites[index].GetComponent<Animator>();

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
