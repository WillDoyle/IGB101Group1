using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{

    public Animator anim;
    public float moveSpeed = 5f;
    public float runSpeed = 8f;
    public float rotSpeed = 10;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ForwardMovement();
        Turning();
        Actions();
    }

    private void ForwardMovement()
    {
        if (Input.GetKey("w"))
        {
            anim.SetBool("Walking", true);

            float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : moveSpeed;
            Vector3 forward = transform.forward * speed * Time.deltaTime;
            rb.MovePosition(transform.position + forward);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("Running", true);
            }
            else
            {
                anim.SetBool("Running", false);
            }
        }
        else if (Input.GetKeyUp("w"))
        {
            anim.SetBool("Walking", false);
            anim.SetBool("Running", false);
        }
    }

    private void Turning()
    {
        if (Input.GetKey("a"))
        {
            transform.Rotate(0, -rotSpeed * 15 * Time.deltaTime, 0, Space.World);
            anim.SetBool("Turn Left", true);
        }
        else if (Input.GetKey("d"))
        {
            transform.Rotate(0, rotSpeed * 15 * Time.deltaTime, 0, Space.World);
            anim.SetBool("Turn Right", true);
        }
        else
        {
            anim.SetBool("Turn Left", false);
            anim.SetBool("Turn Right", false);
        }
    }

    // Actions method stays the same
    private void Actions()
    {
        if (Input.GetKeyDown("e"))
        {
            anim.SetBool("Waving", true);
        }
        else if (Input.GetKeyUp("e"))
        {
            anim.SetBool("Waving", false);
        }
    }
}