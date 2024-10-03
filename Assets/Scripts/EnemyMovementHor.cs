using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovementHor : MonoBehaviour
{
    private bool direction;          // La direction du GO est définit par true : se déplace vers la droite, false : se déplace vers la gauche
    private Rigidbody2D rb;
    private float speed = 1f;
    public Canvas canvas;
    private UI ui;
    private Movement playerMovement;

    private void Start()
    {
        playerMovement = GameObject.FindWithTag("Player").GetComponent<Movement>();
        ui = canvas.GetComponent<UI>();
        rb = GetComponent<Rigidbody2D>();
        direction = true;
        rb.velocity = new Vector2(1, 0) * speed;
    }

    void Update()
    {
        if (rb.velocity == Vector2.zero)
        {
            return;
        }
        if (direction)
        {
            rb.velocity = new Vector2(1, 0) * speed;
        } else
        {
            rb.velocity = new Vector2(-1, 0) * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            if (direction == true) 
            {
                direction = false;
            } else
            {
                direction = true;
            }
        } else if (collision.tag == "Player")
        {
            StartCoroutine(EndLose());
        }
    }

    IEnumerator EndLose()
    {
        rb.velocity = new Vector2(0, 0);
        playerMovement.enabled = false;
        ui.ActiveEndLose();
        yield return new WaitForSeconds(3);
        ui.DesactiveEndLose();
        playerMovement.enabled = false;
        SceneManager.LoadScene("Lobby");
    }
}
