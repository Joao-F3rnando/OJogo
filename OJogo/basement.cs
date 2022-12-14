using System;

public class basement
{
    private int ammuNition;
    private int food;
    private int water;
    private int firstAid;
    private int wood;
    private int iron;

    public int GetAmmu()
    {

        return ammuNition;

    }

    public int GetFood()
    {

        return food;

    }

    public int GetWater()
    {

        return water;

    }

    public int GetFirstAid()
    {

        return firstAid;

    }

    public int GetWood()
    {

        return wood;

    }

    public int GetIron()
    {

        return iron;

    }

    public void SetAmmu (int bullets)
    {

        ammuNition = ammuNition + bullets;

        if(ammuNition < 0)
        {
            ammuNition = 0;
        }

    }

    public void SetFood(int can)
    {
        if(can >= 4 && can < 8)
        {
            food++;
        }
        else if(can >= 8)
        {
            food = food + 2;
        }
        else if(can < 0)
        {
            food = food + can;
        }
    }

    public void SetWater(int bottle)
    {
        if(bottle >= 4 && bottle < 8)
        {
            water++;
        }
        else if(bottle >= 8)
        {
            water = water + 2;
        }
        else if(bottle < 0)
        {
            water = water + bottle;
        }
    }

    public void SetFirstAid(int cure)
    {
        if(cure >= 5 && cure <8)
        {
            firstAid++;
        }
        else if(cure >= 8)
        {
            firstAid = firstAid + 2;
        }
        else if(cure < 0)
        {
            firstAid = firstAid + cure;
        }
    }

    public void SetWood(int diewood)
    {

        wood = wood + diewood;

    }

    public void SetIron(int steel)
    {

        iron = iron + steel;

    }

    public int sendWood(int diewood)
    {
        if(diewood < wood)
        {
            SetWood(-diewood);
            return diewood;
        }
        else
        {
            return 0;
        }
    }

    public int sendIron(int steel)
    {
        if(steel < iron)
        {
            SetIron(-steel);
            return steel;
        }
        else
        {
            return 0;
        }
    }

    public basement()
    {

        ammuNition = 7;
        food = 3;
        water = 3;
        firstAid = 1;
        wood = 0;
        iron = 0;

    }
}