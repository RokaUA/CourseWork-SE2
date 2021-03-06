﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2.CourseWork.Models
{
    public class Person
    {
        // протектед поле для дати народження
        protected DateTime _birthdayDate;
        // публічні поля класу (гетери і сетери)
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string BirthdayDate { get => _birthdayDate.ToString("yyyy-MM-dd"); set => _birthdayDate = DateTime.Parse(value); }
        public string PhoneNumber { get; set; }
        public string FullName() => $"{LastName} {FirstName} {MiddleName}";
        // Конструктори класу
        public Person()
        {

        }
        public Person(string firstName, string middleName, string lastName, DateTime birthdayDate, string phoneNumber)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            _birthdayDate = birthdayDate;
            PhoneNumber = phoneNumber;
        }
        public Person(Person clone) : this(clone.FirstName, clone.MiddleName, clone.LastName, clone._birthdayDate, clone.PhoneNumber)
        {

        }
        public override string ToString()
        {
            return $"{FullName()} {BirthdayDate} {PhoneNumber}";
        }
        // перезагружені оператори для запису / зчитування з файлів
        public static StreamWriter operator +(StreamWriter writer, Person person)
        {
            writer.WriteLine($"{person.LastName},{person.FirstName}" +
                $",{person.MiddleName},{person.BirthdayDate},{person.PhoneNumber}");
            return writer;
        }
        public static StreamReader operator -(StreamReader reader, Person person)
        {
            string line = reader.ReadLine();
            string[] parts = line.Split(',');
            person.LastName = parts[0]; person.FirstName = parts[1]; person.MiddleName = parts[2]; person.BirthdayDate = parts[3];
            person.PhoneNumber = parts[4];
            return reader;
        }
    }
}
