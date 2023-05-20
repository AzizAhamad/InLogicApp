using System;
using InLogicApp.API.Controllers;
using InLogicApp.API.Entities;
using InLogicApp.API.Model.Users;
using InLogicApp.API.Repositories;
using InLogicApp.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Moq;

namespace InLogicApp.Tests
{

   

    public class UserTest
	{

        [Fact]
        public async Task Test_POST_ReturnsUpdateUser_ValidModelState()
        {
            // Arrange
            int testId = 2;
            User r = GetTestRegisterRecord();

            var mockRepo = new Mock<IUserService>();
            mockRepo.Setup(repo => repo.GetById(testId)).Returns(GetTestRegisterRecord());

            var controller = new UsersController(mockRepo.Object);
            controller.ModelState.AddModelError("FirstName", "FirstName is required");

            // Act
            var result = await controller.TryUpdateModelAsync(r);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<User>(viewResult.ViewData.Model);
            Assert.Equal(testId, model.Id);
        }


        private User GetTestRegisterRecord()
        {
            var r = new User()
            {
                Id = 1,
                FirstName = "test name",
                LastName = "test last name",
                Username ="testname",
                Email="test@test.com",
                PasswordHash ="password@12345"
            };
            return r;
        }

    }
}

