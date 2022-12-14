using static System.Console;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

public class vehicle
{

  private int shielding;
  

  public int GetShield(){
    return shielding;
  }

  public void SetShield(int shield)
  {

    shielding = shielding + shield;
    if(shielding > 100)
    {
        shielding = 100;
    }
  }

  public void ShieldCraft(int wood, int iron, int amount){

    int verificationW = 40 * amount;
    int verificationI = 15 * amount;

    if(wood == verificationW && iron == verificationI){
      
      SetShield(25 * amount);
      WriteLine("Você conseguiu arrumar a armadura do seu carro");
      ReadLine();
    }
    if(wood < verificationW){
      
      WriteLine("Você não tem madeira o suficiente!");
      ReadLine();
      
    }
    if(iron < verificationI){

      WriteLine("Você não tem ferro o suficiente!");
      ReadLine();
      
    }
    if(shielding == 100)
    {
            WriteLine("Não é possivel realizar mais melhorias");
            ReadLine();
    }
  }

  public vehicle()
  {
    shielding = 0;
  }
}