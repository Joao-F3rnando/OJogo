using System;

public class theEnd
{
    private bool fim1; //Final morte
    private bool fim2; //Final preso
    private bool fim3; //Final fuga

    public void SetFinal(string finais)
    {
        if (finais == "final1")
        {

            fim1 = true;

        }
        else if (finais == "final2")
        {

            fim2 = true;

        }
        else if (finais == "final3")
        {

            fim3 = true;

        }
    }

    public int GetFinal()
    {
        int i = -1;
        if(fim1 == true)
        {
            i = 0;
        }
        else if(fim2 == true)
        {
            i = 1;
        }
        else if(fim3 == true)
        {
            i = 2;
        }
        return i;
    }
    public theEnd()
    {
        fim1 = false;
        fim2 = false;
        fim3 = false;
    }
}