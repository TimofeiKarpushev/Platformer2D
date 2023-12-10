using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawn : MonoBehaviour
{
    public GameObject[] Coins;
    public Vector3[] Position;

    private Coroutine _coroutine;

    private float _delay = 2f;

    private void Start()
    {
        _coroutine = StartCoroutine(DelayedTime());
    }

    private IEnumerator DelayedTime()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        for (int i = 0; i < Coins.Length; i++)
        {
            GameObject newCoins = Instantiate(Coins[i], Position[i], Quaternion.identity);
            yield return waitForSeconds;
        }
    }
}
