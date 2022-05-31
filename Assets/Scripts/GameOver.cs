using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject randomSpawn;
    private bool gameOver;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "figure")
        {
            gameOver = true;
        }
        if (gameOver)
        {
            gameOverCanvas.SetActive(true);
            randomSpawn.SetActive(false);
        }
    }

}
