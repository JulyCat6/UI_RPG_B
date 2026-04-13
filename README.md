# UI_RPG_B

This project was developed as a learning assignment in Unity to demonstrate the four main principles of Object-Oriented Programming (OOP): inheritance, encapsulation, polymorphism, and abstraction.
The game is a UI-based RPG combat system where the player fights against different enemies. On the screen, the player’s and the enemy’s statistics are displayed (HP, weapons, Shield Appears).
If an enemy dies, a new enemy is automatically created and the fight continues. If the player dies, the game ends.

# OOP Principles

  1 Inheritance
  
The project uses a class hierarchy that allows reuse of common functionality.
The base class Charachter is inherited by: 

    Player
    Enemy 
    
These classes share common properties such as:

    health
    charName
    TakeDamage()

Inheritance is also used in the weapon system.
The abstract class Weapon is the base for the following weapons:

    Sword
    MagicSphere
    PoisenWeapon

 2 Encapsulation
 
Data access is controlled using private variables and properties.
Example:

    [SerializeField] private string charName;
    public string CharName
    {
      get { return charName; }
    }
The variable charName is private but can be accessed using a getter method.

A getter and setter are also used:

    public EnemyType Type
    {
      get { return enemyType; }
      set { enemyType = value; }
    }
This allows changing the enemy type in a controlled way.

  3 Polymorphism
  
The project uses both override and overload.

  Override
  
In the base class Charachter, the method Attack() is abstract:

    public abstract void Attack(Charachter toHit);

It is overridden in:

    Player
    Enemy
Each class implements its own attack behavior.

  Overload
The Charachter class contains two versions of the TakeDamage() method:

    public void TakeDamage(float damage)
    public void TakeDamage(Weapon weapon)
The second method calculates the damage based on the weapon.

  4 Abstraction
  
An abstract class Weapon is created to define the general structure of weapons.
It contains:

  a regular method:
  
      public virtual void AttackSound() // Sound was not implemented.
  and an abstract method:
  
    public abstract float GetDamage();
Each weapon defines its own damage calculation logic.

# Implemented Additional Features
Several additional features were implemented in the project.
  
    Shield System
The player can charge a shield.
When it is fully charged, it can be activated to block incoming damage for a certain number of turns.

  3 Enemy Types
The game includes three types of enemies:

     Duck
    Slime
    Skeleton
Each enemy has a different damage range and animations.

  3 Weapon Types
The player can switch between three weapons:

    Sword
    MagicSphere
    PoisenWeapon
Each weapon has a unique damage calculation method.

    Spells (Healing)
The player has access to a healing spell that becomes available after a certain number of turns.
It restores the player’s health points.

  Animations
Enemy animations:

    Idle
    Attack
    Hit
    Death

Player animations:

    Idle
    Attack
Animations are triggered using the Animator Trigger system in scripts.
