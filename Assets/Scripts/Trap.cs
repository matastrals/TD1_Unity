using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private SpriteRenderer playerSr;
    private Movement playerMovement;
    private SpriteRenderer sr;
    private void Start()
    {
        playerSr = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
        playerMovement = GameObject.FindWithTag("Player").GetComponent<Movement>();
        sr = GetComponent<SpriteRenderer>();
        Color color = sr.color;
        color.a = 0f;
        sr.color = color;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Color color = sr.color;
            color.a = 1f;
            sr.color = color;
            StartCoroutine(ChangeSpeed());
        }
    }

    IEnumerator ChangeSpeed()
    {
        playerMovement.SetSpeed(0.5f);
        playerSr.color = Color.red;
        yield return new WaitForSeconds(3);
        playerMovement.SetSpeed(2f);
        playerSr.color = Color.white;
        gameObject.SetActive(false);
    }
}
