/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossTracker : MonoBehaviour
{
    // Private variables
        // Reference to the boss
        private GameObject m_Boss;

    // Update is called once per frame
    void Update()
    {
        // If the boss is dead...
        if(!m_Boss.activeSelf)
            // ... the player has won; move to the win screen
            SceneManager.LoadScene("WinScene");
    }

    public void SetBoss(GameObject obj) { m_Boss = obj; }
}
