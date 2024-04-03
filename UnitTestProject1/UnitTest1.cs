using Homework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<string> testlist = new List<string>() { ".......", ".......", ".......", ".###...", ".###...", "......." };
            int testN = 6;
            int testM = 7;
            string expectedValue = "3 1\r\n3 2\r\n3 3\r\n3 4\r\n3 5\r\n4 5\r\n5 5\r\n6 5\r\n6 4\r\n6 3\r\n6 2\r\n6 1\r\n5 1\r\n4 1\r\n";
            Form1.Calculate(testlist, testN, testM);
            string Value = Homework.Form1.text;
            Assert.AreEqual(expectedValue, Value);
        }
        [TestMethod]
        public void TestMethod2()
        {
            List<string> testlist = new List<string>() { "..........", ".....#....", "....###...", "...####...", "...#####..", "..........", "..........", "..........", "..........", ".........." };
            int testN = 10;
            int testM = 10;
            string expectedValue = "1 5\r\n1 6\r\n1 7\r\n2 7\r\n2 8\r\n3 8\r\n4 8\r\n4 9\r\n5 9\r\n6 9\r\n6 8\r\n6 7\r\n6 6\r\n6 5\r\n6 4\r\n6 3\r\n5 3\r\n4 3\r\n3 3\r\n3 4\r\n2 4\r\n2 5\r\n";
            Form1.Calculate(testlist, testN, testM);
            string Value = Homework.Form1.text;
            Assert.AreEqual(expectedValue, Value);
        }
        [TestMethod]
        public void TestMethod3()
        {
            List<string> testlist = new List<string>() { ".....", ".##..", ".##..", ".....", "....." };
            int testN = 5;
            int testM = 5;
            bool expectedValue = true;
            bool Value = Form1.Calculate(testlist, testN, testM);
            Assert.AreEqual(expectedValue, Value);
        }
        [TestMethod]
        public void TestMethod4()
        {
            List<string> testlist = new List<string>() { ".......", ".......", ".......", ".......", ".###...", ".###...", "......." };
            int testN = 6;
            int testM = 7;
            bool expectedValue = false;
            bool Value = Form1.Calculate(testlist, testN, testM);
            Assert.AreEqual(expectedValue, Value);
        }
        [TestMethod]
        public void TestMethod5()
        {
            List<string> testlist = new List<string>() { ".", "......", ".......", ".......", ".###...", ".###...", "......." };
            int testN = 6;
            int testM = 7;
            bool expectedValue = false;
            bool Value = Form1.Calculate(testlist, testN, testM);
            Assert.AreEqual(expectedValue, Value);
        }
        [TestMethod]
        public void TestMethod6()
        {
            List<string> testlist = new List<string>() { "...", ".#.", "", "..." };
            int testN = 3;
            int testM = 3;
            bool expectedValue = false;
            bool Value = Form1.Calculate(testlist, testN, testM);
            Assert.AreEqual(expectedValue, Value);
        }
        [TestMethod]
        public void TestEmptyMap()
        {
            List<string> testlist = new List<string>() { "" };
            int testN = 99;
            int testM = 13;
            bool expectedValue = false;
            bool Value = Form1.Calculate(testlist, testN, testM);
            Assert.AreEqual(expectedValue, Value);
        }
        [TestMethod]
        public void TestOutOfBounds()
        {
            List<string> testlist = new List<string>() { ".##..", ".##.."};
            int testN = 2;
            int testM = 2;
            bool expectedValue = false;
            bool Value = Form1.Calculate(testlist, testN, testM);
            Assert.AreEqual(expectedValue, Value);
        }
    }
}
