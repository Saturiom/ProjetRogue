using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allPotionsTime : MonoBehaviour
{
    [Header("Effet")]
    public int effectPotion;
    public float vitesse;
    [Header("Durée")]
    public float timeEffect;
    public float healthIncreasePerSecond;


    private bool TimerStarted = false;
    private bool TimerStarted2 = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (effectPotion)
        {
            //effet de heal
            case 1:
                Debug.Log("Debut de l'effet de soin");
                if (!TimerStarted) TimerStarted2 = true;

                break;
            //effet de speed
            case 2:
                //playerController.instance.moveSpeed += 10;
                Debug.Log("Debut de l'effet");
                if (!TimerStarted) TimerStarted = true;
                playerController.instance.moveSpeed += vitesse;
                break;
            default:
                break;
        }
    }

    void playerHeal()
    {
        if (TimerStarted2)
        {
            //clock
        }

    }


    void PlayerSpeed()
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

    private float _timer = 0f;
    private float _timer2 = 0f;


    void Update()
    {
        Debug.Log("CurrentLife: " + playerController.instance.maxHealth);
        PlayerSpeed();
        playerHeal();

    }
}
