/*
    Programmer: Manhattan Calabro
*/

using UnityEngine.UI;

public class ControllerDetectButton : ControllerDetect
{
    // Private variables
        // Reference to the button
        private Button m_Button;

    // Start is called before the first frame update
    void Start()
    {
        m_Button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        // Refresh the list
        RefreshControllerList();

        // If the button exists, check the button
        if(m_Button != null)
            CheckButton();
    }

    // Enables/disables the button
    private void CheckButton()
    {
        // If a controller is detected, enable the button
        // Otherwise, disable the button
        m_Button.interactable = m_StringList.Count > 0;
    }
}
