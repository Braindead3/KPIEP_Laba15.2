using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace KPIEP_Laba15._2
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Player> players = new List<Player>();
            if (File.Exists("players.json"))
            {
                string palyersJsonString = File.ReadAllText("players.json");
                players =JsonConvert.DeserializeObject<List<Player>>(palyersJsonString) as List<Player>;
            }
            else
            {
                using (StreamWriter sw = new StreamWriter("players.json", false))
                {
                    players.Add(new Player(10, 20, 20, 10));
                    sw.Write(JsonConvert.SerializeObject(players));
                }
            }

            FeodalGame feodalGame = new FeodalGame(players[0]);



             feodalGame.Notify += delegate (string mes)
             {
                 Console.WriteLine(mes);
             };
            while (true)
            {
                Console.WriteLine($"Голд:{players[0].gold}\n" +
                    $"Крестьяне:{players[0].rabotyagi}\n" +
                    $"Лимит крестьян:{players[0].limitRabotyag}\n" +
                    $"Процент работяг:{players[0].procRabotyag}");
                Console.WriteLine();

                Console.WriteLine("1.Увеличить налог\n" +
                    "2.Уменьшит налог\n" +
                    "3.Построить лачугу\n" +
                    "4.Дать вольную\n" +
                    "5.Провести торжество\n" +
                    "6.Закончить ход\n");

                int switch_on = Convert.ToInt32(Console.ReadLine());
                switch (switch_on)
                {
                    case 1:
                        if (feodalGame.PodnyatNalogi() == 0)
                        {
                            Console.ReadLine();
                            Environment.Exit(1);
                        }
                        feodalGame.PodnyatNalogi();
                        break;

                    case 2:
                        if (feodalGame.opustitNalogi() == 0)
                        {
                            Console.ReadLine();
                            Environment.Exit(1);
                        }
                        feodalGame.opustitNalogi();
                        break;

                    case 3:
                        if (feodalGame.PostroitLachugu() == 0)
                        {
                            Console.ReadLine();
                            Environment.Exit(1);
                        }
                        feodalGame.PostroitLachugu();
                        break;

                    case 4:
                        if (feodalGame.DatVolnuyu() == 0)
                        {
                            Console.ReadLine();
                            Environment.Exit(1);
                        }
                        feodalGame.DatVolnuyu();
                        break;

                    case 5:
                        if (feodalGame.NoviyGod() == 0)
                        {
                            Console.ReadLine();
                            Environment.Exit(1);
                        }
                        feodalGame.NoviyGod();
                        break;

                    case 6:
                        if (feodalGame.EndTurn()==0)
                        {
                            Console.ReadLine();
                            Environment.Exit(1);
                        }
                        break;

                    default:
                        Console.WriteLine("Нет такого пункта");
                        break;
                }

            }
        }
    }
}
