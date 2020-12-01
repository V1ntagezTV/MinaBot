using System.ComponentModel.DataAnnotations.Schema;

namespace MinaBot.BotTamagochi.Models
{
    public class LevelModel
    {
        public int ID { get; set; }
        public int TamagochiModelID { get; set; }
        public int Level { get; set; }
        public int ExpToNextLevel { get; set; }
        public int currentExp { get; set; }
        [NotMapped]
        public int CurrentExp
        {
            get { return currentExp; }
            set
            {
                currentExp = value;
                if (currentExp > ExpToNextLevel)
                {
                    currentExp %= ExpToNextLevel;
                    Level++;
                    ExpToNextLevel += 50;
                }
            }
        }
    }
}
