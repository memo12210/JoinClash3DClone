using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuWindow : MonoBehaviour
{
    void Awake()
    {
        Time.timeScale = 0;
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Mehmet");
    }


}
