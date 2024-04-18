using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public Animator anim;
    public Rigidbody2D rb2D;
    public float jumpForce;
    public float playerSpeed;
    public Vector2 jumpHeight;
    public bool isGrounded;
    public float posRadius;

    public LayerMask ground;
    public Transform playerPos;
  


    void Start()
    {
        
    }

   
    void Update()
    {
        if(Input.GetAxis("Horizontal")!= 0)
        {
            if(Input.GetAxisRaw("Horizontal")> 0)
            {
                anim.Play("Walk");
                rb2D.AddForce(Vector2.right * playerSpeed);
            }

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                anim.Play("Walk");
                    rb2D.AddForce(Vector2.left* playerSpeed);
            }

            else
            {
                anim.Play("Idle");
            }

            isGrounded = Physics2D.OverlapCircle(playerPos.position, posRadius, ground);

            if(isGrounded== true&& Input.GetKeyDown("space"))
            {
                rb2D.AddForce(Vector2.up * jumpHeight);
            }
        }
    }
}
