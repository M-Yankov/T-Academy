namespace ChainResponsibility.Checker
{
    using ChainResponsibility.Utils;

    internal abstract class BaseHandChecker
    {
        protected BaseHandChecker NextChecker { get; set; }

        public void SetChecker(BaseHandChecker checker)
        {
            this.NextChecker = checker;
        }

        public abstract void CheckHand(PokerHand pokerHand);
    }
}
