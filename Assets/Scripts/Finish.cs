using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private GameObject player;
    private Movement movementScript;
    public Canvas canvas;
    private UI ui;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        movementScript = player.GetComponent<Movement>();
        ui = canvas.GetComponent<UI>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        { 
            StartCoroutine(EndScreen());
        }
    }

    IEnumerator EndScreen()
    {
        movementScript.enabled = false;
        ui.ActiveEndWin();
        yield return new WaitForSeconds(5);
        ui.DesactiveEndWin();
        movementScript.enabled = true;
        SceneManager.LoadScene("Lobby");
    }
}
