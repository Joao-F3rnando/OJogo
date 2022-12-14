using static System.Console;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        opening();

        string game = "MENU";
        while (game == "MENU")
        {
            int start = menu();

            switch (start)
            {
                case 0:
                    game = "RODANDO";
                    break;
                case 1:
                    Clear();
                    instrucoes();
                    break;
                case 2:
                    Clear();
                    criadores();
                    break;
            }
        }
        Clear();
        WriteLine(@"
               Você acorda de madrugada ouvindo sons abafados na sua porta. Você levanta da cama e vai
               rumo à porta. Ninguém responde as suas perguntas sobre quem é ou o que deseja ali,
               aquela hora.

               Ao se aproximar da entrada, os ruídos cessam e você abre a porta para verificar o que estava
               acontecendo, imediatamente você percebe que está sofrendo um ataque. Sem muito tempo
               para reagir, você apenas tenta se proteger com os braços e sofre diversos danos, mas depois
               de momentos de uma tentativa intensa de defesa, você consegue empurrar a coisa e fechar a 
               porta…

               Você fecha a porta e vai em busca de um kit médico que você sabe que está em algum lugar.
               Ao procurar um pequeno armário no seu quarto, você encontra uma arma carregada com 7
               balas, mas não encontra o seu kit. Sua visão começa a ficar turva e você está suando frio,
               então cambaleando você vai rumo à cozinha e encontra uma caixa com suprimentos
               médicos, mas ela está lacrada. Tremendo, você abre uma gaveta e retira de lá uma faca,
               abre a caixa e utiliza um dos dois kit médicos para se curar dos ferimentos da batalha.

               Você automaticamente sente o doce beijo da morte se afastando de você, enquanto guarda
               os seus mais novos itens favoritos: uma faca, um kit médico e uma bela duma arma
               munida de 7 balas para atirar no cérebro alheio. Uma aventura pela sua sobrevivência
               acaba de começar, seria você capaz de conseguir fugir para um local seguro?

               Descubra pressionando Enter.
"); //Introdução do Jogo
        ReadLine();

        character c = new character();
        basement b = new basement();
        theEnd f = new theEnd();
        vehicle v = new vehicle();
        int day = 1;
        while (game == "RODANDO")
        {
            string[] op = { "<< Buscar Materiais >>", "<< Buscar suprimentos >>", "<< Procurar munição >>", "<< Usar kit de primeiros socorros >>", "<< Comer uma lata >>", "<< Beber uma garrafa >>", "<< Ir descansar >>", "<< Arrumar o carro >>", "<< Fugir >>" };
            int index = 0;
            int setado = -1;
            int x = 0;
            int y = 0;
            int z = 0;

            Random r = new Random();

            while (setado == -1)
            {
                ConsoleKeyInfo pressed = new ConsoleKeyInfo();
                while (setado == -1)
                {
                    Clear();
                    WriteLine("\n                    Seu relatório diário                     ");
                    WriteLine("---------------------------Dia {0}----------------------------", day);
                    WriteLine(("\nVida: " + c.GetHealth()).PadRight(20) + ("Comida: " + b.GetFood()));
                    WriteLine(("\nEnegia: " + c.GetStamina()).PadRight(20) + ("Água: " + b.GetWater()));
                    WriteLine(("\nFome: " + c.GetHunger()).PadRight(20) + ("Kit Médico: " + b.GetFirstAid()));
                    WriteLine(("\nSede: " + c.GetThrist()).PadRight(20) + ("Madeira: " + b.GetWood()));
                    WriteLine(("\nFerro: " + b.GetIron()).PadRight(20) + ("Munição: " + b.GetAmmu()));
                    WriteLine("------------------------------------------------------------\n");
                    for (int i = 0; i < op.Length; i++)
                    {
                        if (i == index)
                        {
                            WriteLine(op[i], ForegroundColor = ConsoleColor.Black, BackgroundColor = ConsoleColor.White);
                            if (i == 2 || i == 5)
                            {
                                WriteLine("\n");
                            }
                        }
                        else
                        {
                            WriteLine(op[i], ForegroundColor = ConsoleColor.White, BackgroundColor = ConsoleColor.Black);
                            if (i == 2 || i == 5)
                            {
                                WriteLine("\n");
                            }
                        }
                    }
                    pressed = ReadKey(true);

                    if (pressed.Key == ConsoleKey.UpArrow)
                    {
                        index--;
                        if (index == -1)
                        {
                            index = op.Length - 1;
                        }
                    }
                    else if (pressed.Key == ConsoleKey.DownArrow)
                    {
                        index++;
                        if (index == op.Length)
                        {
                            index = 0;
                        }
                    }
                    else if (pressed.Key == ConsoleKey.Enter)
                    {
                        setado = index;
                    }
                    else if (pressed.Key == ConsoleKey.Escape)
                    {
                        Clear();
                        Environment.Exit(1);
                    }
                    ResetColor();
                }
            }

            
            switch (setado)
            {
                case 0: //Buscar madeira e ferro
                    b.SetWood(r.Next(10, 20));
                    b.SetIron(r.Next(0, 10));
                    ataque(r.Next(1, 10), b.GetAmmu(), ref x, ref y, ref z);
                    c.SetHealth(-x);
                    c.SetStamina(-(15 + z));
                    c.SetHunger(-15);
                    c.SetThrist(-10);
                    b.SetAmmu(-y);
                    break;
                case 1: //Buscar comida, água, e kit
                    b.SetFood(r.Next(1, 10));
                    b.SetWater(r.Next(1, 10));
                    b.SetFirstAid(r.Next(1, 10));
                    ataque(r.Next(1, 10), b.GetAmmu(), ref x, ref y, ref z);
                    c.SetHealth(-x);
                    c.SetStamina(-(10 + z));
                    c.SetHunger(-15);
                    c.SetThrist(-10);
                    b.SetAmmu(-y);
                    break;
                case 2: //Buscar munição para a arma
                    b.SetAmmu(r.Next(1, 7));
                    ataque(r.Next(2, 10), b.GetAmmu(), ref x, ref y, ref z);
                    c.SetHealth(-x);
                    c.SetStamina(-(10 + z));
                    c.SetHunger(-15);
                    c.SetThrist(-10);
                    b.SetAmmu(-y);
                    break;
                case 3: //Usa um kit para se curar
                    if(b.GetFirstAid() > 0)
                    {
                        c.SetHealth(50);
                        b.SetFirstAid(-1);
                    }
                    else
                    {
                        Clear();
                        WriteLine("Você não tem kit de primeiros socorros para se curar!!!");
                        ReadLine();
                    }
                    break;
                case 4: //Come uma lata de comida
                    if(b.GetFood() > 0)
                    {
                        c.SetHunger(50);
                        b.SetFood(-1);
                    }
                    else
                    {
                        Clear();
                        WriteLine("Você não tem comida estocada!!!");
                        ReadLine();
                    }
                    break;
                case 5: //Beber água
                    if(b.GetWater() > 0)
                    {
                        c.SetThrist(30);
                        b.SetWater(-1);
                    }
                    else
                    {
                        Clear();
                        WriteLine("A água acabou!!!");
                        ReadLine();
                    }
                    break;
                case 6: //Ir dormir
                    day++;
                    c.SetStamina(100);
                    Clear();
                    WriteLine("Depois de uma bela noite de sono, você se sente revigorado para um novo dia!!!");
                    ReadLine();
                    break;
                case 7: //Arrumar o carro
                    Clear();
                    int quant;
                    WriteLine("Atualmente, a armadura do seu carro está {0}% arrumada", v.GetShield());
                    WriteLine("Quanto você quer melhorar a armadura do seu carro? (1 = 25%) (2 = 50%) (3 = 75%) (4 = 100%)\n\nObs.:Caso um número maior que 4 for digitado, vou entender como 4\n\nVocê precisa de 40 madeiras e 15 ferros pra melhorar 1 vez a armadura do carro");
                    try
                    {
                        quant = Convert.ToInt32(ReadLine());

                        if(quant > 0 && quant <= 4)
                        {
                            v.ShieldCraft(b.sendWood(40 * quant), b.sendIron(15 * quant), quant);
                        }
                        else if(quant > 4)
                        {
                            quant = 4;
                            v.ShieldCraft(b.GetWood(), b.GetIron(), quant);
                        }
                        else if(quant < -1)
                        {
                            WriteLine("Não tem como fazer isso, volta e faz de novo!!!");
                        }
                    }
                    catch (System.FormatException)
                    {
                        Clear();
                        WriteLine("Já que você não quer melhorar o escudo, volte para o Menu!!!");
                        ReadLine();
                    }
                    break;
                case 8: //Fuga da pessoa
                    if(v.GetShield() < 100)
                    {
                        game = "FIM";
                        f.SetFinal("final2");
                    }
                    else if(v.GetShield() == 100)
                    {
                        game = "FIM";
                        f.SetFinal("final3");
                    }
                    break;
            }
            if(c.GetHealth() == 0 || c.GetStamina() == 0)
            {
                game = "FIM";
                f.SetFinal("final1");
                if(c.GetHealth() == 0)
                {
                    Clear();
                    WriteLine("Devido a todos os danos sofridos, você não aguentou tudo isso e aceita a morte sobre seus ombros!!!");
                    ReadLine();
                }
                else if(c.GetStamina() == 0)
                {
                    Clear();
                    WriteLine("Toda a fadiga e falta de descanso fizeram você sucumbir até o ponto que nem seu corpo aguentou!!!");
                    ReadLine();
                }
            }
            if(c.GetHunger() == 0)
            {
                Clear();
                WriteLine("Com muita fome, você acaba perdendo um pouco de sua vida");
                ReadLine();
                c.SetHealth(-10);
            }
            if(c.GetThrist() == 0)
            {
                Clear();
                WriteLine("Com muita sede, você acaba perdendo um pouco de sua vida");
                ReadLine();
                c.SetHealth(-20);
            }
        }
        switch(f.GetFinal())
        {
            case 0:
                Clear();
                if(day == 1)
                {
                    WriteLine($@"
                    Após uma tentativa de sobrevivência medíocre, você falhou miseravelmente e
                    morreu. Tente não falhar como zumbi agora….

                                                BAD ENDING: MORTE         
                                             Você sobreviveu {day} dia
                ");
                }
                else
                {
                    WriteLine($@"
                    Após uma tentativa de sobrevivência medíocre, você falhou miseravelmente e
                    morreu. Tente não falhar como zumbi agora….

                                                BAD ENDING: MORTE         
                                             Você sobreviveu {day} dias
                ");
                }
                break;
            case 1:
                Clear();
                if(day == 1)
                {
                    WriteLine($@"
                    Mesmo após muita dedicação, tudo acabou sendo em vão, já que o seu carro
                    quebrou e agora você está preso nesta realidade. Pelo resto da sua vida.

                                         ENDING NORMAL: PRESOS PARA SEMPRE
                                            Você sobreviveu {day} dia
                ");
                }
                else
                {
                    WriteLine($@"
                    Mesmo após muita dedicação, tudo acabou sendo em vão, já que o seu carro
                    quebrou e agora você está preso nesta realidade. Pelo resto da sua vida.

                                         ENDING NORMAL: PRESOS PARA SEMPRE
                                            Você sobreviveu {day} dias
                ");
                }
                break;
            case 2:
                Clear();
                if(day == 1)
                {
                    WriteLine($@"
                    Todas as noites mal dormidas, sacrifícios e batalhas enfrentadas até agora valeram
                    à pena. Você conseguiu fugir do epicentro e indo rumo a um lugar seguro.

                                            GOOD ENDING: LIBERDADE      
                                           Você sobreviveu {day} dia
                ");
                }
                else
                {
                    WriteLine($@"
                    Todas as noites mal dormidas, sacrifícios e batalhas enfrentadas até agora valeram
                    à pena. Você conseguiu fugir do epicentro e indo rumo a um lugar seguro.

                                            GOOD ENDING: LIBERDADE      
                                           Você sobreviveu {day} dias
                ");
                }
                break;
        }
        ReadLine();
    }
    static void opening()
    {
        ConsoleKeyInfo pressed = new ConsoleKeyInfo();

        while (pressed.Key != ConsoleKey.Enter)
        {
            Clear();
            WriteLine(@"
                        ───────────────────────────────────────────────────────────────────────────────
                        ─██████████████────────────██████─██████████████─██████████████─██████████████─
                        ─██░░░░░░░░░░██────────────██░░██─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░░░██─
                        ─██░░██████░░██────────────██░░██─██░░██████░░██─██░░██████████─██░░██████░░██─
                        ─██░░██──██░░██────────────██░░██─██░░██──██░░██─██░░██─────────██░░██──██░░██─
                        ─██░░██──██░░██────────────██░░██─██░░██──██░░██─██░░██─────────██░░██──██░░██─
                        ─██░░██──██░░██────────────██░░██─██░░██──██░░██─██░░██──██████─██░░██──██░░██─
                        ─██░░██──██░░██────██████──██░░██─██░░██──██░░██─██░░██──██░░██─██░░██──██░░██─
                        ─██░░██──██░░██────██░░██──██░░██─██░░██──██░░██─██░░██──██░░██─██░░██──██░░██─
                        ─██░░██████░░██────██░░██████░░██─██░░██████░░██─██░░██████░░██─██░░██████░░██─
                        ─██░░░░░░░░░░██────██░░░░░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░░░██─
                        ─██████████████────██████████████─██████████████─██████████████─██████████████─
                        ───────────────────────────────────────────────────────────────────────────────"); //Logo do jogo
            WriteLine("\nAperte ENTER para começar!!!");
            pressed = ReadKey(true);
        }
    } //Função da abertura do jogo

    static int menu()
    {
        string[] menu = { "<< Play >>", "<< Instruções >>", "<< Criadores >>" };
        int index = 0;
        int setado = -1;

        while (setado == -1)
        {
            ConsoleKeyInfo pressed = new ConsoleKeyInfo();
            while (setado == -1 && pressed.Key != ConsoleKey.Escape)
            {
                Clear();
                WriteLine(@"
                        ───────────────────────────────────────────────────────────────────────────────
                        ─██████████████────────────██████─██████████████─██████████████─██████████████─
                        ─██░░░░░░░░░░██────────────██░░██─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░░░██─
                        ─██░░██████░░██────────────██░░██─██░░██████░░██─██░░██████████─██░░██████░░██─
                        ─██░░██──██░░██────────────██░░██─██░░██──██░░██─██░░██─────────██░░██──██░░██─
                        ─██░░██──██░░██────────────██░░██─██░░██──██░░██─██░░██─────────██░░██──██░░██─
                        ─██░░██──██░░██────────────██░░██─██░░██──██░░██─██░░██──██████─██░░██──██░░██─
                        ─██░░██──██░░██────██████──██░░██─██░░██──██░░██─██░░██──██░░██─██░░██──██░░██─
                        ─██░░██──██░░██────██░░██──██░░██─██░░██──██░░██─██░░██──██░░██─██░░██──██░░██─
                        ─██░░██████░░██────██░░██████░░██─██░░██████░░██─██░░██████░░██─██░░██████░░██─
                        ─██░░░░░░░░░░██────██░░░░░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░░░██─
                        ─██████████████────██████████████─██████████████─██████████████─██████████████─
                        ───────────────────────────────────────────────────────────────────────────────"); //Logo do jogo

                for (int i = 0; i < menu.Length; i++)
                {
                    if (i == index)
                    {
                        WriteLine(menu[i], ForegroundColor = ConsoleColor.Black, BackgroundColor = ConsoleColor.White);
                    }
                    else
                    {
                        WriteLine(menu[i], ForegroundColor = ConsoleColor.White, BackgroundColor = ConsoleColor.Black);
                    }

                }
                pressed = ReadKey(true);

                if (pressed.Key == ConsoleKey.UpArrow)
                {
                    index--;
                    if (index == -1)
                    {
                        index = menu.Length - 1;
                    }
                }
                else if (pressed.Key == ConsoleKey.DownArrow)
                {
                    index++;
                    if (index == menu.Length)
                    {
                        index = 0;
                    }
                }

                else if (pressed.Key == ConsoleKey.Enter)
                {
                    setado = index;
                }

                ResetColor();
                if (pressed.Key == ConsoleKey.Escape)
                {
                    Clear();
                    Environment.Exit(1);
                }
            }
        }
        return setado;
    } //Função do menu do jogo

    static void instrucoes()
    {
        WriteLine(@"
               O Jogo possui instruções que vão facilitar a sua jogabilidade, mas assim como seu nome,
               as instruções também são bem genéricas.

               Utilize a Seta para cima ou Seta para baixo para navegar entre as opções e pressione Enter
               para selecionar. Aperte o Esc sempre que quiser fechar o programa.

               O seu objetivo geral é fugir da cidade grande e do apocalipse zumbi que rodeia sua casa,
               para isso, você irá precisar (ou não) montar uma armadura para o seu carro ou arriscar
               fugir diretamente, quem sabe. O seu destino está em suas mãos (e na sorte também hehe).


               É bem fácil, não? Só não se esqueça de sempre monitorar a sua barra de status para
               verificar seu inventário e saúde.

               Volte para o menu pressionando Enter.
"); //Intruções do jogo
        ReadLine();
    }//Função das Instruções do jogo

    static void criadores()
    {
        WriteLine(@"                             
                                                Made for Fecap 
                                                   Créditos:                            
                                          Débora Souza Matos(あいちゃん)
                                    João Fernando de Lima Gonçalves(あいちゃん)
");
        ReadLine();
        ResetColor();
    }//Função dos criadores do jogo

    static void ataque(int i, int bullet, ref int dano, ref int munition, ref int estamina)
    {
        string[] atk = { "<< Faca (15 de dano) >>", "<< Arma(Gasta 1 bala/30 de dano) >>" };
        int index = 0;
        int setado = -1;
        int aux = 0;
        munition = 0;
        dano = 0;
        estamina = 0;
      
        ConsoleKeyInfo pressed = new ConsoleKeyInfo();
        handgun p = new handgun();
        knife k = new knife();

        switch (i)
        {
            case 1: //Ataque de Humano
                Clear();
                WriteLine("\nVocê sai para se aventurar neste mundo caótico e é atacado por um humano, lute para se defender!");
                ReadLine();
                human h = new human();
                while (h.GetLife() > 0)
                {
                    while (setado == -1)
                    {
                        Clear();
                        WriteLine("---------------------Batalha---------------------");
                        WriteLine(("\nVida: " + h.GetLife()).PadRight(20) + ("Munição: " + bullet + "\n") + ("Dano Sofrido: " + dano).PadRight(19) + ("Energia Gasta: " + estamina + "\n\n"));
                        for (int j = 0; j < atk.Length; j++)
                        {
                            if (j == index)
                            {
                                WriteLine(atk[j], ForegroundColor = ConsoleColor.Black, BackgroundColor = ConsoleColor.White);
                            }
                            else
                            {
                                WriteLine(atk[j], ForegroundColor = ConsoleColor.White, BackgroundColor = ConsoleColor.Black);
                            }
                        }
                        pressed = ReadKey(true);

                        if (pressed.Key == ConsoleKey.UpArrow)
                        {
                            index--;
                            if (index == -1)
                            {
                                index = atk.Length - 1;
                            }
                        }
                        else if (pressed.Key == ConsoleKey.DownArrow)
                        {
                            index++;
                            if (index == atk.Length)
                            {
                                index = 0;
                            }
                        }
                        else if (pressed.Key == ConsoleKey.Enter)
                        {
                            setado = index;
                        }
                        else if (pressed.Key == ConsoleKey.Escape)
                        {
                            Clear();
                            Environment.Exit(1);
                        }
                        ResetColor();
                    }
                    if (setado == 0)
                    {
                        h.SetLife(k.GetDamage());
                    }
                    else if (setado == 1)
                    {
                        if(bullet > 0)
                        {
                            h.SetLife(p.GetDamage());
                            munition++;
                            bullet--;
                        }
                        else
                        {
                            Clear();
                            WriteLine("Ao tentar atirar, você percebe que o pente da arma está vazio, e perde sua chance. Melhor ficar de olho nisso!!!");
                            ReadLine();
                        }
                    }
                    setado = -1;
                    aux++;
                    estamina = estamina + 2;
                    if (aux == 2 && h.GetLife() > 0)
                    {
                        dano = dano + h.GetDamage();
                        aux = 0;
                    }
                }
                break;
            case 2: //Pisar em uma armadilha
                Clear();
                WriteLine("\nVocê sai para se aventurar neste mundo caótico e acaba preso em uma armadilha. Você consegue se soltar, mas ela te causa muitos danos.");
                ReadLine();
                trap t = new trap();
                dano = dano + t.GetDamage();
                break;
            case 3: //Ataque de Zumbi
                Clear();
                WriteLine("\nVocê sai para se aventurar neste mundo caótico e é atacado por um zumbi, lute para se defender!");
                ReadLine();
                zombies z = new zombies();
                while (z.GetLife() > 0)
                {
                    while (setado == -1)
                    {
                        Clear();
                        WriteLine("---------------------Batalha---------------------");
                        WriteLine(("\nVida: " + z.GetLife()).PadRight(20) + ("Munição: " + bullet + "\n") + ("Dano Sofrido: " + dano).PadRight(19) + ("Energia Gasta: " + estamina + "\n\n"));
                        for (int j = 0; j < atk.Length; j++)
                        {
                            if (j == index)
                            {
                                WriteLine(atk[j], ForegroundColor = ConsoleColor.Black, BackgroundColor = ConsoleColor.White);
                            }
                            else
                            {
                                WriteLine(atk[j], ForegroundColor = ConsoleColor.White, BackgroundColor = ConsoleColor.Black);
                            }
                        }
                        pressed = ReadKey(true);

                        if (pressed.Key == ConsoleKey.UpArrow)
                        {
                            index--;
                            if (index == -1)
                            {
                                index = atk.Length - 1;
                            }
                        }
                        else if (pressed.Key == ConsoleKey.DownArrow)
                        {
                            index++;
                            if (index == atk.Length)
                            {
                                index = 0;
                            }
                        }
                        else if (pressed.Key == ConsoleKey.Enter)
                        {
                            setado = index;
                        }
                        else if (pressed.Key == ConsoleKey.Escape)
                        {
                            Clear();
                            Environment.Exit(1);
                        }
                        ResetColor();
                    }
                    if (setado == 0)
                    {
                        z.SetLife(k.GetDamage());
                    }
                    else if (setado == 1)
                    {
                        if(bullet > 0)
                        {
                            z.SetLife(p.GetDamage());
                            munition++;
                            bullet--;
                        }
                        else
                        {
                            Clear();
                            WriteLine("Ao tentar atirar, você percebe que o pente da arma está vazio, e perde sua chance. Melhor ficar de olho nisso!!!");
                            ReadLine();
                        }
                    }
                    setado = -1;
                    aux++;
                    estamina = estamina + 2;
                    if (aux == 2 && z.GetLife() > 0)
                    {
                        dano = dano + z.GetDamage();
                        aux = 0;
                    }
                }
                break;
            case 4: //Ataque de Animal
                Clear();
                WriteLine("\nVocê sai para se aventurar neste mundo caótico e é atacado por um animal selvagem, lute para se defender!");
                ReadLine();
                wildAnimal a = new wildAnimal();
                while (a.GetLife() > 0)
                {
                    while (setado == -1)
                    {
                        Clear();
                        WriteLine("---------------------Batalha---------------------");
                        WriteLine(("\nVida: " + a.GetLife()).PadRight(20) + ("Munição: " + bullet + "\n") + ("Dano Sofrido: " + dano).PadRight(19) + ("Energia Gasta: " + estamina + "\n\n"));
                        for (int j = 0; j < atk.Length; j++)
                        {
                            if (j == index)
                            {
                                WriteLine(atk[j], ForegroundColor = ConsoleColor.Black, BackgroundColor = ConsoleColor.White);
                            }
                            else
                            {
                                WriteLine(atk[j], ForegroundColor = ConsoleColor.White, BackgroundColor = ConsoleColor.Black);
                            }
                        }
                        pressed = ReadKey(true);

                        if (pressed.Key == ConsoleKey.UpArrow)
                        {
                            index--;
                            if (index == -1)
                            {
                                index = atk.Length - 1;
                            }
                        }
                        else if (pressed.Key == ConsoleKey.DownArrow)
                        {
                            index++;
                            if (index == atk.Length)
                            {
                                index = 0;
                            }
                        }
                        else if (pressed.Key == ConsoleKey.Enter)
                        {
                            setado = index;
                        }
                        else if (pressed.Key == ConsoleKey.Escape)
                        {
                            Clear();
                            Environment.Exit(1);
                        }
                        ResetColor();
                    }
                    if (setado == 0)
                    {
                        a.SetLife(k.GetDamage());
                    }
                    else if (setado == 1)
                    {
                        if(bullet > 0)
                        {
                            a.SetLife(p.GetDamage());
                            munition++;
                            bullet--;
                        }
                        else
                        {
                            Clear();
                            WriteLine("Ao tentar atirar, você percebe que o pente da arma está vazio, e perde sua chance. Melhor ficar de olho nisso!!!");
                            ReadLine();
                        }
                    }
                    setado = -1;
                    aux++;
                    estamina = estamina + 2;
                    if (aux == 2 && a.GetLife() > 0)
                    {
                        dano = dano + a.GetDamage();
                        aux = 0;
                    }
                }
                break;
            default:
                Clear();
                WriteLine("\nVocê sai em uma busca, e consegue voltar em segurança para sua casa. Parece que você ainda não comeu sua última lata!!!");
                ReadLine();
                break;
        }
    } //Função de ser atacado
}