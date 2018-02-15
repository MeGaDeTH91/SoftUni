namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RepositoryFilters
    {
        /// <summary>
        /// Filter students from a given course by given criteria
        /// </summary>
        /// <param name="wantedData"></param>
        /// <param name="wantedFilter"></param>
        /// <param name="studentsToTake"></param>
        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter,
            int studentsToTake)
        {
            if (wantedFilter == "excellent")
            {
                FilterAndTake(wantedData, x => x >= 5.0, studentsToTake);
            }
            else if (wantedFilter == "average")
            {
                FilterAndTake(wantedData, x => x < 5.00 && x >= 3.5, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                FilterAndTake(wantedData, x => x < 3.5, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
            }
        }

        /// <summary>
        /// Method which will actually do the filtration 
        /// </summary>
        /// <param name="wantedData">Dictionary that corresponds to the students with their scores from the seeked course.</param>
        /// <param name="givenFilter">Filter to use.</param>
        /// <param name="studentsToTake">The number of students to take.</param>
        private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter,
            int studentsToTake)
        {
            int counterForPrinted = 0;
            foreach (var userMarksKVP in wantedData)
            {
                double averageScore = userMarksKVP.Value.Average();
                var percentageOfAll = averageScore / 100;
                var mark = percentageOfAll * 4 + 2;

                if (givenFilter(mark))
                {
                    OutputWriter.PrintStudent(userMarksKVP);
                    counterForPrinted++;
                }

                if (counterForPrinted == studentsToTake)
                {
                    break;
                }
            }
        }
    }
}
