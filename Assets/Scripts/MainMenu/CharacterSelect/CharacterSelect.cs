/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterSelect : MonoBehaviour
{
    // Private variables
        // Reference to the first character
        [SerializeField] private GameObject m_First;
        // Reference to the second character
        [SerializeField] private GameObject m_Second;
        // Reference to the children's sprite renderers
        private SpriteRenderer[] m_Renderers;
        // Reference to the rect transform
        private RectTransform m_Rect;
        // The rect transform of the first character
        private RectTransform m_FirstRect;
        // The rect transform of the second character
        private RectTransform m_SecondRect;
        // The axis to pay attention to
        [SerializeField] private int m_PlayerNumber = 1;
        // Reference to the text
        private TextMeshProUGUI m_Text;
        // The position of the text
        [SerializeField] private float m_X;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the children
        m_Renderers = GetComponentsInChildren<SpriteRenderer>();

        // Grab the rect transforms
        m_Rect = GetComponent<RectTransform>();
        m_FirstRect = m_First.GetComponent<RectTransform>();
        m_SecondRect = m_Second.GetComponent<RectTransform>();

        // Grab the text
        m_Text = transform.parent.GetComponentInChildren<TextMeshProUGUI>();

        // Make sure the select cursor starts visible
        SetAble(true);

        // Check the player number to assign the corresponding character
        if(m_PlayerNumber == 1)
            // Change the cursor's position to the first character
            SetFirst();
        else
            // Change the cursor's position to the second character
            SetSecond();
    }

    // Update is called once per frame
    void Update()
    {
        // If the left key is tapped, highlight the first character
        if(Input.GetAxis("Horizontal" + m_PlayerNumber) < 0)
        {
            // Make sure the cursor is visible
            SetAble(true);

            // Change the cursor's position
            SetFirst();
        }

        // Otherwise, if the right key is tapped, highlight the second character
        else if(Input.GetAxis("Horizontal" + m_PlayerNumber) > 0)
        {
            // Make sure the cursor is visible
            SetAble(true);

            // Change the cursor's position
            SetSecond();
        }
    }

    // Enables/disables all children within the select cursor
    public void SetAble(bool b)
    {
        // Only run if the boolean and the cursor visibility are opposite
        if(m_Renderers[0].enabled != b)
            // Go through the list
            foreach(SpriteRenderer rend in m_Renderers)
                rend.enabled = b;
    }

    // Sets the cursor to the first character
    private void SetFirst()
    {
        // Change the cursor's position to the first character
        m_Rect.anchorMin = m_FirstRect.anchorMin;
        m_Rect.anchorMax = m_FirstRect.anchorMax;
        m_Rect.pivot = m_FirstRect.pivot;
        m_Text.transform.localPosition = new Vector3(-m_X,
                                                     m_Text.transform.localPosition.y,
                                                     m_Text.transform.localPosition.z);
    }

    // Sets the cursor to the second character
    private void SetSecond()
    {
        // Change the cursor's position to the second character
        m_Rect.anchorMin = m_SecondRect.anchorMin;
        m_Rect.anchorMax = m_SecondRect.anchorMax;
        m_Rect.pivot = m_SecondRect.pivot;
        m_Text.transform.localPosition = new Vector3(m_X,
                                                     m_Text.transform.localPosition.y,
                                                     m_Text.transform.localPosition.z);
    }

    public bool GetAble() { return m_Renderers[0].enabled; }
    public RectTransform GetRectTransform() { return m_Rect; }
    public int GetPlayerNumber() { return m_PlayerNumber; }
}
