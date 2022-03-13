/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;

public class CharacterPan : MonoBehaviour
{
    // Private variables
        // Reference to the RectTransform of the characters
        private RectTransform m_Rect;
        // Time to pan (please for the love of god don't change this; I don't remember how logarithms work)
        private float m_MaxTime = 1f;
        // Current time panning
        private float m_CurrentTime;
        // Exponent
        [SerializeField] private float m_Exp;

    // Start is called before the first frame update
    void Start()
    {
        m_Rect = GetComponent<RectTransform>();
        m_CurrentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // The offset
        float offset = Mathf.Log(Mathf.Pow(m_CurrentTime, m_Exp));

        // Change the offset
        if(m_CurrentTime != 0 && !float.IsNaN(offset))
        {
            m_Rect.offsetMin = new Vector2(offset, m_Rect.offsetMin.y);
            m_Rect.offsetMax = new Vector2(-offset, m_Rect.offsetMax.y);
        }

        // Increment the time
        m_CurrentTime = Mathf.Min(m_CurrentTime + Time.deltaTime, m_MaxTime);
    }
}
