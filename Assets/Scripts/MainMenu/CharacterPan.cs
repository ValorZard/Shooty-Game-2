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
        // Exponent to use (EXP ONLY)
        [SerializeField] private float m_Exp;
        // Time to pan (LINEAR ONLY)
        [SerializeField] private float m_PanTime;
        // Original offset x (LINEAR ONLY)
        private float m_OffsetX;

    // Start is called before the first frame update
    void Start()
    {
        m_Rect = GetComponent<RectTransform>();
        m_CurrentTime = 0f;
        m_OffsetX = m_Rect.offsetMax.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Pan the characters
        LinearPan();

        // Increment the time
        m_CurrentTime = Mathf.Min(m_CurrentTime + Time.deltaTime, m_MaxTime);
    }

    private void ExpPan()
    {
        // The offset
        float offset = Mathf.Log(Mathf.Pow(m_CurrentTime, m_Exp));

        // Only run if it's possible
        if(m_CurrentTime != 0 && !float.IsNaN(offset))
        {
            Pan(offset);
        }
    }

    private void LinearPan()
    {
        // The offset
        float offset = m_OffsetX * m_CurrentTime - m_OffsetX;

        Pan(offset);
    }

    private void Pan(float offset)
    {
        // Change the offset
        m_Rect.offsetMin = new Vector2(offset, m_Rect.offsetMin.y);
        m_Rect.offsetMax = new Vector2(-offset, m_Rect.offsetMax.y);
    }
}
