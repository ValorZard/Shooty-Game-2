/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;
using System.IO;

/*
    This script is exclusively made to be played at the beginning of
    start-up, though can technically be played at any time without issue.
    Directories are created for text file searches, since the build of
    the game doesn't already include these directories.
*/

public class CreateFolders : MonoBehaviour
{
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
        
        // Create the files if they don't exist
        if(!File.Exists("Assets/Resources/LevelsUnlocked.txt"))
            File.Create("Assets/Resources/LevelsUnlocked.txt");
    }
}
