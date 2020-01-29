namespace HeroesOfTheStats.Shared.DTOs
{
    public class PlayerDto
    {
        public string BattleTag { get; set; }
        public string Hero { get; set; }
        public int HeroLevel { get; set; }
        public int Team { get; set; }
        public bool Winner { get; set; }
        public long BlizzId { get; set; }
        public bool IsSilenced { get; set; }
        public int Party { get; set; }
        public object Talents { get; set; }
        public ScoreDto Score { get; set; }
    }
}