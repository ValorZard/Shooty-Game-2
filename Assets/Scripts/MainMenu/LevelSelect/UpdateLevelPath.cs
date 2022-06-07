/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
    This script is exclusively made for the level select screen,
    and should be attached to the level options.
    When a level option is pressed, 1) the preview image,
    2) the level's description, and 3) the start button's level path
    are updated.
*/

public class UpdateLevelPath : MonoBehaviour
{
    // Private variables
        // The preview image to update
        [SerializeField] private Image m_PreviewImage;
        // The new image
        [SerializeField] private Sprite m_Sprite;
        // The description to update
        [SerializeField] private TextMeshProUGUI m_DescriptionObject;
        // The new description
        [SerializeField] private string m_DescriptionMessage;
        // The start button to update
        [SerializeField] private Button m_StartButton;
        // Reference to the button's start script
        private StartScript m_StartScript;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the start script
        m_StartScript = GetComponent<StartScript>();
    }

    // Updates everything when called
    public void UpdateSelection()
    {
        // Update the preview image
        m_PreviewImage.sprite = m_Sprite;

        // Update the description
        m_DescriptionObject.text = m_DescriptionMessage;

        // Update the start button's level path
        m_StartButton.GetComponent<StartScript>().SetLevelName(m_StartScript.GetLevelName());
    }
}
