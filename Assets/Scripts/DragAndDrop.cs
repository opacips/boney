using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 offset;
    public LayerMask dropPointLayer;

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
        transform.GetComponentInChildren<Collider2D>().enabled = false;
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit2D hitInfo = Physics2D.Raycast(rayOrigin, rayDirection, dropPointLayer);
        if (hitInfo)
        {
            transform.position = hitInfo.collider.transform.position;
            Debug.Log("Drop Area");
            
        }
        transform.GetComponentInChildren<Collider2D>().enabled = true;
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
