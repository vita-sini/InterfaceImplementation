using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] public float _speed;
    [SerializeField] private Transform[] _points;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private int _currentPoint;
    private Vector3 direction;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    public void Patrol()
    {
        Transform target = _points [_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position.x > target.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }

        if (transform.position == target.position)
        {
            _currentPoint++;

            //spriteRenderer.flipX = true;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;

                //spriteRenderer.flipX = false;
            }
        }
    }
}
