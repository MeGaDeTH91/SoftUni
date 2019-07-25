namespace _04.BestLectSchedule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static HashSet<Lecture> lectures = new HashSet<Lecture>();
        private static IList<Lecture> resultLectures = new List<Lecture>();

        public static void Main()
        {
            ReadInput();

            ChooseLectures();

            Console.WriteLine($"Lectures ({resultLectures.Count}):");

            foreach (var lecture in resultLectures)
            {
                Console.WriteLine($"{lecture.StartTime}-{lecture.EndTime} -> {lecture.Name}");
            }
        }

        private static void ChooseLectures()
        {
            while (lectures.Count > 0)
            {
                var chosen = lectures.OrderBy(x => x.EndTime)
                    .FirstOrDefault();

                lectures.RemoveWhere(x => x.EndTime <= chosen.EndTime || x.StartTime < chosen.EndTime);

                resultLectures.Add(chosen);
            }
        }

        private static void ReadInput()
        {
            string[] lectureCountTokens = Console.ReadLine()
                            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

            int lecturesCount = int.Parse(lectureCountTokens[1]);

            for (int i = 0; i < lecturesCount; i++)
            {
                string[] lineTokens = Console.ReadLine()
                    .Split(new[] { " ", ":", "-" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string lectureName = lineTokens[0];
                int lectureStart = int.Parse(lineTokens[1]);
                int lectureEnd = int.Parse(lineTokens[2]);

                Lecture lecture = new Lecture()
                {
                    Name = lectureName,
                    StartTime = lectureStart,
                    EndTime = lectureEnd
                };

                lectures.Add(lecture);
            }
        }

        private class Lecture
        {
            public string Name { get; set; }

            public int StartTime { get; set; }

            public int EndTime { get; set; }
        }
    }
}
