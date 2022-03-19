using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allPotions : MonoBehaviour
{

    [Header("Effet")]
    public int effectPotion;
    public float vitesse, heal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (effectPotion)
        {
            //effet de heal
            case 1:
                PlayerHeal();
                break;
            //effet de speed
            case 2:
                PlayerSpeed();
                break;
            default:
                break;
        }
    }

    private void PlayerHeal()
    {
        Debug.Log("Vous avez choisi l'effet heal! ");
        if (playerController.instance.currentHealth < playerController.instance.maxHealth)
        {
            Debug.Log("Vous avez gagnez: " + heal + "Health points");
            playerController.instance.currentHealth += heal;
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
    }

    void PlayerSpeed()
    {

        Debug.Log("Effet de speed");
        playerController.instance.moveSpeed += vitesse;
        Debug.Log("Votre vitesse Max a augmenté: " + vitesse);
        Debug.Log("Vitesse actuel: " + playerController.instance.moveSpeed);
        Destroy(gameObject);
    }
}

