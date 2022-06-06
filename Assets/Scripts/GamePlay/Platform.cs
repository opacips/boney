using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool buttonIsPushed = false;
    [SerializeField] Sprite button;
    [SerializeField] Sprite pushedButton;
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject platform;
    private SpriteRenderer spriteR;
    
    void Start()
    {
        spriteR = buttons.GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            buttonIsPushed = true;
            spriteR.sprite = pushedButton;
            platform.transform.Translate(Time.deltaTime*+10,0,0,Space.Self);
            Debug.Log(Time.deltaTime);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            buttonIsPushed = false;
            spriteR.sprite = button;
        }
    }
}
