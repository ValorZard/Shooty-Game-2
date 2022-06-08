/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

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
        // Only run if the level name exists
        if(m_LevelName != "")
            SceneManager.LoadScene(m_LevelName);
    }

    // Moves to the game scene using the player number
    public void StartWithNumber()
    {
        // Only run if the level name exists
        if(m_LevelName == "DialogSample")
            SceneManager.LoadScene(m_LevelName);
        else if(m_LevelName != "")
            SceneManager.LoadScene(m_LevelName + File.ReadAllText(m_Path));
    }

    // Reloads the current scene
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public string GetLevelName() { return m_LevelName; }
    public void SetLevelName(string str) { m_LevelName = str; }
}
