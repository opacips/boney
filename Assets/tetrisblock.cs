using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetrisblock : MonoBehaviour
{
    public Vector3 rotPoint;
    private float previTime;
    public float FallTime=0.8f;
    public static int Height= 40;
    public static int Width =25;
    private static Transform[,] grid= new Transform[Width,Height];
   
    
   
    
    void Start()
    {
     
    }
    

    
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.LeftArrow)){

            transform.position += new Vector3(-1,0,0);
            if(!ValMove()){
                transform.position -= new Vector3(-1,0,0);
            }
              
            
                
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow)){
            transform.position += new Vector3(1,0,0);
            if(!ValMove())
                transform.position -= new Vector3(1,0,0);
            
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow)){
            transform.RotateAround(transform.TransformPoint(rotPoint), new Vector3(0,0,1),90);
            if(!ValMove())
               transform.RotateAround(transform.TransformPoint(rotPoint), new Vector3(0,0,1),-90);
                
        }

        if(Time.time-previTime>(Input.GetKey(KeyCode.DownArrow) ? FallTime/ 10 : FallTime)){
            transform.position += new Vector3(0,-1,0);
            previTime=Time.time;
            
            
            if(!ValMove()){
                 transform.position -= new Vector3(0,-1,0);
                 Addtogrid();
                 this.enabled=false;
                 FindObjectOfType<spawnblock>().NewBlock();
                 

            }
            
            
          
        }
        
        

    }
    
    public void Addtogrid(){
         foreach(Transform children in transform){
            int roundedX= Mathf.RoundToInt(children.transform.position.x);
            int roundedY= Mathf.RoundToInt(children.transform.position.y);
            


            grid[roundedX,roundedY]= children;
            
         }

    }
    bool ValMove(){
        foreach(Transform children in transform){
            int roundedX= Mathf.RoundToInt(children.transform.position.x);
            int roundedY= Mathf.RoundToInt(children.transform.position.y);

            if(roundedX < 0 || roundedX>=Width || roundedY <0 || roundedY>=Height){
                return false;

            }

            if(grid[roundedX,roundedY]!= null){
                return false;
            }
        }
        return true;
    }
    


}
