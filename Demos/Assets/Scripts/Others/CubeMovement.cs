using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float m_speed = 10f;

    private string m_horizontalAxis = "Horizontal";
    private string m_verticalAxis = "Vertical";
    private Rigidbody m_Rigidbody;
    private float m_horizontalInputValue;
    private float m_verticalInputValue;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_horizontalInputValue = Input.GetAxis(m_horizontalAxis);
        m_verticalInputValue = Input.GetAxis(m_verticalAxis);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 horizontalMovement = transform.right * m_horizontalInputValue * m_speed * Time.deltaTime;
        Vector3 verticalMovement = transform.forward * m_verticalInputValue * m_speed * Time.deltaTime;

        m_Rigidbody.MovePosition(m_Rigidbody.position + horizontalMovement + verticalMovement);
    }
}
