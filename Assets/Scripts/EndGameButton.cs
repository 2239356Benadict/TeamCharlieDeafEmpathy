using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameButton : MonoBehaviour
{
    public void EndGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); 
        Application.Quit();
    }

}
