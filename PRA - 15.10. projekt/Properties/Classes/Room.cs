using PRA___15._10._projekt.Properties.Classes;

namespace PRA___15._10._projekt
{
    public class Room
    {
        public string Name { get; private set; }
        public Enemy Enemy { get; set; }

        public Room(string name, Enemy enemy = null)
        {
            Name = name;
            Enemy = enemy;
        }
    }

}