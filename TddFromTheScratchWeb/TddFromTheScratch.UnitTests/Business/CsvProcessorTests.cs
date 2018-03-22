using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TddFromTheScratch.Business;
using TddFromTheScratch.Business.Enumerations;
using FluentAssertions;

namespace TddFromTheScratch.UnitTests.Business
{
    [TestClass]
    public class CsvProcessorTests
    {
        [TestMethod]
        public void ProcessFile_FilenameIsEmpty_ReturnsErrorStatus()
        {
            //Arrange
            var expected = ProcessFileStatuses.Error;

            var csvProcessor = new CsvProcessor();

            //Act
            var result = csvProcessor.ProcessFile(string.Empty);

            //Assert
            Assert.AreEqual(expected, result.Status);
        }

        [TestMethod]
        public void ProcessFile_FilenameIsEmpty_ReturnsAnEmptyListOfItems()
        {
            //Arrange
            var expected = new List<ProcessResultItem>();

            var csvProcessor = new CsvProcessor();

            //Act
            var actual = csvProcessor.ProcessFile(string.Empty);

            //Assert
            actual.Items.Should().AllBeEquivalentTo(expected);
        }
    }
}
