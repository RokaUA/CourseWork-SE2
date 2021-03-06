﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2.CourseWork.Models
{
    public class Student : Person
    {
        // публічні поля класу
        public Group Group { get; set; }
        public string GroupName {
            get => Group?.GroupName;
            set
            {
                Group?.DeleteStudent(this);
                Group = GroupsContainer.FindOrCreateGroup(value, Speciality);
                Group.AddStudent(this);
            }
        }
        public string Speciality { get => Group?.SpecialityFullName; set => Group.SpecialityFullName = value; }
        public int Course { get => Group.Course; }
        public decimal AverageScore { get; set; }
        // конструктори класу
        public Student() : base()
        {

        }
        public Student(string firstName, string middleName, string lastName, DateTime birthdayDate, string phoneNumber, Group group, decimal averageScore) : base(firstName, middleName, lastName, birthdayDate, phoneNumber)
        {
            Group = group;
            AverageScore = averageScore;
        }
        public Student(Student clone) : this(clone.FirstName, clone.MiddleName, clone.LastName, clone._birthdayDate, clone.PhoneNumber, clone.Group, clone.AverageScore)
        {

        }
        // перезавантажені оператори для зчитування / запису з файлів
        public static StreamWriter operator +(StreamWriter writer, Student student)
        {
            writer.WriteLine($"{student.FirstName},{student.MiddleName}" +
                $",{student.LastName},{student.BirthdayDate},{student.PhoneNumber}," +
                $"{student.GroupName},{student.Speciality},{student.AverageScore}");
            return writer;
        }
        public static StreamReader operator -(StreamReader reader, Student student)
        {
            string line = reader.ReadLine();
            string[] parts = line.Split(',');
            student.FirstName = parts[0]; student.MiddleName = parts[1]; student.LastName = parts[2]; student.BirthdayDate = parts[3];
            student.PhoneNumber = parts[4]; student.Group = GroupsContainer.FindOrCreateGroup(parts[5], parts[6]);
            student.AverageScore = Decimal.Parse(parts[7]);
            student.Group.AddStudent(student);
            return reader;
        }

        public override string ToString()
        {
            return $"{base.ToString()} {GroupName} {Speciality} {AverageScore}";
        }
    }
}
