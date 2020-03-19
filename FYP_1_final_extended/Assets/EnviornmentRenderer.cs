using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviornmentRenderer : MonoBehaviour {

    Rigidbody rb;
    public float moveSpeed, turnSpeed;

    Animator characterAnim;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        characterAnim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {

        if (Input.GetAxis("Vertical") < 0)
        {
            // Walk backwards
            rb.MovePosition(transform.position - transform.forward * moveSpeed * Time.deltaTime);
            characterAnim.SetFloat("velocityx", 1);
            characterAnim.SetFloat("velocityy", 0);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            // Walk forward
            rb.MovePosition(transform.position + transform.forward * moveSpeed * Time.deltaTime);
            characterAnim.SetFloat("velocityx", 1);
            characterAnim.SetFloat("velocityy", 0);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

        if (Input.GetAxis("Vertical") == 0)
        {
            characterAnim.SetFloat("velocityx", 0);
            characterAnim.SetFloat("velocityy", 0);
        }

    }
}
