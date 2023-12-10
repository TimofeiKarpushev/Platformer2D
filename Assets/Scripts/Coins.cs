using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    const string Coin = "Coin";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(Coin))
        {
            Destroy(collision.gameObject);
        }
    }
}
