/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    // Public variables
        // The name of the scene to load
        public string m_LevelName;

    // Moves to the game scene
    public void StartGame()
    {
        SceneManager.LoadScene(m_LevelName);
    }
}
