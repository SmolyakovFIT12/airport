using System;

namespace Airport.GameModel
{
    [Serializable]
    public class City
    {
        public string ID { get; }
        public string Name { get; }

        public City(string ID, string name)
        {
            this.ID = ID;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
