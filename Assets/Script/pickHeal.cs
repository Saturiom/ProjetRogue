using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickHeal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Ici ça baise");
        Debug.Log("Ratio");
        Destroy(gameObject);
    }
}
