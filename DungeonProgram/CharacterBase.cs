namespace DungeonProgram
{
    public class CharacterBase
    {
        //Fields
        private int _remainingLife;

        //Properties
        public string Name { get; set; }
        public int HitChance { get; set; }
        public int BlockChance { get; set; }
        public int MaxLife { get; set; }
        public int RemainingLife
        {
            get { return _remainingLife; }
            set
            {
                //making sure life doesn't go over MaxLife
                if (value <= MaxLife)
                {
                    _remainingLife = value;
                }
                else
                {
                    _remainingLife = MaxLife;
                }
            }
        }//end RemainingLife prop

        //Constructors
        //No need to define Constructor because this class is only a parent,Not going to call it except in children
        //Methods
        public virtual int DetermineBlock()
        {
            return BlockChance;
        }
        public virtual int DetermineHitChance()
        {
            return HitChance;
        }
        public virtual int DamageDone()
        {
            return 0;
        }
    }//end class
}//end namespace
