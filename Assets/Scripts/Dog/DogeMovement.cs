using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogeMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    [Header("Movement Variables")]
    [SerializeField] private float movementSpeed = 7.5f;
    [SerializeField] private float jumpPower = 10f;
    public bool isMoving;
    public bool isGrounded;
    public bool canDoubleJump;
    

    private float horizontalInput;

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded)
            {
                Jump();
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                Jump();
                canDoubleJump = false;
            }

        }
       
        SetAnimations();

    }

    private void FixedUpdate()
    {
        CheckIsGrounded();
        rb.velocity = new Vector2(horizontalInput * movementSpeed, rb.velocity.y);
    }

    private bool CheckIsGrounded()
    {
        float distance = .15f;
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, distance, groundLayer);
        Color rayColor;


        if (hit.collider != null)
        {
            rayColor = Color.blue;
            isGrounded = true;

            Debug.Log("Hits the Ground " + groundLayer);
        }
        else
        {
            isGrounded = false;

            Debug.Log("Doesn't hit any layer");
            rayColor = Color.red;
        }

        #region DebugRay
        Debug.DrawRay(boxCollider.bounds.center + new Vector3(boxCollider.bounds.extents.x, 0f), Vector2.down * (boxCollider.bounds.extents.y + distance), rayColor);
        Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, 0f), Vector2.down * (boxCollider.bounds.extents.y + distance), rayColor);
        Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, boxCollider.bounds.extents.y), Vector2.right * (boxCollider.bounds.extents.x), rayColor);
        #endregion

        return hit.collider != null;
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        isGrounded = false;
    }

    private void SetAnimations()
    {

        //Running Animations 
        if(horizontalInput > 0)
        {
            isMoving = true;
            animator.SetFloat("horizontalMovement", horizontalInput);
            animator.SetBool("isMoving", isMoving);
        }
        else if(horizontalInput < 0)
        {
            isMoving = true;
            animator.SetFloat("horizontalMovement", horizontalInput);
            animator.SetBool("isMoving", isMoving);
        }
        else
        {
            isMoving = false;
            animator.SetBool("isMoving", isMoving);
        }

        //Jumping Animations
        if(!isGrounded && horizontalInput > 0)
        {
            animator.SetBool("isJumpingRight", true);
        }
        else if (!isGrounded && horizontalInput < 0)
        {
            animator.SetBool("isJumpingLeft", true);
        }
        else
        {
            animator.SetBool("isJumpingRight", false);
            animator.SetBool("isJumpingLeft", false);
        }

    }
}
