using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnblock : MonoBehaviour
{
    public GameObject[] block;
    
    // Start is called before the first frame update
    void Start()
    {
        NewBlock();
        
    }

    public void NewBlock(){
        Instantiate(block[Random.Range(0,block.Length)],transform.position,(Quaternion.identity));
    }
    
}
