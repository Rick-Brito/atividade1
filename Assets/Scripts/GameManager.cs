using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]private Ball player;
    [SerializeField]private CameraFollow cameraFollow;
    [SerializeField]private GameObject gameOverScreen; 

    // Update is called once per frame
    void Update()
    {
        DetectDeath();
    }

    void DetectDeath()
    {
        if (player.lives == 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {  
       cameraFollow.enabled = false;
       gameOverScreen.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
