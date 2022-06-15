/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

/*
    This script is to be applied to exit teleporters in levels
    that have to be unlocked to play in the level select screen.
    If the object this script is attached to is touched,
    then the current level is unlocked.
*/

public class LevelUnlockCollide : LevelLock
{
    // Private variables
        // The level to unlock
        private string m_LevelName;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the level name
        //m_LevelName = SceneManager.GetActiveScene().name;
        m_LevelName = GetComponent<StartScript>().GetLevelName();

        // Remove the number if it's there
        if(m_LevelName.Contains("1"))
            m_LevelName = m_LevelName.Substring(0, m_LevelName.Length - 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If touched by a player...
        if(other.CompareTag("Player")
            && other.GetComponent<ShieldTag>() == null
            && other.GetComponent<BulletHit>() == null)
        {
            // If the level isn't unlocked yet...
            if(!File.ReadAllText(m_Path).Contains(m_LevelName))
            {
                File.AppendAllText(m_Path, m_LevelName + "\n");
            }
        }
    }
}
