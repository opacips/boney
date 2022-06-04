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
            transform.localPosition=spriteDragStartPos+(Camera.main.ScreenToWorldPoint(Input.mousePosition)-mouseDragStartPos);
            Debug.Log(Input.mousePosition);
        }
    }
    private void OnMouseUp()
    {
        isDragged = false;

    }

}

