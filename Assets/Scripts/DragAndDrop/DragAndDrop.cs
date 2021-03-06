using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public bool dragging = false;
    public bool canDrag;
    [SerializeField] private Rigidbody2D blockRB;
    [SerializeField] private Collider2D blockCollider;

    private void Start()
    {
        canDrag = true;
    }

    void Update()
    {

        CheckForClicks();

        if (this.dragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 position = new Vector3(mousePosition.x, mousePosition.y, 1);
            transform.position = position;
        }
    }

    private void CheckForClicks()
    {
        
        //if left click down
        if (Input.GetMouseButtonDown(0) && canDrag)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {

                    this.dragging = true;
                    
                   
                }
            }
        }
        //if left click up
        else if (Input.GetMouseButtonUp(0))
        {
            blockRB.constraints = RigidbodyConstraints2D.FreezeAll;
            blockRB.mass = 100f;
            canDrag = false;
            if (this.dragging)
            {
                this.dragging = false;
                
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);

        if (collision.gameObject != gameObject)
        {
            this.dragging = false;
        }
    }
}
