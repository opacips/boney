using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject Player;
    public GameObject dog;
    public GameObject balldog;
    public GameObject ball;
    //private Vector3 ballStartPoint;
    public GameObject ballStartPoint;


    public Image[] hearts;

    private void Start()
    {
        //ballStartPoint = ball.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            balldog.gameObject.SetActive(false);
            dog.gameObject.SetActive(true);
            Player.transform.position = startPoint.transform.position;
            Instantiate(ball, ballStartPoint.transform.position, Quaternion.identity);
            AudioManager.Instance.PlaySound(AudioManager.Instance.audioData.failSound);
        }
    }
}
