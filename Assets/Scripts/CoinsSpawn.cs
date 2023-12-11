using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] _coins;
    [SerializeField] private Vector3[] _position;

    private Coroutine _coroutine;

    private float _delay = 2f;

    private void Start()
    {
        _coroutine = StartCoroutine(DelayedTime());
    }

    private IEnumerator DelayedTime()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        for (int i = 0; i < _coins.Length; i++)
        {
            GameObject newCoins = Instantiate(_coins[i], _position[i], Quaternion.identity);
            yield return waitForSeconds;
        }
    }
}
