namespace WildFarm.Core
{
    using WildFarm.Models;

    public class AnimalCreator
    {
        public Animal Create(string[] args, int foodEaten)
        {
            string typeOfAnimal = args[0];
            string name = args[1];
            double weight = double.Parse(args[2]);

            Animal animal = null;
            switch (typeOfAnimal)
            {
                case "Hen":
                    double wingSizeHen = double.Parse(args[3]);
                    animal = new Hen(name, weight, foodEaten, wingSizeHen);
                    break;
                case "Owl":
                    double wingSizeOwl = double.Parse(args[3]);
                    animal = new Owl(name, weight, foodEaten, wingSizeOwl);
                    break;
                case "Mouse":
                    string livingRegionMouse = args[3];
                    animal = new Mouse(name, weight, foodEaten, livingRegionMouse);
                    break;
                case "Dog":
                    string livingRegionDog = args[3];
                    animal = new Dog(name, weight, foodEaten, livingRegionDog);
                    break;
                case "Cat":
                    string livingRegionCat = args[3];
                    string breedCat = args[4];
                    animal = new Cat(name, weight, foodEaten, livingRegionCat, breedCat);
                    break;
                case "Tiger":
                    string livingRegionTiger = args[3];
                    string breedTiger = args[4];
                    animal = new Tiger(name, weight, foodEaten, livingRegionTiger, breedTiger);
                    break;
            }

            return animal;
        }
    }
}
