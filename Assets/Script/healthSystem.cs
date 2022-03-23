using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthSystem : MonoBehaviour
{
    public Sprite emptyPoint, halfPoint, fullPoint;
    public Image life1, life2, life3;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (playerController.instance.currentHealth)
        {
            case 0:
                life1.sprite = emptyPoint;
                life2.sprite = emptyPoint;
                life3.sprite = emptyPoint;
                break;
            case 1:
                life1.sprite = fullPoint;
                life2.sprite = emptyPoint;
                life3.sprite = emptyPoint;
                break;
            case 2:
                life1.sprite = fullPoint;
                life2.sprite = fullPoint;
                life3.sprite = emptyPoint;
                break;
            case 3:
                life1.sprite = fullPoint;
                life2.sprite = fullPoint;
                life3.sprite = fullPoint;
                break;

        }

        if (playerController.instance.currentHealth == 2.5)
        {
            life1.sprite = fullPoint;
            life2.sprite = fullPoint;
            life3.sprite = halfPoint;
        }
        if (playerController.instance.currentHealth == 1.5)
        {
            life1.sprite = fullPoint;
            life2.sprite = halfPoint;
            life3.sprite = emptyPoint;
        }
        if (playerController.instance.currentHealth == 0.5)
        {
            life1.sprite = halfPoint;
            life2.sprite = emptyPoint;
            life3.sprite = emptyPoint;
        }


    }
}
