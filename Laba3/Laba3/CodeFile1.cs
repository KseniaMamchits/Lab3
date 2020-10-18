using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    class Program
    {
        static void Main(string[] args)
        {
            House house1 = new House(90, 110, 9, 3, "Зимняя", "общежитие", 30);
            house1.Show();
            house1.Repair(out string repair, house1.Lifetime);
            House house2 = new House(101, 100, 6, 4, "Молодежная", "квартирный дом", 12);
            house2.Show();
            house2.Repair(out repair, house2.Lifetime);
            House house3 = new House(123, 50, 4, 2, "Центральная", "частный дом", 13);
            house3.Show();
            house3.Repair(out repair, house3.Lifetime);
            House house4= new House(128, 75, 7, 4, "Школьная", "гостиница", 2);
            house4.Show();
            house4.Repair(out repair, house4.Lifetime);
            House house5 = new House(1, 60, 1, 2, "Советская", "хостел", 50);
            house5.Show();
            house5.Repair(out repair, house5.Lifetime);
            Console.WriteLine();
            Console.WriteLine("Количество квартир: " + House.size);
           
            object[] ListOfHouse = new object[5];
            ListOfHouse[0] = house1;
            ListOfHouse[1] = house2;
            ListOfHouse[2] = house3;
            ListOfHouse[3] = house4;
            ListOfHouse[4] = house5;
            Console.WriteLine();
            Console.WriteLine("Список квартир, имеющих 4 комнаты: ");
            foreach (House houses in ListOfHouse)
            {
                if (houses.Rooms == 4)
                {
                    Console.WriteLine(houses.Number);
                }
            }
            Console.WriteLine("Список квартир, имеющих 2 комнаты и расположенных на этаже, который находится между 1 и 5: ");
            foreach (House houses in ListOfHouse)
            {
                if (houses.Floor >= 1 && houses.Floor <= 5)
                {
                    if (houses.Rooms == 2)
                    {
                        Console.WriteLine(houses.Number);
                    }
                }
            }
            Console.WriteLine(house1.Equals(house2));
            Console.WriteLine(house3.Rooms.Equals(house5.Rooms));
            Console.WriteLine(house4.Lifetime.ToString());
            Console.WriteLine(house1.GetHashCode());
            Console.WriteLine(house4.GetHashCode());

        }
        public partial class House
        {
            protected int id;
            public const int houses = 100;
            private int number;//номер квартиры
            private int area;//площадь квартиры
            private int floor;//этаж
            private int rooms;//количество комнат
            private string street;//улица
            private string building_type;//тип здания
            private int lifetime;//срок эксплуатации
            internal readonly uint NumHouse;
            public static int size;


            public int Number
            {
                get
                {
                    return this.number;
                }
                set
                {
                    this.number = value;
                }
            }
            public int Area
            {
                get
                {
                    return this.area;
                }
                set
                {
                    this.area = value;
                }
            }
            public int Floor
            {
                get
                {
                    return this.floor;
                }
                set
                {
                    this.floor = value;
                }
            }
            public string Street
            {
                get
                {
                    return this.street;
                }
                set
                {
                    this.street = value;
                }
            }
            public string Building_type
            {
                get
                {
                    return this.building_type;
                }
                set
                {
                    this.building_type = value;
                }

            }
            public int Lifetime
            {
                get
                {
                    return this.lifetime;
                }
                set
                {
                    this.lifetime = value;
                }

            }
            public int Rooms
            {
                get
                {
                    return this.rooms;
                }
                set
                {
                    this.rooms = value;
                }

            }


            static House()
            {
                size = 0;
            }
            public House(int number, int area, int floor, int rooms, string street, string building_type, int lifetime) 
            {
                size++;
                this.rooms = rooms;
                this.area = area;
                this.number = number;
                this.floor = floor;
                this.street = street;
                this.building_type = building_type;
                this.lifetime = lifetime;
                this.NumHouse = Hash(out int id, street, number);
            }
            public House(int number, int area, string building_type)
            {
                size++;
                this.number = number;
                this.area = area;
                this.building_type = building_type;
                this.NumHouse = Hash(out int id, street, number);
            }
            public House()
            {
                size++;
                number = 102;
                area = 25;
                floor = 6;
                street = "Ленинская";
                building_type = "Квартирный дом";
                lifetime = 10;
                this.NumHouse = Hash(out int id, street, number);
            }
            public string Repair(out string repair, int lifetime)
            {
                if (lifetime>15)
                {
                    repair = "Требуется ремонт!";
                }
                else
                {
                    repair="Ремонт не требуется";
                }
                Console.WriteLine(repair);
                return repair;

            }
            public void Show()
            {
                Console.WriteLine("_________________________________________________________________");
                Console.WriteLine("Номер квартиры: " + number);
                Console.WriteLine("Площадь:" + area + "\nЭтаж: " + floor + "\nКоличество комнат: " + rooms + "\nУлица: " + street + "\nТип здания: " + building_type + "\nСрок эксплуатации: " + lifetime);

            }
            //вычисление хэша
            public uint Hash(out int id, string street, int number)
            {
                Random random = new Random();
                id = random.Next(1, 15);
                int key = (number * 444 + street.Length) / id * 6;
                uint hash = (uint)key;
                return hash;
            }

        }
    }
}