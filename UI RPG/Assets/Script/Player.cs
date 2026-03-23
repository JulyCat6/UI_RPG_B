using UnityEngine;

public class Player : Charachter
{
    [SerializeField] private Weapon[] weapons;
    [SerializeField] private Weapon activeWeapon;

    public string ActiveWeaponName
    {
        get { return activeWeapon.weaponName; }
    }
    private int selectedWeaponID = 0;
    
    public override void Attack(Charachter toHit)
    {
        toHit.TakeDamage(activeWeapon);
        //float damage = activeWeapon.GetDamage();
        //toHit.TakeDamage(damage);
    }

    public void SwitchWeapon()
    {
        selectedWeaponID = (++selectedWeaponID) % weapons.Length;
        activeWeapon = weapons[selectedWeaponID];
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
