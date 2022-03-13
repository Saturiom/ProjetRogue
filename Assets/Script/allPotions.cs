using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allPotions : MonoBehaviour
{
    [Header("Effet")]
    public int effectPotion;
    public float vitesse, heal;
    [Header("Durée")]
    public float timeEffect;


    private bool TimerStarted = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (effectPotion)
        {
            //effet de heal
            case 1:
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
                break;
            //effet de speed
            case 2:
                //playerController.instance.moveSpeed += 10;
                if (!TimerStarted) TimerStarted = true;
                playerController.instance.moveSpeed += vitesse;
                break;
            default:
                break;
        }
    }

    private float _timer = 0f;

    void Update()
    {
        if (TimerStarted)
        {
            _timer += Time.deltaTime;
            if (_timer >= timeEffect)
            {
                Debug.Log("Test et fin");
                playerController.instance.moveSpeed -= vitesse;
                Destroy(gameObject);
            }
        }
    }

}
