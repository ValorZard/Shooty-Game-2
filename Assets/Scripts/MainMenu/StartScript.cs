/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    // Protected variables
        // The name of the scene to load
        [SerializeField] protected string m_LevelName;
        // The file path
        protected string m_Path = "Assets/Resources/PlayerNumber.txt";

    // Moves to the game scene
    public void StartGame()
    {
        SceneManager.LoadScene(m_LevelName);
    }
}
