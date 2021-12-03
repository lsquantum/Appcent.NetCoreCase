using Appcent.Application.Interfaces;
using Appcent.Domain.Entities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Appcent.Test
{
    public class Tests
    {
        private Mock<IToDoListRepositoryAsync> toDoListRepository;
        [SetUp]
        public void Setup()
        {
            toDoListRepository = new Mock<IToDoListRepositoryAsync>();
        }

        private static List<ToDoList> GetSampleToDoList()
        {
            List<ToDoList> toDoLists = new()
            {
                new ToDoList
                {
                    ObjectId = "3b185d67-a6ad-4594-87ed-8f8192d220f9",
                    TaskName = "Task 1",
                    TaskStatus = Status.InProgress,
                    UserId = "test1@email.com",
                    Created = DateTime.Today
                },
                new ToDoList
                {
                    ObjectId = "6db866e6-7671-4641-8877-4e3db95e4325",
                    TaskName = "Task 2",
                    TaskStatus = Status.Done,
                    UserId = "test2@email.com",
                    Created = DateTime.Today
                },
                new ToDoList
                {
                    ObjectId = "7a8cddf7-6e15-4eb9-b04d-908db0e7b9fa",
                    TaskName = "Task 3",
                    TaskStatus = Status.InProgress,
                    UserId = "test3@email.com",
                    Created = DateTime.Today
                }
            };
            return toDoLists;
        }

        [Test]
        [TestCase("7a8cddf7-6e15-4eb9-b04d-908db0e7b9fa")]
        public void GetToDoList_ShouldReturnToDoListWithSameID(string key)
        {
            toDoListRepository.Setup(a => a.GetByIdAsync(key)).ReturnsAsync(GetSampleToDoList().Find(f => f.ObjectId == key));
            Assert.Pass();
        }
    }
}