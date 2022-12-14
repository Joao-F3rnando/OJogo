using System;

public class enemy
{

    public int damage;
    public int life;

    public int GetDamage()
    {

        return damage;

    }

    public int GetLife()
    {

        return life;

    }

    public void SetLife(int injury)
    {
        life = life - injury;
    }

}