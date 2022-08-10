using AuthGuard.Api.Controllers.v1;
using AuthGuard.Application.Dtos;
using AuthGuard.Application.Services.Abstractions;
using AuthGuard.Unit.Statics;
using EasyWeb.Core.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AuthGuard.Unit.Controllers.v1
{
    public class EmployeeControllerTest
    {
        [Theory, AutoMoqData]
        public async Task Advanced_Filter_Return_Ok_Object_Result(Mock<IEmployeeApplicationService> service, EmployeeFilterDto actual, List<EmployeeResponseDto> expected, int countExpected)
        {
            // Arrange
            var sut = new EmployeeController(service.Object);

            service.Setup(setup => setup.FilterAsync(actual)).ReturnsAsync(expected);
            service.Setup(setup => setup.CountAsync()).ReturnsAsync(countExpected);

            // Act

            var result = await sut.AdvancedFilterAsync(actual);

            // Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Theory, AutoMoqData]
        public async Task Advanced_Filter_Return_List_Of_Employee_Response(Mock<IEmployeeApplicationService> service, EmployeeFilterDto actual, List<EmployeeResponseDto> expected, int countExpected)
        {
            // Arrange
            var sut = new EmployeeController(service.Object);

            service.Setup(setup => setup.FilterAsync(actual)).ReturnsAsync(expected);
            service.Setup(setup => setup.CountAsync()).ReturnsAsync(countExpected);

            // Act

            var result = await sut.AdvancedFilterAsync(actual);

            // Assert
            var apiOkResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var model = Assert.IsType<ApiResult>(apiOkResult.Value);
            var response = model.Data;
            Assert.IsType<List<EmployeeResponseDto>>(response);
        }

        [Theory, AutoMoqData]
        public async Task Advanced_Filter_Return_Dictionary_String_Of_Int_Response(Mock<IEmployeeApplicationService> service, EmployeeFilterDto actual, List<EmployeeResponseDto> expected, int countExpected)
        {
            // Arrange
            var sut = new EmployeeController(service.Object);

            service.Setup(setup => setup.FilterAsync(actual)).ReturnsAsync(expected);
            service.Setup(setup => setup.CountAsync()).ReturnsAsync(countExpected);

            // Act

            var result = await sut.AdvancedFilterAsync(actual);

            // Assert
            var apiOkResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var model = Assert.IsType<ApiResult>(apiOkResult.Value);
            var response = model.Meta;
            Assert.IsType<Dictionary<string, int>>(response);
        }

        [Theory, AutoMoqData]
        public async Task Advanced_Filter_Not_Throw(Mock<IEmployeeApplicationService> service, EmployeeFilterDto actual, List<EmployeeResponseDto> expected, int countExpected)
        {
            // Arrange
            var sut = new EmployeeController(service.Object);

            service.Setup(setup => setup.FilterAsync(actual)).ReturnsAsync(expected);
            service.Setup(setup => setup.CountAsync()).ReturnsAsync(countExpected);

            // Act

            var action = async () => { await sut.AdvancedFilterAsync(actual); };

            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Theory, AutoMoqData]
        public async Task Advanced_Filter_Throw(Mock<IEmployeeApplicationService> service, EmployeeFilterDto actual, List<EmployeeResponseDto> expected, int countExpected)
        {
            // Arrange
            var sut = new EmployeeController(null);

            service.Setup(setup => setup.FilterAsync(actual)).ReturnsAsync(expected);
            service.Setup(setup => setup.CountAsync()).ReturnsAsync(countExpected);

            // Act

            var action = async () => { await sut.AdvancedFilterAsync(actual); };

            // Assert
            await action.Should().ThrowAsync<NullReferenceException>();
        }

        [Theory, AutoMoqData]
        public async Task Insert_Employee_Return_Ok_Object_Result(Mock<IEmployeeApplicationService> service, EmployeeRequestDto actual, EmployeeResponseDto expected)
        {
            // Arrange

            var sut = new EmployeeController(service.Object);
            service.Setup(setup => setup.AddAsync(actual)).ReturnsAsync(expected);

            // Act

            var result = await sut.InsertAsync(actual);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Theory, AutoMoqData]
        public async Task Insert_Employee_Return_Employee_Response(Mock<IEmployeeApplicationService> service, EmployeeRequestDto actual, EmployeeResponseDto expected)
        {
            // Arrange

            var sut = new EmployeeController(service.Object);
            service.Setup(setup => setup.AddAsync(actual)).ReturnsAsync(expected);

            // Act

            var result = await sut.InsertAsync(actual);

            // Assert
            var apiOkResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var model = Assert.IsType<ApiResult>(apiOkResult.Value);
            var response = model.Data;
            Assert.IsType<EmployeeResponseDto>(response);
        }

        [Theory, AutoMoqData]
        public async Task Insert_Employee_Not_Throw(Mock<IEmployeeApplicationService> service, EmployeeRequestDto actual, EmployeeResponseDto expected)
        {
            // Arrange

            var sut = new EmployeeController(service.Object);
            service.Setup(setup => setup.AddAsync(actual)).ReturnsAsync(expected);

            // Act

            var action = async () => { await sut.InsertAsync(actual); };

            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Theory, AutoMoqData]
        public async Task Insert_Employee_Throw(Mock<IEmployeeApplicationService> service, EmployeeRequestDto actual, EmployeeResponseDto expected)
        {
            // Arrange

            var sut = new EmployeeController(null);
            service.Setup(setup => setup.AddAsync(actual)).ReturnsAsync(expected);

            // Act

            var action = async () => { await sut.InsertAsync(actual); };

            // Assert
            await action.Should().ThrowAsync<NullReferenceException>();
        }

        // -- 
        [Theory, AutoMoqData]
        public async Task Update_Employee_Return_Ok_Object_Result(Mock<IEmployeeApplicationService> service, EmployeeRequestDto actual, Guid actualId, EmployeeResponseDto expected)
        {
            // Arrange

            var sut = new EmployeeController(service.Object);
            service.Setup(setup => setup.UpdateAsync(actualId, actual)).ReturnsAsync(expected);

            // Act

            var result = await sut.UpdateAsync(actualId, actual);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Theory, AutoMoqData]
        public async Task Update_Employee_Return_Employee_Response(Mock<IEmployeeApplicationService> service, EmployeeRequestDto actual, Guid actualId, EmployeeResponseDto expected)
        {
            // Arrange

            var sut = new EmployeeController(service.Object);
            service.Setup(setup => setup.UpdateAsync(actualId, actual)).ReturnsAsync(expected);

            // Act

            var result = await sut.UpdateAsync(actualId, actual);

            // Assert
            var apiOkResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var model = Assert.IsType<ApiResult>(apiOkResult.Value);
            var response = model.Data;
            Assert.IsType<EmployeeResponseDto>(response);
        }

        [Theory, AutoMoqData]
        public async Task Update_Employee_Not_Throw(Mock<IEmployeeApplicationService> service, EmployeeRequestDto actual, Guid actualId, EmployeeResponseDto expected)
        {
            // Arrange

            var sut = new EmployeeController(service.Object);
            service.Setup(setup => setup.UpdateAsync(actualId, actual)).ReturnsAsync(expected);

            // Act

            var action = async () => { await sut.UpdateAsync(actualId, actual); };

            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Theory, AutoMoqData]
        public async Task Update_Employee_Throw(Mock<IEmployeeApplicationService> service, EmployeeRequestDto actual, Guid actualId, EmployeeResponseDto expected)
        {
            // Arrange

            var sut = new EmployeeController(null);
            service.Setup(setup => setup.UpdateAsync(actualId, actual)).ReturnsAsync(expected);

            // Act

            var action = async () => { await sut.UpdateAsync(actualId, actual); };

            // Assert
            await action.Should().ThrowAsync<NullReferenceException>();
        }

        [Theory, AutoMoqData]
        public async Task Delete_Employee_No_Content_Result(Mock<IEmployeeApplicationService> service, Guid actual, Task expected)
        {
            // Arrange
            var sut = new EmployeeController(service.Object);

            service.Setup(setup => setup.DeleteAsync(actual)).Returns(expected);

            // Act

            var result = await sut.DeleteAsync(actual);

            // Assert

            Assert.IsType<NoContentResult>(result);
        }

        [Theory, AutoMoqData]
        public async Task Delete_Employee_Not_Throw(Mock<IEmployeeApplicationService> service, Guid actual, Task expected)
        {
            // Arrange
            var sut = new EmployeeController(service.Object);

            service.Setup(setup => setup.DeleteAsync(actual)).Returns(expected);

            // Act

            var action = async () => { await sut.DeleteAsync(actual); };

            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Theory, AutoMoqData]
        public async Task Delete_Employee_Throw(Mock<IEmployeeApplicationService> service, Guid actual, Task expected)
        {
            // Arrange
            var sut = new EmployeeController(null);

            service.Setup(setup => setup.DeleteAsync(actual)).Returns(expected);

            // Act

            var action = async () => { await sut.DeleteAsync(actual); };

            // Assert
            await action.Should().ThrowAsync<NullReferenceException>();
        }

        [Theory, AutoMoqData]
        public async Task Find_Employee_Return_Ok_Object_Result(Mock<IEmployeeApplicationService> service, Guid actual, EmployeeResponseDto expected)
        {
            // Arrange
            
            var sut = new EmployeeController(service.Object);
            service.Setup(setup => setup.FindAsync(actual)).ReturnsAsync(expected);

            // Act
            var result = await sut.FindAsync(actual);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Theory, AutoMoqData]
        public async Task Find_Employee_Return_Employee_Response(Mock<IEmployeeApplicationService> service, Guid actual, EmployeeResponseDto expected)
        {
            // Arrange

            var sut = new EmployeeController(service.Object);
            service.Setup(setup => setup.FindAsync(actual)).ReturnsAsync(expected);

            // Act
            var result = await sut.FindAsync(actual);

            // Assert
            var apiOkResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var model = Assert.IsType<ApiResult>(apiOkResult.Value);
            var response = model.Data;
            Assert.IsType<EmployeeResponseDto>(response);
        }


        [Theory, AutoMoqData]
        public async Task Find_Employee_Not_Throw(Mock<IEmployeeApplicationService> service, Guid actual, EmployeeResponseDto expected)
        {
            // Arrange

            var sut = new EmployeeController(service.Object);
            service.Setup(setup => setup.FindAsync(actual)).ReturnsAsync(expected);

            // Act
            var action = async () => { await sut.FindAsync(actual); };

            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Theory, AutoMoqData]
        public async Task Find_Employee_Throw(Mock<IEmployeeApplicationService> service, Guid actual, EmployeeResponseDto expected)
        {
            // Arrange

            var sut = new EmployeeController(null);
            service.Setup(setup => setup.FindAsync(actual)).ReturnsAsync(expected);

            // Act
            var action = async () => { await sut.FindAsync(actual); };

            // Assert
            await action.Should().ThrowAsync<NullReferenceException>();
        }

    }
}
