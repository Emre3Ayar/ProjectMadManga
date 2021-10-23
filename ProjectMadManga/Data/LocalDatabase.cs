using ProjectMadManga.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMadManga.Data
{
    public class LocalDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public LocalDatabase(string dPath)
        {
            _database = new SQLiteAsyncConnection(dPath);
            _database.CreateTableAsync<Car>().Wait();
            _database.CreateTableAsync<User>().Wait();
        }

        public async Task<List<Car>> GetCars()
        {
            //Reset database
            await _database.DeleteAllAsync<Car>();
            //return _database.Table<Car>().ToListAsync();
            var car = await _database.Table<Car>().ToListAsync();
            if (!car.Any())
            {            
                await _database.InsertAllAsync(new Car[]
                {
                    new Car{Id = 1, CarName = "Drifsta", CarAccel = 1.2, CarBraking = 0, CarHandeling = 0, CarImage = "Drifsta", CarTopSpeed = 50, CarWanted = 1, CarDetail = "The Driftsta is a Hot Wheels Original Model designed by Jun Imai. The sleek and aerodynamic shape of the car makes it perfect for drifting through those corners. Even its name screams drifting. With the roof rack, exposed intercooler for the twin turbo engine and missing front spoiler, this rubber destroying beast is ready to produce some smoke. Use the double nitrous to boost your speed before pulling the handbrake and turning the wheel."},
                    new Car{Id = 2, CarName = "Zotic", CarAccel = 1.5, CarBraking = 0, CarHandeling = 0, CarImage = "Zotic", CarTopSpeed = 80, CarWanted = 3, CarDetail ="A luxury car like no other, the Zotic is a Hot Wheels supercar made to edge out the competition. Fast, sleek, and powerful, this high-end hottie is like heaven on wheels."},
                    new Car{Id = 3, CarName = "Audacious", CarAccel = 1.7, CarBraking = 0, CarHandeling = 0, CarImage = "Audacious", CarTopSpeed = 150, CarWanted = 1, CarDetail ="The Audacious is an original, fantasy design created by Phil Riehlman. This car is styled after station wagons such as the Toyota Caldina. In 2011, the casting was changed, and the rear spoiler is now part of the body instead of the window."},
                    new Car{Id = 4, CarName = "Pony-Up", CarAccel = 2.1, CarBraking = 0, CarHandeling = 0, CarImage = "PonyUp", CarTopSpeed = 130, CarWanted = 5, CarDetail = "The Pony-Up is a contemporary muscle car designed by Mark Jones. The tooling for the casting was updated around 2015, with the casting gaining a new overhauled interior and a slightly different base."},
                    new Car{Id = 5, CarName = "FastFish", CarAccel = 1.8, CarBraking = 0, CarHandeling = 0, CarImage = "FastFish", CarTopSpeed = 190, CarWanted = 7, CarDetail = "This Hot Wheels version of a contemporary muscle car comes equipped with quad exhaust and a transparent hood bulge to show off the brute force of its 8-cylinder engine and let you know it's fast and fierce. The spoilers around the car, top and bottom, as well as the styling of headlights and other features give an impression of an American muscle-car take on laser precision."}
                });
                return await _database.Table<Car>().ToListAsync();
            }
            return car;
        }
        public Task<int> SaveCar(Car car)
        {
            return _database.InsertAsync(car);
        }

        public async Task<int> NameControl(string name)
        {
            int output = 0;
            string items = "";
            var gevondenitems = await _database.QueryAsync<Car>("SELECT * FROM Car WHERE CarName = ?", name);
            foreach (var s in gevondenitems)
            {
                items += s.CarName;
            }
            if (items == "")
            {
                output = 1;
                return output;
            }
            else
            {
                output = 0;
                return output;
            };
        }
        public async Task<List<User>> GetUsers()
        {
            //Reset database
            await _database.DeleteAllAsync<User>();
            //return _database.Table<Car>().ToListAsync();
            var user = await _database.Table<User>().ToListAsync();
            if (!user.Any())
            {
                await _database.InsertAllAsync(new User[]
                {
                    new User{UserId = 0, UserName = "Serdal", UserPassword = "macka61"},
                    new User{UserId = 1, UserName = "Emre", UserPassword = "123"},
                });
                return await _database.Table<User>().ToListAsync();
            }
            return user;
        }
    }
}
