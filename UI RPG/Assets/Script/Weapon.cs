using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float minDamage, maxDamage;
    public string weaponName;

    public virtual float GetDamage()
    {
        return Random.Range(minDamage, maxDamage);
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
