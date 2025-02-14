﻿using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownController movementContoroller;
    private Rigidbody2D movementRigidbody;

    private Vector2 movementDirection = Vector2.zero;

    private void Awake()
    {
        movementContoroller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        movementContoroller.OnMoveEvent += Move;
    }
    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
    }
    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }
    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 5;

        movementRigidbody.velocity = direction;
    }
}
