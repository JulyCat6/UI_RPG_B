using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private GameObject shieldButton;
    
    public int charge = 0;
    private bool active = false;
    public bool ready = false;
    
    //private float shieldHP = 5f;

    private int turnsLeft = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    public void Charge(float damage)
    {
        if (ready) return;
        
        charge += Mathf.RoundToInt(damage);

        if (charge >= 10)
        {
            charge = 10;
            ready = true;
        }
    }

    public void Activate()
    {
        if (!ready) return;
        
        active = true;
        ready = false;
        charge = 0;
        
        //shieldHP = 5f;
        turnsLeft = 2;
    }

    public float BlockDamage(float damage)
    {
        if (!active) return damage;

        //if (damage <= shieldHP)
        //{
           // shieldHP -= damage;
           // return 0;
        //}
        //else
        //{
            //float remaining = damage - shieldHP;
            //shieldHP = 0;
            
            //return remaining;
        //}
        return 0;
    }
    
    public void RestartShield()
    {
        charge = 0;
        ready = false;
        active =  false;
        //shieldHP = 5f;
    }

    public void EndTurn()
    {
        if (!active) return;

        turnsLeft--;

        if (turnsLeft <= 0)
        {
            active = false;
        }

        //if (shieldHP <= 0)
        //{
            //active = false;
        //}
        
        Debug.Log("Shield turns left: " + turnsLeft);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
