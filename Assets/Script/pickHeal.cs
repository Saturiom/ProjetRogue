using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickHeal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (playerController.instance.currentHealth < playerController.instance.maxHealth)
        {
            Debug.Log("+1 health points");
            playerController.instance.currentHealth += 1;
            if (playerController.instance.currentHealth > playerController.instance.maxHealth)
            {
                playerController.instance.currentHealth = playerController.instance.maxHealth;
            }
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Vous etes full vie");
        }
        //Destroy(gameObject);
    }
}
