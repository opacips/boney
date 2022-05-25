using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] private float movementSpeed = 15f;
    [SerializeField] private float jumpForce = 25f;
    public bool isGrounded;

    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;

    [Header("Animation Variables")]
    public bool isIdle;


    private Vector2 moveDirection;
    


    private void Update()
    {
        MovementHandler();
        SetAnimations(CheckIsGrounded(), isIdle);
      
    }

    private void MovementHandler()
    {
        float moveX = 0f;

        bool movingLeft = Input.GetKey(KeyCode.A);
        bool movingRight = Input.GetKey(KeyCode.D);

        if (movingLeft)
        {
            moveX = -1;
        }
        else if (movingRight)
        {
            moveX = 1f;
        }

        //Jump
   

        moveDirection = new Vector2(moveX, 0f).normalized;
        isIdle = moveX == 0;
    }


    private void FixedUpdate()
    {
        CheckIsGrounded();
        rb.velocity =  new Vector2(moveDirection.x * movementSpeed, 0f);
        
    }


    private bool CheckIsGrounded()
    {
        float extraHeight = .25f;
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraHeight, groundLayer);
        Color rayColor;
        

        if (hit.collider != null)
        { 
            rayColor = Color.blue;
            isGrounded = true;
        }
        else
        {
            isGrounded =false;
            Debug.Log("doesn't hit " + groundLayer.ToString());
            rayColor = Color.red;
        }

        Debug.DrawRay(boxCollider.bounds.center + new Vector3(boxCollider.bounds.extents.x, 0f), Vector2.down * (boxCollider.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, 0f), Vector2.down * (boxCollider.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, boxCollider.bounds.extents.y), Vector2.right * (boxCollider.bounds.extents.x), rayColor);
        return hit.collider != null;
    }

    private void SetAnimations(bool isGrounded, bool isIdle)
    {
        if (isIdle)
        {
            rb.velocity = Vector2.zero;
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetFloat("horizontalMovement", moveDirection.x);
            animator.SetBool("isMoving", true);
        }

        if (isGrounded)
        { 
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetFloat("horizontalMovement", moveDirection.x);
            animator.SetBool("isJumping", true);
        }
        

        
    }
  
}
