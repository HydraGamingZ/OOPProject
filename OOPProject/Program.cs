using System;
using System.Collections.Generic;
namespace rpg
    
{
    public class Character
    {
        public string Name{get;set;}
        public int Level{get;set;}
        public int MaxHealth{get;set;}
        public int Health{get;set;}
        public int Attack{get;set;}
        public int Defense{get;set;}
        public int Speed{get;set;}
        public string Skills{get;set;}
        public string Description{get;set;}
        public string UltimateSkill{get;set;}
        public string PassiveSkill{get; set;}
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public List<Item> Inventory { get; set; }
        public int Experience { get; set; }
        public int ExperienceToNextLevel { get; set; } = 100;
        public int Gold { get; set; }





        public Character(string name, int level, int maxhealth, int health, int attack, int defense, int speed, string skills, string description, string ultimateSkill, string passiveSkill)
        {
            Name = name;
            Level = level;
            MaxHealth = maxhealth;
            Health = health;
            Attack = attack;
            Defense = defense;
            Speed = speed;
            Skills = skills;
            Description = description;
            UltimateSkill = ultimateSkill;
            PassiveSkill = passiveSkill;
            Inventory = new List<Item>();
            Experience = 0;
            Gold = 0;
        }

    public bool IsAlive()
    {
        return Health > 0;
    }

    public bool IsDead()
    {
        return Health <= 0;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0)
        {
            Health = 0;
        }
        
    }

    public void Heal(int amount)
    {
        Health += amount;
        if (Health > MaxHealth)
        {
            Health = maxHealth;
        }
    }

    public void LevelUp()
    {
        Level++;
        maxHealth += 10;
        Health = maxHealth;
        Attack += 2;
        Defense += 2;
        Speed += 1;
    }


public void GainExperience(int exp)
{
    Experience += exp;

    while (Experience >= ExperienceToNextLevel)
    {
        Experience -= ExperienceToNextLevel;
        LevelUp();
        ExperienceToNextLevel += 50;
    }
}

public void EquipWeapon(Weapon weapon)
{
    if (EquippedWeapon != null)
        Attack -= EquippedWeapon.AttackBonus;

    EquippedWeapon = weapon;
    Attack += weapon.AttackBonus;
}

public void EquipArmor(Armor armor)
{
    if (EquippedArmor != null)
        Defense -= EquippedArmor.DefenseBonus;

    EquippedArmor = armor;
    Defense += armor.DefenseBonus;
}

public void AddItem(Item item)
{
    Inventory.Add(item);
}

public void RemoveItem(Item item)
{
    Inventory.Remove(item);
}
public void ShowInventory()
{
    Console.WriteLine("===== Inventory =====");

    if (Inventory.Count == 0)
    {
        Console.WriteLine("Inventory is empty.");
        return;
    }

    foreach (Item item in Inventory)
    {
        Console.WriteLine("- " + item.Name);
    }
}

public void EarnGold(int amount)
{
    Gold += amount;
}

public void SpendGold(int amount)
{
    if (Gold >= amount)
        Gold -= amount;
}
    }


public class Weapon
{
    public string Name { get; set; }
    public int AttackBonus { get; set; }

    public Weapon(string name, int attackBonus)
    {
        Name = name;
        AttackBonus = attackBonus;
    }
}


public class Armor
{
    public string Name { get; set; }
    public int DefenseBonus { get; set; }

    public Armor(string name, int defenseBonus)
    {
        Name = name;
        DefenseBonus = defenseBonus;
    }
}


public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Item(string name, string description)
    {
        Name = name;
        Description = description;
    }
}



public class Potion : Item
{
    public int HealAmount { get; set; }

    public Potion(string name, string description, int healAmount)
        : base(name, description)
    {
        HealAmount = healAmount;
    }

    public void Use(Character character)
    {
        character.Heal(HealAmount);
    }
}

    

    
}
