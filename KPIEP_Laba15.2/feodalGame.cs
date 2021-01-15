using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KPIEP_Laba15._2
{
    class feodalGame
    {
        Player player;
        private delegate void   RabotyagaHandler(string message);
        private event RabotyagaHandler Notify =delegate(string mes)
        {
            Console.WriteLine(mes);
        };

        public feodalGame(Player player)
        {
            this.player = player;
        }

        public void PodnyatNalogi()
        {
            player.gold++;
            player.procRabotyag -= 20;
        }

        public int opustitNalogi()
        {
            if (--player.gold < 0)
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
            if (--player.rabotyagi<0)
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
                player.procRabotyag += 1;
                return 1;
            }
        }

        public void EndTurn()
        {
            player.kolvoRabotyag += player.kolvoRabotyag * player.procRabotyag;
            Notify?.Invoke("Появился работяга");
        }

        public Player ReturnPlayer()
        {
            return player;
        }
    }
}
