/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    // Private variables
        // The name of the scene to load
        [SerializeField] private string m_LevelName;

    // Moves to the game scene
    public void StartGame()
    {
        SceneManager.LoadScene(m_LevelName);
    }
}
