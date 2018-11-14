using DotNetCorePractice.Services.Implementation;
using Moq;
using Xunit;

namespace DotNetCorePracticeTests.tests.Services
{
    public class TodoListServiceTests
    {
        private TodoListService testable = new TodoListService();
        
        [Fact]
        public void ShouldReturnNewItem()
        {
            const string expected = "Create new item to do something.";            
            Assert.Equal(expected, testable.Create("to do something"));
        }

        [Fact]
        public void ShouldDeleteItem()
        {
            const string expected = "Delete 1 is done.";
            Assert.Equal(expected, testable.Delete(1));
        }

        [Fact]
        public void ShouldFindItemById()
        {
            const string expected = "New Item";
            Assert.Equal(expected, testable.Find(It.IsAny<int>()));
        }

        [Fact]
        public void ShouldGetAllItems()
        {
            const string item = "New Item";
            Assert.Equal(1, testable.GetAll().Count);
            Assert.Contains(item, testable.GetAll());
        }

        [Fact]
        public void ShouldUpdateSpecificItemWithValue()
        {
            const string expected = "Update 1 to New Value is done.";
            Assert.Equal(expected, testable.Update(1, "New Value"));
        }
    }
}