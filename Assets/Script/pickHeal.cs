using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickHeal : MonoBehaviour
{

    [Header("Effet")]
    public float soin;


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (playerController.instance.currentHealth < playerController.instance.maxHealth)
        {
            Debug.Log("Vous avez gagnez: " + soin + "Health points");
            playerController.instance.currentHealth += soin;
            if (playerController.instance.currentHealth > playerController.instance.maxHealth)
            {
                playerController.instance.currentHealth = playerController.instance.maxHealth;
            }
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Vous ne pouvez pas ramasser la potion vous avez: " + playerController.instance.currentHealth + "/" + playerController.instance.maxHealth);
        }
        //Destroy(gameObject);
    }
}
