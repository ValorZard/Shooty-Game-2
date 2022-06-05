/*
    Programmer: Manhattan Calabro
*/

using UnityEngine;

public class DamageBase : MonoBehaviour
{
    // Protected variables
        // The amount of damage done if hit
        [SerializeField] protected float m_Damage;
        // The tag of friends to NOT hurt
        [SerializeField] protected string m_Friend;
        // The tag of enemies to hurt
        [SerializeField] protected string m_Enemy;

    // Deals damage to a target
    protected void DealDamage(Collider2D target)
    {
        // The shield of the target
        ShieldTag shield = target.GetComponentInChildren<ShieldTag>();

        // If the shield exists AND is active AND isn't surface-level...
        if(shield != null
            && shield.gameObject.activeSelf
            && target.GetComponent<ShieldTag>() == null)
        {
            // ... don't do harm (the shield will be detected another time)
        }

        // Damage the shield / shieldless entity
        else
        {
            // Grab the target's health script
            BaseHealthScript health = target.GetComponent<BaseHealthScript>();

            // Deal damage to the target
            health.TakeDamage(m_Damage);
        }
    }

    public float GetDamage() { return m_Damage; }
    public void SetDamage(float num) { m_Damage = num; }
    public string GetFriend() { return m_Friend; }
    public void SetFriend(string str) { m_Friend = str; }
    public string GetEnemy() { return m_Enemy; }
    public void SetEnemy(string str) { m_Enemy = str; }
}
