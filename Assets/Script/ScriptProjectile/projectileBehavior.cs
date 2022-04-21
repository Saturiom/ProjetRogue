using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileBehavior : MonoBehaviour
{

    Rigidbody2D rb;
    [Header("Vitesse")]
    public int vitesse;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * vitesse;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        if (other.gameObject.name == "Player")
        {
            Debug.Log("hIT");
            playerController.instance.currentHealth -= 1;
        }
    }
}
