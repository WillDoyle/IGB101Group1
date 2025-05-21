using UnityEngine;
public class Jump : MonoBehaviour
{
    public Animator animator;
    public bool isGrounded = true;
    public float jumpHeight = 400.0f;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpHeight);
            animator.SetBool("Jumping", true);
        }
        else if (Input.GetKeyUp("space"))
        {
            animator.SetBool("Jumping", false);
        }
    }
}