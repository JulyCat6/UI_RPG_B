using UnityEngine;

public class MagicSphere : Weapon
{
    [SerializeField] private float damage = 6f;

    public override float GetDamage()
    {
        return damage;
    }
}
