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

            var sut = new CsvProcessor();

            //Act
            var result = sut.ProcessFile(string.Empty);

            //Assert
            Assert.AreEqual(expected, result.Status);
        }

        [TestMethod]
        public void ProcessFile_FilenameIsEmpty_ReturnsAnEmptyListOfItems()
        {
            //Arrange
            var expected = new List<ProcessResultItem>();

            var sut = new CsvProcessor(new FilesystemWrapperStub());

            //Act
            var actual = sut.ProcessFile(string.Empty);

            //Assert
            actual.Items.Should().AllBeEquivalentTo(expected);
        }

        [TestMethod]
        public void ProcessFile_FileDoesNotExist_ReturnsAnEmptyListOfItems()
        {
            //Arrange
            var expected = new List<ProcessResultItem>();

            var fileSystemWrapperStub = new FilesystemWrapperStub();
            fileSystemWrapperStub.Exists = false;
            fileSystemWrapperStub.Path = "path";
            fileSystemWrapperStub.Lines = new[] { "blah" };

            var sut = new CsvProcessor(fileSystemWrapperStub);

            //Act
            var actual = sut.ProcessFile("filename");

            //Assert
            actual.Items.Should().AllBeEquivalentTo(expected);
        }
    }
}
