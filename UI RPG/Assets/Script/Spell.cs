using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private Player player;
    
    public int turnCounter = 0;
    public bool ready = false;

    public void EndTurn()
    {
        if (ready) return;
        turnCounter++;

        if (turnCounter >= 3)
        {
            ready = true;
        }
    }

    public void Activate()
    {
        if (!ready) return;

        player.health += 5f;
        ready = false;
        turnCounter = 0;
    }
    

    public void Buff()
    {
        player.health += 3f;
        Debug.Log("Buff active");
    }

    public void RestartHeal()
    { 
        turnCounter = 0; 
        ready = false;
    }
}
