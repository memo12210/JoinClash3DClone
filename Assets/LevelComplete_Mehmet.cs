using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete_Mehmet : MonoBehaviour
{
    public void NextLeveButton()
    {
        SceneManager.LoadScene("Level2");
    }
}
