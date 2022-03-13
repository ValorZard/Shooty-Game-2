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
    public void StartAndWrite()
    {
        // Write the text
        File.WriteAllText(m_Path, m_Text);

        // Move to the next scene
        StartGame();
    }
}
