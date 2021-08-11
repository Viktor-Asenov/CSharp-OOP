using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository driverRepository;
        private CarRepository carRepository;
        private RaceRepository raceRepository;

        public ChampionshipController()
        {
            this.driverRepository = new DriverRepository();
            this.carRepository = new CarRepository();
            this.raceRepository = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = this.driverRepository.GetAll().FirstOrDefault(d => d.Name == driverName);
            ICar car = this.carRepository.GetAll().FirstOrDefault(c => c.Model == carModel);

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            if (car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            driver.AddCar(car);

            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = this.raceRepository.GetAll().FirstOrDefault(r => r.Name == raceName);
            IDriver driver = this.driverRepository.GetAll().FirstOrDefault(d => d.Name == driverName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            race.AddDriver(driver);

            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.carRepository.GetAll().FirstOrDefault(c => c.Model == model) != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            this.carRepository.Add(car);

            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            if (this.driverRepository.GetAll().FirstOrDefault(d => d.Name == driverName) != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            IDriver driver = new Driver(driverName);
            this.driverRepository.Add(driver);

            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRepository.GetAll().FirstOrDefault(r => r.Name == name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            IRace race = new Race(name, laps);
            this.raceRepository.Add(race);

            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.GetAll().FirstOrDefault(r => r.Name == raceName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var winingDrivers = race.Drivers
                .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            this.raceRepository.Remove(race);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Driver {winingDrivers[0].Name} wins {raceName} race.");
            sb.AppendLine($"Driver {winingDrivers[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Driver {winingDrivers[2].Name} is third in {raceName} race.");

            return sb.ToString().TrimEnd();
        }
    }
}
