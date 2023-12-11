using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]private Transform[] _points;

    private float _speed = 2;
    private int _targetPosititon;
    private float _reachedPoint = 0.1f;

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, _points[_targetPosititon].position, _speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, _points[_targetPosititon].position) < _reachedPoint)
        {
            _targetPosititon = _targetPosititon > 0  ? _targetPosititon = 0 : _targetPosititon = 1;
        }
    }
}
