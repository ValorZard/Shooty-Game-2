/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;
using UnityEngine.UI;

public class IndexElement : MonoBehaviour
{
    // Private variables
        // Reference to a prefab
        [SerializeField] private GameObject m_Prefab;

    // Start is called before the first frame update
    void Start()
    {
        // Set the icon to the prefab's sprite
        GetComponentInChildren<Image>().sprite = m_Prefab.GetComponent<SpriteRenderer>().sprite;

        // Use the same color as the prefab's sprite
        GetComponentInChildren<Image>().color = m_Prefab.GetComponent<SpriteRenderer>().color;
    }
}
