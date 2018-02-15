using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace BashSoft
{
    public static class StudentsRepository
    {
        public static bool isDataInitialized = false;

        //Dictionary<Course name, Dictionary<Username, Grades>>
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        public static void InitializeData(string fileName)
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData(fileName);
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitializedException);
            }
        }

        private static void ReadData(string fileName)
        {
            string path = $"{SessionData.currentPath}\\{fileName}";
            if (File.Exists(path))
            {
                string pattern = @"(?<Course>[A-Z][a-z#+A-Z]*_[A-Z][a-z]{2}_[0-9]{4})\s+(?<Student>[A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(?<Mark>\d+)";

                Regex rgx = new Regex(pattern);

                string[] allInputLines = File.ReadAllLines(path);

                for (int line = 0; line < allInputLines.Length; line++)
                {
                    if (!string.IsNullOrWhiteSpace(allInputLines[line]) && rgx.IsMatch(allInputLines[line]))
                    {
                        Match currentMatch = rgx.Match(allInputLines[line]);

                        string courseName = currentMatch.Groups["Course"].Value;
                        string userName = currentMatch.Groups["Student"].Value;
                        int studentScoreOnTask;
                        bool hasParsedScore = int.TryParse(currentMatch.Groups["Mark"].Value, out studentScoreOnTask);

                        if (hasParsedScore && studentScoreOnTask >= 0 && studentScoreOnTask <= 100)
                        {
                            if (!studentsByCourse.ContainsKey(courseName))
                            {
                                studentsByCourse[courseName] = new Dictionary<string, List<int>>();
                            }

                            if (!studentsByCourse[courseName].ContainsKey(userName))
                            {
                                studentsByCourse[courseName][userName] = new List<int>();
                            }
                        }

                        studentsByCourse[courseName][userName].Add(studentScoreOnTask);
                    }
                }

                isDataInitialized = true;
                OutputWriter.WriteMessageOnNewLine("Data read!");
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }
        }

        private static bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                if (studentsByCourse.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                }
                return false;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }
            return false;
        }

        private static bool IsQueryForStudentPossible(string courseName, string studentUserName)
        {
            if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
            }
            return false;
        }

        public static void GetStudentScoresFromCourse(string courseName, string username)
        {
            if (IsQueryForStudentPossible(courseName, username))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(username, studentsByCourse[courseName][username]));
            }
        }

        public static void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}:");

                foreach (var studentMarkEntry in studentsByCourse[courseName])
                {
                    OutputWriter.PrintStudent(studentMarkEntry);
                }
            }
        }

        /// <summary>
        /// Bediator between the command interpreter and the filters/sorters. 
        /// </summary>
        /// <param name="courseName">Course name</param>
        /// <param name="givenFilter">Filter: excellent/average/poor</param>
        /// <param name="studentsToTake">Number of students to take (nullable)</param>
        public static void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                RepositoryFilters.FilterAndTake(studentsByCourse[courseName], givenFilter, studentsToTake.Value);
            }
        }

        public static void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }
                RepositorySorters.OrderAndTake(studentsByCourse[courseName], comparison, studentsToTake.Value);


            }
        }
    }
}
