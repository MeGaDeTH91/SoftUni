﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitFortressTests.Performance
{
    using System.Diagnostics;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PerformanceGetMines : BaseTestClass
    {
         [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceGetMines_WithRandomAmounts1()
        {
            FileStream input = File.Open("../../Tests/GetMines/get.0.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                        .ToList();



                for (int i = 0; i < commands.Count; i++)
                {
                    switch (commands[i][0])
                    {
                        case "player":
                            this.PitFortressCollection.AddPlayer(commands[i][1], int.Parse(commands[i][2]));
                            break;
                        case "mine":
                            this.PitFortressCollection.SetMine(
                            commands[i][1],
                            int.Parse(commands[i][2]),
                            int.Parse(commands[i][3]),
                            int.Parse(commands[i][4]));
                            break;
                    }
                }

                Assert.AreEqual(commands.Count - 8, this.PitFortressCollection.MinesCount, "Mines Count did not match!");
                
                Stopwatch timer = new Stopwatch();
                timer.Start();

                var mines = this.PitFortressCollection.GetMines();
                
                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 10);

                //using (
                //    StreamWriter writer =
                //        new StreamWriter(File.Create("../../Results/GetMines/get.0.result.txt")))
                //{
                //    foreach (var mine in mines)
                //    {
                //        writer.WriteLine("{0} {1} {2} {3} {4}", mine.Delay, mine.Id, mine.XCoordinate, mine.Damage, mine.Player.Name);
                //    }
                //}

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/GetMines/get.0.result.txt", FileMode.Open)))
                {
                    foreach (var mine in mines)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), mine.Delay, "Mine Delay did not match!");
                        Assert.AreEqual(int.Parse(line[1]), mine.Id, "Mine Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), mine.XCoordinate, "Mine Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[3]), mine.Damage, "Mine Damage did not match!");
                        Assert.AreEqual(line[4], mine.Player.Name, "Mine Player did not match!");
                    }
                }
            }
        }


        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceGetMines_WithRandomAmounts2()
        {
            FileStream input = File.Open("../../Tests/GetMines/get.1.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                        .ToList();

                for (int i = 0; i < commands.Count; i++)
                {
                    switch (commands[i][0])
                    {
                        case "player":
                            this.PitFortressCollection.AddPlayer(commands[i][1], int.Parse(commands[i][2]));
                            break;
                        case "mine":
                            this.PitFortressCollection.SetMine(
                            commands[i][1],
                            int.Parse(commands[i][2]),
                            int.Parse(commands[i][3]),
                            int.Parse(commands[i][4]));
                            break;
                    }
                }



                Assert.AreEqual(commands.Count - 8, this.PitFortressCollection.MinesCount, "Mines Count did not match!");

                Stopwatch timer = new Stopwatch();
                timer.Start();

                var mines = this.PitFortressCollection.GetMines();

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 10);

                //using (
                //    StreamWriter writer =
                //        new StreamWriter(File.Create("../../Results/GetMines/get.1.result.txt")))
                //{
                //    foreach (var mine in mines)
                //    {
                //        writer.WriteLine("{0} {1} {2} {3} {4}", mine.Delay, mine.Id, mine.XCoordinate, mine.Damage, mine.Player.Name);
                //    }
                //}

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/GetMines/get.1.result.txt", FileMode.Open)))
                {
                    foreach (var mine in mines)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), mine.Delay, "Mine Delay did not match!");
                        Assert.AreEqual(int.Parse(line[1]), mine.Id, "Mine Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), mine.XCoordinate, "Mine Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[3]), mine.Damage, "Mine Damage did not match!");
                        Assert.AreEqual(line[4], mine.Player.Name, "Mine Player did not match!");
                    }
                }
            }
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceGetMines_WithRandomAmounts3()
        {
            FileStream input = File.Open("../../Tests/GetMines/get.2.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                        .ToList();

                for (int i = 0; i < commands.Count; i++)
                {
                    switch (commands[i][0])
                    {
                        case "player":
                            this.PitFortressCollection.AddPlayer(commands[i][1], int.Parse(commands[i][2]));
                            break;
                        case "mine":
                            this.PitFortressCollection.SetMine(
                            commands[i][1],
                            int.Parse(commands[i][2]),
                            int.Parse(commands[i][3]),
                            int.Parse(commands[i][4]));
                            break;
                    }
                }


                Assert.AreEqual(commands.Count - 8, this.PitFortressCollection.MinesCount, "Mines Count did not match!");

                Stopwatch timer = new Stopwatch();
                timer.Start();

                var mines = this.PitFortressCollection.GetMines();

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 10);

                //using (
                //    StreamWriter writer =
                //        new StreamWriter(File.Create("../../Results/GetMines/get.2.result.txt")))
                //{
                //    foreach (var mine in mines)
                //    {
                //        writer.WriteLine("{0} {1} {2} {3} {4}", mine.Delay, mine.Id, mine.XCoordinate, mine.Damage, mine.Player.Name);
                //    }
                //}

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/GetMines/get.2.result.txt", FileMode.Open)))
                {
                    foreach (var mine in mines)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), mine.Delay, "Mine Delay did not match!");
                        Assert.AreEqual(int.Parse(line[1]), mine.Id, "Mine Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), mine.XCoordinate, "Mine Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[3]), mine.Damage, "Mine Damage did not match!");
                        Assert.AreEqual(line[4], mine.Player.Name, "Mine Player did not match!");
                    }
                }
            }
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceGetMines_WithRandomAmounts4()
        {
            FileStream input = File.Open("../../Tests/GetMines/get.3.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                        .ToList();

                for (int i = 0; i < commands.Count; i++)
                {
                    switch (commands[i][0])
                    {
                        case "player":
                            this.PitFortressCollection.AddPlayer(commands[i][1], int.Parse(commands[i][2]));
                            break;
                        case "mine":
                            this.PitFortressCollection.SetMine(
                            commands[i][1],
                            int.Parse(commands[i][2]),
                            int.Parse(commands[i][3]),
                            int.Parse(commands[i][4]));
                            break;
                    }
                }


                Assert.AreEqual(commands.Count - 8, this.PitFortressCollection.MinesCount, "Mines Count did not match!");

                Stopwatch timer = new Stopwatch();
                timer.Start();

                var mines = this.PitFortressCollection.GetMines();

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 10);

                //using (
                //    StreamWriter writer =
                //        new StreamWriter(File.Create("../../Results/GetMines/get.3.result.txt")))
                //{
                //    foreach (var mine in mines)
                //    {
                //        writer.WriteLine("{0} {1} {2} {3} {4}", mine.Delay, mine.Id, mine.XCoordinate, mine.Damage, mine.Player.Name);
                //    }
                //}

                using (StreamReader reader2 = new StreamReader(File.Open("../../Results/GetMines/get.3.result.txt", FileMode.Open)))
                {
                    foreach (var mine in mines)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), mine.Delay, "Mine Delay did not match!");
                        Assert.AreEqual(int.Parse(line[1]), mine.Id, "Mine Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), mine.XCoordinate, "Mine Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[3]), mine.Damage, "Mine Damage did not match!");
                        Assert.AreEqual(line[4], mine.Player.Name, "Mine Player did not match!");
                    }
                }
            }
        }

        [TestCategory("Performance")]
        [TestMethod]
        public void PerformanceGetMines_WithRandomAmounts5()
        {
            FileStream input = File.Open("../../Tests/GetMines/get.4.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(input))
            {
                var commands =
                    reader.ReadToEnd()
                        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                        .ToList();

                for (int i = 0; i < commands.Count; i++)
                {
                    switch (commands[i][0])
                    {
                        case "player":
                            this.PitFortressCollection.AddPlayer(commands[i][1], int.Parse(commands[i][2]));
                            break;
                        case "mine":
                            this.PitFortressCollection.SetMine(
                                commands[i][1],
                                int.Parse(commands[i][2]),
                                int.Parse(commands[i][3]),
                                int.Parse(commands[i][4]));
                            break;
                    }
                }

                Assert.AreEqual(commands.Count - 8, this.PitFortressCollection.MinesCount, "Mines Count did not match!");

                Stopwatch timer = new Stopwatch();
                timer.Start();

                var mines = this.PitFortressCollection.GetMines();

                timer.Stop();
                Assert.IsTrue(timer.ElapsedMilliseconds < 10);

                //using (
                //    StreamWriter writer =
                //        new StreamWriter(File.Create("../../Results/GetMines/get.4.result.txt")))
                //{
                //    foreach (var mine in mines)
                //    {
                //        writer.WriteLine("{0} {1} {2} {3} {4}", mine.Delay, mine.Id, mine.XCoordinate, mine.Damage, mine.Player.Name);
                //    }
                //}

                using (
                    StreamReader reader2 =
                        new StreamReader(File.Open("../../Results/GetMines/get.4.result.txt", FileMode.Open)))
                {
                    foreach (var mine in mines)
                    {
                        var line = reader2.ReadLine().Split(' ');
                        Assert.AreEqual(int.Parse(line[0]), mine.Delay, "Mine Delay did not match!");
                        Assert.AreEqual(int.Parse(line[1]), mine.Id, "Mine Id did not match!");
                        Assert.AreEqual(int.Parse(line[2]), mine.XCoordinate, "Mine Coordinates did not match!");
                        Assert.AreEqual(int.Parse(line[3]), mine.Damage, "Mine Damage did not match!");
                        Assert.AreEqual(line[4], mine.Player.Name, "Mine Player did not match!");
                    }
                }
            }
        }
    }
}
