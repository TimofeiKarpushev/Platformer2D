using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]private Transform[] _points;
    private float _speed = 2;
    private int i;

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, _points[i].position, _speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, _points[i].position) < 0.2f)
        {
            if(i > 0)
            {
                i=0;
            }
            else
            {
                i=1;
            }
        }
    }
}
