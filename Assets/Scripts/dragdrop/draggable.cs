using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draggable : MonoBehaviour
{
    public delegate void DragEndDelegate(draggable draggableObjects);

    public DragEndDelegate DragEndedCallback;

    private bool isDragged = false;
    private Vector3 mouseDragStartPos;
    private Vector3 spriteDragStartPos;

    public BoxCollider2D boxCollider;
    public LayerMask groundLayer;
    public bool isGrounded;
    private void OnMouseDown()
    {
        isDragged = true;
        mouseDragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPos = transform.localPosition;

    }
    private void OnMouseDrag()
    {
        if (isDragged)
        {
            transform.localPosition = spriteDragStartPos + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPos);

        }

    }
    private void OnMouseUp()
    {
        isDragged = false;

    }

    private void Update()
    {
        if(CheckIsGrounded())
        {
            transform.position = boxCollider.transform.position;
        }
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

}
