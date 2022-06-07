/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

/*
    This script is exclusively made for the player UI.
    This script reads the player type text file,
    and assigns the portrait appropriately.
*/

public class UIGunIcon : ConfirmAndWrite
{
    // Private variables
        // Reference to the Sally portrait
        [SerializeField] private Sprite m_SallyPortrait;
        // Reference to the Molly portrait
        [SerializeField] private Sprite m_MollyPortrait;
        // Reference to the image
        private Image m_Image;
        // The player number
        [SerializeField] private int m_PlayerNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the image
        m_Image = GetComponent<Image>();

        // Read the file
        string str = File.ReadAllText(m_Path);

        // Assign the icon
        if(str.Contains(m_PlayerNumber.ToString() + "s"))
            m_Image.sprite = m_SallyPortrait;
        else
            m_Image.sprite = m_MollyPortrait;
    }

    // Update is called once per frame
    void Update()
    {
        // Left here in case the ConfirmAndWrite script gains a Update() method
    }
}
