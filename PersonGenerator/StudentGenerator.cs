﻿using CsvHelper;
using FizzWare.NBuilder;
using SE2.CourseWork.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2.CourseWork.Generators
{
    public class StudentGenerator
    {
        private static Random random = new Random();
        private static readonly string[] Specialities = { "ПЗ", "КН", "БД", "ІР", "КІ", "СА" };
        private static readonly Dictionary<string, string> fullName = new Dictionary<string, string> { { "ПЗ", "Програмне забезпечення" }, { "КН", "Комп'ютерні науки" }, { "БД", "Бази даних" }, { "ІР", "Інтернет речі" }, { "КІ", "Комп'ютерна інженерія" }, { "СА", "Системний аналіз" } };
        public static void GenerateData() => GenerateData("student.dat");
        public static void GenerateData(string fileName) => GenerateData(random.Next(5, 100), fileName);
        public static void GenerateData(int numberOfItems) => GenerateData(numberOfItems, "student.dat");
        public static void GenerateData(int numberOfItems, string fileName)
        {
            Console.WriteLine("Generating students");
            StreamWriter file = new StreamWriter(fileName);
            try
            {
                IList<Student> data = GenerateList(numberOfItems);
                foreach (Student student in data)
                {
                    file += student;
                }
            }
            finally
            {
                file.Close();
            }
        }
        protected static IList<Student> GenerateList(int numberOfItems)
        {
            IList<Student> list = new List<Student>(numberOfItems);
            for (int i = 0; i < numberOfItems; i++)
            {
                list.Add(new Student(Faker.Name.First(), Faker.Name.First(), Faker.Name.Last(), RandomDay(), RandomNumber(), RandomGroup(), decimal.Round((decimal)random.NextDouble() * 100, 2)));
            }
            return list;
        }
        protected static DateTime RandomDay()
        {
            DateTime start = new DateTime(1990, 1, 1);
            DateTime end = new DateTime(2002, 1, 1);
            int range = (end - start).Days;
            return start.AddDays(random.Next(range));
        }
        protected static Group RandomGroup()
        {
            string speciality = Specialities[random.Next(Specialities.Length - 1)];
            return new Group(speciality,  fullName[speciality], random.Next(1, 7), random.Next(1, 15), null);
        }
        protected static string RandomNumber()
        {
            string number = "+380";
            for (int i = 0; i < 9; i++)
                number += random.Next(10);
            return number;
        }
    }
}
