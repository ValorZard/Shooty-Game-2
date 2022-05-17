/*
    Programmer: Manhattan Calabro
*/

using TMPro;

public class ControllerDetectTMP : ControllerDetect
{
    // Private variables
        // Reference to the text
        private TextMeshProUGUI m_TMP;
    
    // Start is called before the first frame update
    void Start()
    {
        m_TMP = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Refresh the list
        RefreshControllerList();

        // If the text exists, check the text
        if(m_TMP != null)
            CheckText();
    }

    // Enables/disables the text
    private void CheckText()
    {
        // If a controller is detected, hide the warning text
        // Otherwise, show the warning text
        m_TMP.enabled = !(m_StringList.Count > 0);
    }
}
