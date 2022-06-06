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
    public GameObject ballStartPoint;

    public GameObject gameOverMenu;

    private void Update()
    {
        Time.timeScale = 1f;
        if (HealthManager.Instance.health <= 0)
        {
            gameOverMenu.SetActive(true);
            Time.timeScale = 0;
        }
        
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            balldog.gameObject.SetActive(false);
            dog.gameObject.SetActive(true);
            Player.transform.position = startPoint.transform.position;

            HealthManager.Instance.health--;
         

            Instantiate(ball, ballStartPoint.transform.position, Quaternion.identity);
            AudioManager.Instance.PlaySound(AudioManager.Instance.audioData.failSound);
        }
    }
}
