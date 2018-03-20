using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TddFromTheScratch.Business;
using TddFromTheScratch.Business.Enumerations;

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
    }
}
