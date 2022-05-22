/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;
using TMPro;

abstract public class UIBaseText : MonoBehaviour
{
    // Protected variables
        // The starting (max) value
        protected float m_StartingValue;
        // The current value
        protected float m_CurrentValue;
        // The text
        protected TextMeshProUGUI m_Text;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the children text
        m_Text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the values
        UpdateValues();
    }

    // Update the display
    protected void UpdateDisplay()
    {
        m_Text.text = m_CurrentValue.ToString() + "/" + m_StartingValue.ToString();
    }

    // Update the text
    abstract protected void UpdateValues();
}
