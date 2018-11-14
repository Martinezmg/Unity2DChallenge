using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Move to point controller.
/// 
/// Inpired by https://www.youtube.com/watch?v=Cw6B-VYNba0
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 velDir;
    [Range(0f, 10f)]
    public float velocityMagnitude = 1f;

    public Vector2Variable targetPos;    
    private float targetDistance = 0f;
    [Range(0f, 1f)]
    public float targetTreshold = 1f;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        targetDistance = Vector2.Distance(transform.position, targetPos.Value);
    }

    private void FixedUpdate()
    {
        if (targetTreshold > targetDistance)
            velDir = Vector2.zero;
        else
            velDir = (targetPos.Value - (Vector2)transform.position).normalized;

        rb.velocity = velDir * velocityMagnitude;   
    }
}
