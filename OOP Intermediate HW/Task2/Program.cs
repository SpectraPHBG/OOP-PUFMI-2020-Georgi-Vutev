using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Task2
{
    class Program
    {
        class Car
        {
            public int HorsePower { get; set; }
            public string Brand { get; set; }
            public int Weight { get; set; }
            public decimal AccelerationTo100 { get; set; }
            public decimal AccelerationFrom100To200 { get; private set; }
            public int Boost
            {
                set
                {
                    if (value == 100)
                    {
                        AccelerationTo100 = (decimal)1000 / (2 * HorsePower);
                        AccelerationTo100 = AccelerationTo100 - (AccelerationTo100 * 30) / 100;
                        AccelerationFrom100To200 = (decimal)1000 / HorsePower;

                    }
                    else if (value == 200)
                    {
                        AccelerationTo100 = (decimal)1000 / (2 * HorsePower);
                        AccelerationFrom100To200 = (decimal)1000 / HorsePower;
                        AccelerationFrom100To200 = AccelerationFrom100To200 - (AccelerationFrom100To200 * 20) / 100;
                    }
                    else
                    {
                        AccelerationTo100 = (decimal)1000 / (2 * HorsePower);
                        AccelerationFrom100To200 = (decimal)1000 / HorsePower;
                    }
                    AccelerationTo100 = Math.Round(AccelerationTo100, 2);
                    AccelerationFrom100To200 = Math.Round(AccelerationFrom100To200, 2);
                }
            }

            public Car(string brand, int horsePower, int weight, int boost)
            {
                this.Brand = brand;
                this.HorsePower = horsePower;
                this.Weight = weight;
                this.Boost = boost;
            }
        }
        class Participant
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Car MyCar { get; set; }
            public int Points { get; set; }
            public Participant(string firstName, string lastName, string carBrand, int weight, int horsePower, int boost)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                MyCar = new Car(carBrand,horsePower,weight,boost);
            }
        }
        static void Main(string[] args)
        {
            List<Participant> participants = new List<Participant>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "end")
                {
                    break;
                }
                string[] inputData = input.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries).Select(str => str.Trim()).ToArray();
                string firstName = inputData[0];
                string lastName = inputData[1];
                string brand = inputData[2];
                int weight = int.Parse(inputData[3]);
                int horsePower = int.Parse(inputData[4]);
                int boost = 0;
                if (inputData[5].ToLower() == "do-100") boost = 100;
                if (inputData[5].ToLower() == "do-200") boost = 200;
                participants.Add(new Participant(firstName, lastName, brand, weight, horsePower, boost));
            }
            for (int i = 0; i < participants.Count; i++)
            {
                for (int j = 0; j < participants.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    else
                    {
                        if (participants[i].MyCar.AccelerationTo100 < participants[j].MyCar.AccelerationTo100)
                        {
                            participants[i].Points += 3;
                        }
                        if ((participants[i].MyCar.AccelerationTo100 + participants[i].MyCar.AccelerationFrom100To200) < (participants[j].MyCar.AccelerationTo100 + participants[j].MyCar.AccelerationFrom100To200))
                        {
                            participants[i].Points += 3;
                        }
                    }

                }
            }
            foreach (var participant in participants.OrderByDescending(p => p.Points))
            {
                Console.WriteLine($"{participant.FirstName} {participant.Points}");
            }
        }
    }
}
