/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;

public class RotationPosition : RotationObjectBase<Vector3>
{
    protected override void Fetch()
    {
        transform.localPosition = m_List[index];
    }

    protected override void BeforeIndex(){}

    protected override void AfterIndex()
    {
        transform.localPosition = m_List[index];
    }
}
