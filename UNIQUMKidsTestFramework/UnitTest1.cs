﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UNIQUMkidsCore;

namespace UNIQUMKidsTestFramework
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGettingParent()
        {
            Assert.AreEqual(1, GetDataFromDB.GetParent().Find(x => x.id_Parent == 1).id_Parent);
            Assert.AreEqual("Данил", GetDataFromDB.GetParent().Find(x => x.id_Parent == 2003).Name);
        }

        [TestMethod]
        public void TestGettingChild()
        {
            Child child = GetDataFromDB.GetChild().Find(x => x.id_Child == 1);
            Assert.AreEqual(child.Name, "Мелания");
            Assert.AreEqual(child.Year, 5);
            Assert.AreEqual(child.Surname, "Барышева");
        }

        [TestMethod]
        public void TestConnectLessonChild()
        {
            LessonChild lessonChild = GetDataFromDB.GetLessonChild().Find(x => x.id_LessonChild == 1);
            Assert.AreEqual(lessonChild.id_Lesson, 1);
            Assert.AreEqual(lessonChild.id_Child, 2);
        }
    }
}
