using System;

public class character
{
  int health;
  int stamina;
  int hunger;
  int thrist;

  public int GetHealth()
  {
    return health;
  }

  public int GetStamina()
  {
    return stamina;
  }

  public int GetHunger()
  {
    return hunger;
  }

  public double GetThrist()
  {
    return thrist;
  }

  public void SetHealth(int life)
  {
    health  =  (health + life);

    if(health > 100)
    {
      health = 100;
    }
    else if(health < 0)
    {
            health = 0;
    }
  }

  public void SetStamina(int energy)
  {
    stamina  =  (stamina + energy);
    
    if(stamina > 100)
    {
      stamina = 100;
    }
    else if(stamina < 0)
    {
        stamina = 0;
    }
  }

  public void SetHunger(int food)
  {
    hunger  =  (hunger + food);

    if(hunger > 100)
    {
      hunger = 100;
    }
    else if(hunger < 0)
    {
      hunger = 0;
    }
  }

  public void SetThrist(int water)
  {
    thrist  =  (thrist + water);

    if(thrist > 100)
    {
      thrist = 100;
    }
    else if(thrist < 0)
    {
      thrist = 0;
    }
  }

  
  public character()
  {
    health = 100;
    stamina = 100;
    hunger = 100;
    thrist = 100;
  }
}