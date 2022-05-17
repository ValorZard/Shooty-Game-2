/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;
using UnityEngine.UI;

public class RotationSprite : RotationObjectBase<Sprite>
{
    // Private variables
        // Reference to the image
        private Image m_Renderer;

    protected override void Fetch()
    {
        m_Renderer = GetComponent<Image>();
    }

    protected override void BeforeIndex()
    {
        // If the index is even...
        if(index % 2 == 0)
            // ... flip the X axis
            m_Renderer.rectTransform.localScale = new Vector3(-m_Renderer.rectTransform.localScale.x,
                                                                m_Renderer.rectTransform.localScale.y,
                                                                m_Renderer.rectTransform.localScale.z);
    }

    protected override void AfterIndex()
    {
        // Move to the next sprite
        m_Renderer.sprite = m_List[index];
    }
}
