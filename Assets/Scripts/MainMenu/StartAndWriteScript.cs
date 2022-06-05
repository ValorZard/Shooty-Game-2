/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;
using System.IO;

public class StartAndWriteScript : StartScript
{
    // Private variables
        // The text to write
        [SerializeField] private string m_Text;

    // Start is called before the first frame update
    void Start()
    {
        // Create the directories if they don't exist
        if(!Directory.Exists("Assets"))
            Directory.CreateDirectory("Assets");
        if(!Directory.Exists("Assets/Resources"))
            Directory.CreateDirectory("Assets/Resources");
        if(!Directory.Exists("Assets/Dialogue"))
            Directory.CreateDirectory("Assets/Dialogue");
    }

    // Start is called before the first frame update
    public void StartAndWrite()
    {
        // Write the text
        File.WriteAllText(m_Path, m_Text);

        // Move to the next scene
        StartGame();
    }

    public string GetText() { return m_Text; }
}
