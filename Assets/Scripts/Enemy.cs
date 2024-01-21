using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Patrolling))]
public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetPlayer;

    Patrolling patrolling;

    public LayerMask layerMask;

    public Vector2 DetectorSize = Vector2.one;

    private void Start()
    {
        patrolling = GetComponent<Patrolling>();
    }

    private void Update()
    {
        Collider2D collider = Physics2D.OverlapBox(transform.position, DetectorSize, 0, layerMask);

        if (collider != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, patrolling._speed * Time.deltaTime);
        }
        else
        {
            patrolling.Patrol();
        }
    }
}
