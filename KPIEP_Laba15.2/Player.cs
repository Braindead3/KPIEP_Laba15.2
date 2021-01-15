using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPIEP_Laba15._2
{
    class Player
    {
        public int rabotyagi;
        public int gold;
        public int limitRabotyag;
        public int kolvoGold;
        public int kolvoRabotyag;
        public int procRabotyag;

        public Player(int rabotyagi, int gold, int limitRabotyag, int kolvoGold, int kolvoRabotyag, int procRabotyag)
        {
            this.rabotyagi = rabotyagi;
            this.gold = gold;
            this.limitRabotyag = limitRabotyag;
            this.kolvoGold = kolvoGold;
            this.kolvoRabotyag = kolvoRabotyag;
            this.procRabotyag = procRabotyag;
        }
    }
}
