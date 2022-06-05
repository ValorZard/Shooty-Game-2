/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;
using TMPro;

/*
    Concatenates the text with the stats from the given prefab.
    This means that the prefabs can be updated without also
    having to manually update the text.
*/

public class CharacterInfoUpdate : MonoBehaviour
{
    // Private variables
        // Reference to the prefab
        [SerializeField] private GameObject m_Prefab;
        // Reference to the text
        private TextMeshProUGUI m_Text;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the text
        m_Text = GetComponent<TextMeshProUGUI>();

        // Only run if the text exists
        if(m_Text != null)
        {
            // Concatenate the health
            BaseHealthScript health = m_Prefab.GetComponentInChildren<BaseHealthScript>();
            m_Text.text += "\n* Health: " + health.GetStartingHealth();

            // Concatenate the ammo
            AmmoManager ammo = m_Prefab.GetComponentInChildren<AmmoManager>();
            m_Text.text += "\n* Ammo: " + ammo.GetMaxAmmo();

            // Concatenate the damage
            PlayerShooting damage = m_Prefab.GetComponentInChildren<PlayerShooting>();
            m_Text.text += "\n* Damage: " + damage.GetDamage();

            // Concatenate the movement speed
            PlayerController speed = m_Prefab.GetComponentInChildren<PlayerController>();
            m_Text.text += "\n* Speed: " + speed.GetMoveSpeed();
        }
    }
}
