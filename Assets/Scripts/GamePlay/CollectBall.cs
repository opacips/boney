using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBall : MonoBehaviour
{
//    public GameObject player;
    public bool hasBall = false;
    public GameObject dog;
    public GameObject balldog;

    void Start()
    {
        dog.gameObject.SetActive(true);
        balldog.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("intrigger");
        if (other.gameObject.CompareTag("ball"))
        {
            Destroy(other.gameObject);
            hasBall = true;
            dog.gameObject.SetActive(false);
            balldog.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
