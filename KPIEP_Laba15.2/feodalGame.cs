using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KPIEP_Laba15._2
{
    class FeodalGame
    {
        Player player;
        public delegate void   RabotyagaHandler(string message);
        public event RabotyagaHandler Notify;

        public FeodalGame(Player player)
        {
            this.player = player;
        }

        public int PodnyatNalogi()
        {
            if (player.gold - 1 < 0)
            {
                Console.WriteLine("Вы проиграли");
                return 0;
            }
            else
            {
                player.gold++;
                player.procRabotyag -= 20;
                return 1;
            }
        }

        public int opustitNalogi()
        {
            if (player.gold-1 < 0)
            {
                Console.WriteLine("Вы проиграли");
                return 0;
            }
            else
            {
                player.gold--;
                player.procRabotyag += 20;
                return 1;
            }
        }

        public int PostroitLachugu()
        {
            if (player.gold - 10 < 0)
            {
                Console.WriteLine("Вы проиграли");
                return 0;
            }
            else
            {
                player.gold -= 10;
                player.limitRabotyag += 4;
                return 1;
            }
        }

        public int DatVolnuyu()
        {
            if (player.rabotyagi-1<0)
            {
                Console.WriteLine("Вы проиграли");
                return 0;
            }
            else
            {
                player.rabotyagi--;
                player.procRabotyag += 5;
                return 1;
            }
        }

        public int NoviyGod()
        {
            if (player.gold - 20 < 0)
            {
                Console.WriteLine("Вы проиграли");
                return 0;
            }
            else
            {
                player.gold -= 20;
                player.rabotyagi++;
                player.procRabotyag += 10;
                return 1;
            }
        }

        public int EndTurn()
        {
            if (player.rabotyagi+Convert.ToInt32(player.rabotyagi * (player.procRabotyag / 100)) > player.limitRabotyag)
            {
                Console.WriteLine("Слишком мало домов, нужно больше места.");
            }
            else
            {
                Console.Clear();
                player.rabotyagi += Convert.ToInt32(player.rabotyagi * (player.procRabotyag / 100));
                if (player.rabotyagi<0)
                {
                    Console.WriteLine("Вы проиграли");
                    return 0;
                }
                else
                {
                    Notify?.Invoke("Появился работяга!!!");
                }
            }
            return 1;
        }

        public Player ReturnPlayer()
        {
            return player;
        }
    }
}
