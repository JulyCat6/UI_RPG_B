using UnityEngine;

public class Sword : Weapon
{
    // SWORD
    [SerializeField] private float minDamage , maxDamage;

    public override float GetDamage()
    {
        return Random.Range(minDamage, maxDamage);
    }
}
