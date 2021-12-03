using Appcent.Application.Features.ToDoLists.Queries.GetAllToDoLists;
using Appcent.Application.Features.ToDoLists.Queries.GetToDoListById;
using Appcent.Application.Interfaces;
using Appcent.Application.Mappings;
using Appcent.Application.Wrappers;
using Appcent.Domain.Entities;
using AutoMapper;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Appcent.Application.Features.ToDoLists.Queries.GetToDoListById.GetToDoListByIdQuery;

namespace Appcent.Test
{
    public class ToDoListTests
    {
        private Mock<IToDoListRepositoryAsync> toDoListRepository;
        private IMapper mapper;

        [SetUp]
        public void Setup()
        {
            toDoListRepository = new Mock<IToDoListRepositoryAsync>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new GeneralProfile());
            });
            mapper = mockMapper.CreateMapper();
        }

        private static List<ToDoList> GetSampleToDoList()
        {
            List<ToDoList> toDoLists = new()
            {
                new ToDoList { ObjectId = "3b185d67-a6ad-4594-87ed-8f8192d220f9", TaskName = "Task 1", TaskStatus = Status.InProgress, UserId = "test1@email.com", Created = DateTime.Today },
                new ToDoList { ObjectId = "6db866e6-7671-4641-8877-4e3db95e4325", TaskName = "Task 2", TaskStatus = Status.Done, UserId = "test2@email.com", Created = DateTime.Today },
                new ToDoList { ObjectId = "7a8cddf7-6e15-4eb9-b04d-908db0e7b9fa", TaskName = "Task 3", TaskStatus = Status.InProgress, UserId = "test3@email.com", Created = DateTime.Today }
            };
            return toDoLists;
        }        
        
        private static List<GetAllToDoListsViewModel> GetSampleToDoListViewModel()
        {
            var sampleList = JsonConvert.SerializeObject(GetSampleToDoList());
            var toDoLists = JsonConvert.DeserializeObject<List<GetAllToDoListsViewModel>>(sampleList);
            return toDoLists;
        }

        [Test]
        [TestCase("7a8cddf7-6e15-4eb9-b04d-908db0e7b9fa")]
        public async Task GetToDoList_ShouldReturnToDoListWithSameID(string key)
        {
            toDoListRepository.Setup(a => a.GetByIdAsync(key)).ReturnsAsync(GetSampleToDoList().Find(f => f.ObjectId == key));
            GetToDoListByIdQuery command = new() { Key = key };
            GetToDoListByIdQueryHandler handler = new(toDoListRepository.Object);

            var actionResult = await handler.Handle(command, new System.Threading.CancellationToken());
            var actual = JsonConvert.SerializeObject(actionResult.Data);
            var expected = JsonConvert.SerializeObject(GetSampleToDoList().Find(f => f.ObjectId == key));

            toDoListRepository.Verify(x => x.GetByIdAsync(key), Times.Once);
            Assert.IsInstanceOf<Response<ToDoList>>(actionResult);
            Assert.IsInstanceOf<ToDoList>(actionResult.Data);
            Assert.NotNull(actionResult.Data);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(GetSampleToDoList().Find(f => f.ObjectId == key).TaskName, actionResult.Data.TaskName);
            Assert.AreNotEqual("Test", actionResult.Data.TaskName);
            return;
        }

        [Test]
        public async Task GetAllToDoList_ShouldReturnToDoLists()
        {
            toDoListRepository.Setup(a => a.GetAllAsync()).ReturnsAsync(GetSampleToDoList());
            GetAllToDoListsQuery command = new() { };
            GetAllToDoListsQueryHandler handler = new(toDoListRepository.Object, mapper);

            var actionResult = await handler.Handle(command, new System.Threading.CancellationToken());
            var actual = JsonConvert.SerializeObject(actionResult.Data);
            var expected = JsonConvert.SerializeObject(GetSampleToDoListViewModel());

            toDoListRepository.Verify(x => x.GetAllAsync(), Times.Once);
            Assert.IsInstanceOf<Response<IEnumerable<GetAllToDoListsViewModel>>>(actionResult);
            Assert.IsInstanceOf<List<GetAllToDoListsViewModel>>(actionResult.Data);
            Assert.NotNull(actionResult.Data);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(3, GetSampleToDoListViewModel().Count);
            return;
        }
    }
}