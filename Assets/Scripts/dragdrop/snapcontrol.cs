using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapcontrol : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<draggable> draggableObjects;
    public float snapRange=0.5f;
    // Start is called before the first frame update
    void Start()
    {
        foreach(draggable draggable in draggableObjects ){
            draggable.DragEndedCallback=OnDragEnded;
        }
    }

    private void OnDragEnded(draggable draggable ){
        float closestDistance=-1;
        Transform closestSnapPoint=null;

        foreach(Transform snapPoint in snapPoints){
            float currentDistance=Vector2.Distance(draggable.transform.localPosition,snapPoint.localPosition);
            if(closestSnapPoint==null || currentDistance<closestDistance ){
                closestSnapPoint=snapPoint;
                closestDistance=currentDistance;

            }
        }

        if(closestSnapPoint != null && closestDistance<=snapRange){
            draggable.transform.localPosition=closestSnapPoint.localPosition;
        }

    }
}
