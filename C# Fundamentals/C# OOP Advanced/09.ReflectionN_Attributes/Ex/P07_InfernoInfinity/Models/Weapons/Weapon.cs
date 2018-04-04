namespace P07_InfernoInfinity
{
    using P07_InfernoInfinity.Models.Enums;
    using P07_InfernoInfinity.Models.Gems;
    using P07_InfernoInfinity.Models.Weapons;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Weapon
    {
        private string name;
        private int minDamage;
        private int maxDamage;
        private List<Socket> sockets;
        private RarityType rarity;
        private int socketCount;

        private int strength;
        private int agility;
        private int vitality;

        public Weapon(string name, RarityType rarity, int minDamage, int maxDamage, int socketsCount)
        {
            this.Name = name;
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
            this.Sockets = CreateSocketsForWeapon(socketsCount);
            this.socketCount = socketsCount;
            this.Rarity = rarity;
        }

        private static List<Socket> CreateSocketsForWeapon(int socketsCount)
        {
            List<Socket> sockets = new List<Socket>();

            for (int i = 0; i < socketsCount; i++)
            {
                sockets.Add(default(Socket));
            }

            return sockets;
        }

        public void EnhanceWithGem(int socketIndex, Gem gem)
        {
            if(socketIndex >= 0 && socketIndex < this.Sockets.Count)
            {
                this.Sockets[socketIndex] = new Socket(gem);
            }
        }

        public void RemoveGem(int socketIndex)
        {
            if(socketIndex >= 0 && socketIndex < this.Sockets.Count)
            {
                this.Sockets[socketIndex] = default(Socket);
            }
        }

        protected void IncreaseDamage()
        {
            this.MinDamage *= (int)this.Rarity;
            this.MaxDamage *= (int)this.Rarity;
        }

        public override string ToString()
        {

            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int MinDamage
        {
            get
            {
                int strBonus = 0;
                int agiBonus = 0;

                if (this.Sockets.Any(x => x != default(Socket)))
                {
                    List<Socket> tempList = this.Sockets.Where(x => x != default(Socket)).ToList();

                    strBonus = (tempList.Sum(x => x.Gem.Strength)) * 2;
                    agiBonus = tempList.Sum(x => x.Gem.Agility);
                }
                return minDamage + strBonus + agiBonus;
            }
            private set { minDamage = value; }
        }

        public int MaxDamage
        {
            get
            {
                int strBonus = 0;
                int agiBonus = 0;

                if (this.Sockets.Any(x => x != default(Socket)))
                {
                    List<Socket> tempList = this.Sockets.Where(x => x != default(Socket)).ToList();

                    strBonus = (tempList.Sum(x => x.Gem.Strength)) * 3;
                    agiBonus = (tempList.Sum(x => x.Gem.Agility)) * 4;
                }

                return maxDamage + strBonus + agiBonus;
            }
            private set { maxDamage = value; }
        }

        public List<Socket> Sockets
        {
            get { return sockets; }
            private set { sockets = value; }
        }

        public RarityType Rarity
        {
            get { return rarity; }
            private set { rarity = value; }
        }

        public int Strength
        {
            get
            {
                int strBonus = 0;

                if (this.Sockets.Any(x => x != default(Socket)))
                {
                    List<Socket> tempList = this.Sockets.Where(x => x != default(Socket)).ToList();

                    strBonus = tempList.Sum(x => x.Gem.Strength);
                }
                return this.strength + strBonus;
            }
            private set { this.strength = value; }
        }

        public int Agility
        {
            get
            {
                int agiBonus = 0;

                if (this.Sockets.Any(x => x != default(Socket)))
                {
                    List<Socket> tempList = this.Sockets.Where(x => x != default(Socket)).ToList();
                    
                    agiBonus = tempList.Sum(x => x.Gem.Agility);
                }
                return this.agility + agiBonus;
            }
            private set { this.agility = value; }
        }

        public int Vitality
        {
            get
            {
                int vitaBonus = 0;

                if (this.Sockets.Any(x => x != default(Socket)))
                {
                    List<Socket> tempList = this.Sockets.Where(x => x != default(Socket)).ToList();
                    
                    vitaBonus = tempList.Sum(x => x.Gem.Vitality);
                }
                return this.vitality + vitaBonus;
            }
            private set { this.vitality = value; }
        }
    }
}
