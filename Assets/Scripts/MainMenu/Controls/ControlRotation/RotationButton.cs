/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;
using UnityEngine.UI;

public class RotationButton : RotationObjectBase<Button>
{
    protected override void Fetch()
    {
        // Make the color of the first button "pressed"
        m_List[index].GetComponent<Image>().color = Color.grey;
    }

    // Revert the previous button's colour
    protected override void BeforeIndex()
    {
        m_List[index].GetComponent<Image>().color = Color.white;
    }

    // Color the new button
    protected override void AfterIndex()
    {
        m_List[index].GetComponent<Image>().color = Color.grey;
    }
}