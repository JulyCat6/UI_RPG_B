using UnityEngine;

public class Player : Charachter
{
    [SerializeField] private Weapon[] weapons; // weapon massive. weapon in inspector
    [SerializeField] private Weapon activeWeapon; // active weapon. weapon in the moment

    public string ActiveWeaponName // atļauja to show weapon in UI
    {
        get { return activeWeapon.weaponName; }
    }
    private int selectedWeaponID = 0;
    
    public override void Attack(Charachter toHit) // override = player pašs izvēlas ka attack -> caur activeweapon
    {
        animator.SetTrigger("attack");
        //float damage = activeWeapon.GetDamage();
        //toHit.TakeDamage(damage);

        if (animator != null)
        {
            animator.SetTrigger("attack");
        }
        toHit.TakeDamage(activeWeapon);
    }

    public void SwitchWeapon()
    {
        selectedWeaponID = (++selectedWeaponID) % weapons.Length; // ++ weaponID,  % weapons.Length = weapon izvēlas pa apli
        activeWeapon = weapons[selectedWeaponID]; //chose new weapon
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activeWeapon = weapons[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
