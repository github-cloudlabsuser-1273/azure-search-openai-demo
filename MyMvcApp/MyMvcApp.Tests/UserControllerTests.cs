using Xunit;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Controllers;
using MyMvcApp.Models;
using MyMvcApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MyMvcApp.Tests
{
    public class UserControllerTests
    {
        private AppDbContext GetDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;
            return new AppDbContext(options);
        }

        [Fact]
        public void Index_ReturnsViewResult_WithListOfUsers()
        {
            var context = GetDbContext("IndexTest");
            context.Users.Add(new User { Name = "Test", Email = "test@email.com", Phone = "123" });
            context.SaveChanges();
            var controller = new UserController(context);
            var result = controller.Index() as ViewResult;
            var model = Assert.IsAssignableFrom<IEnumerable<User>>(result.Model);
            Assert.Single(model);
        }

        [Fact]
        public void Details_ReturnsNotFound_WhenIdIsNull()
        {
            var context = GetDbContext("DetailsNullTest");
            var controller = new UserController(context);
            var result = controller.Details(null);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Details_ReturnsNotFound_WhenUserNotFound()
        {
            var context = GetDbContext("DetailsNotFoundTest");
            var controller = new UserController(context);
            var result = controller.Details(1);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Create_AddsUser_AndRedirects()
        {
            var context = GetDbContext("CreateTest");
            var controller = new UserController(context);
            var user = new User { Name = "Test", Email = "test@email.com", Phone = "123" };
            var result = controller.Create(user) as RedirectToActionResult;
            Assert.Equal("Index", result.ActionName);
            Assert.Single(context.Users);
        }

        [Fact]
        public void Edit_ReturnsNotFound_WhenIdMismatch()
        {
            var context = GetDbContext("EditIdMismatchTest");
            var controller = new UserController(context);
            var user = new User { Id = 2, Name = "Test", Email = "test@email.com", Phone = "123" };
            var result = controller.Edit(1, user);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteConfirmed_RemovesUser_AndRedirects()
        {
            var context = GetDbContext("DeleteTest");
            var user = new User { Name = "Test", Email = "test@email.com", Phone = "123" };
            context.Users.Add(user);
            context.SaveChanges();
            var controller = new UserController(context);
            var result = controller.DeleteConfirmed(user.Id) as RedirectToActionResult;
            Assert.Equal("Index", result.ActionName);
            Assert.Empty(context.Users);
        }
    }
}
