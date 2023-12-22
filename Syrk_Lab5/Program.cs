using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syrk_Lab5_Library;

namespace Syrk_Lab5
{
    class Program
    {
        static System.Random rand = new System.Random();

        static List<Car> cars = new List<Car>();

        static string[] names=new string[6];
        static string[] ints = new string[3];

        static void Main(string[] args)
        {
            names[0] = "Волга";
            names[1] = "Лада";
            names[2] = "УАЗ";
            names[3] = "Лексус";
            names[4] = "Ауди";
            names[5] = "Тойота";

            ints[0] = "Кожа";
            ints[1] = "Ткань";
            ints[2] = "Дерево";

            Console.Title = "Конструктор и симулятор автомобиля";

            while (true)
            {
                Console.WriteLine("\nВыберете действие: \n" +
                    "0 - Создание случайного автомобиля\n" +
                    "1 - Управление автомобилем");

                int act = int.Parse(Console.ReadLine());

                switch (act)
                {
                    case 0:
                        {

                            cars.Add(new Car(names[rand.Next(6)], rand.Next(1900, 2023)));

                            cars[cars.Count() - 1].InstalPart(new Engine($"Д{rand.Next(500, 2500)}", rand.Next(60, 400)));
                            cars[cars.Count() - 1].InstalPart(new FuelTank($"Б{rand.Next(90, 98)}", rand.Next(30, 80)));
                            cars[cars.Count() - 1].InstalPart(new Wheels($"К{rand.Next(20)}"));
                            cars[cars.Count() - 1].InstalPart(new Interior(ints[rand.Next(3)]));

                            Console.WriteLine("Создан автомобиль");
                            cars[cars.Count() - 1].ShowStats();
                        }break;
                    case 1:
                        {

                            Console.WriteLine("\nВыберите автомобиль: ");

                            int k = 0;

                            if (cars.Count() > 0)
                            {
                                foreach (Car car in cars)
                                {
                                    Console.WriteLine($"{k} - {cars[k].name}");

                                    k++;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Отсутствуют автомобили, необходимо создать по крайней мере один");
                            }

                            Console.WriteLine($"{k} - Вернуться к выбору действий");

                            int pickAction = int.Parse(Console.ReadLine());

                            if (pickAction == k)
                            {
                                break;
                            }
                            else
                            {
                                bool actionGoing = true;

                                while (actionGoing)
                                {
                                    Console.WriteLine("\nВыберите действие: \n" +
                                        "0 - Завести двигатель\n" +
                                        "1 - Заглушить двигатель\n" +
                                        "2 - Проехаться\n" +
                                        "3 - Отобразить информацию об автомобиле\n" +
                                        "4 - Заправиться\n" +
                                        "5 - Вернуться к выбору действий");

                                    int controlAction = int.Parse(Console.ReadLine());

                                    switch (controlAction)
                                    {
                                        case 0:
                                            {
                                                cars[pickAction].StartEngine();
                                            }
                                            break;
                                        case 1:
                                            {
                                                cars[pickAction].ShutEngine();
                                            }
                                            break;
                                        case 2:
                                            {
                                                cars[pickAction].Drive();
                                            } break;
                                        case 3:
                                            {
                                                cars[pickAction].ShowStats();
                                            } break;
                                        case 4:
                                            {
                                                cars[pickAction].Refuel();
                                            } break;
                                        case 5:
                                            actionGoing = false;
                                            break;
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
