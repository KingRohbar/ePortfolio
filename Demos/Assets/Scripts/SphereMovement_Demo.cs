﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement_Demo : MonoBehaviour
{
    public float m_Speed = 5f;
    public float m_TurnSpeed = 180f;
    public float m_JumpForce = 10f;
    public LayerMask m_FloorLayer;

    private string m_MovementAxisName;
    private string m_TurnAxisName;
    private string m_JumpButton;
    private Rigidbody m_Rigidbody;
    private SphereCollider m_Collider;
    private float m_MovementInputValue;
    private float m_TurnInputValue;
    private bool m_JumpInputValue;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Collider = GetComponent<SphereCollider>();
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
        m_MovementAxisName = "Vertical";
        m_TurnAxisName = "Horizontal";
        m_JumpButton = "Jump";
    }

    // Update is called once per frame
    void Update()
    {
        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);
        m_JumpInputValue = Input.GetButtonDown(m_JumpButton);
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
        //Jump();
    }

    private void Move()
    {

    }

    private void Turn()
    {

    }

    /*
    private void Jump()
    {
        if (m_JumpInputValue && JumpAllowed())
        {
            Vector3 jump = transform.up * m_JumpForce;
            m_Rigidbody.AddForce(jump, ForceMode.Impulse);
        }
    }

    private bool JumpAllowed()
    {
        return Physics.CheckCapsule(m_Collider.bounds.center, new Vector3(m_Collider.bounds.center.x, m_Collider.bounds.min.y, m_Collider.bounds.center.z), m_Collider.radius * .9f, m_FloorLayer);
    }*/
}
