namespace KeyValuePairStructure
{
    public class Helper<TKey, TValue> 
    {
        public Helper(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }

        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public override int GetHashCode()
        {
            //// http://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
            unchecked 
            {
                int hash = (int)2166136261;
                hash = hash * 16777619 ^ Key.GetHashCode();
                hash = hash * 16777619 ^ Value.GetHashCode();
                return hash;
            }
        }
    }
}
