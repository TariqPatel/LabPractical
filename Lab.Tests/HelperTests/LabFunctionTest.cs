using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab.Helpers;

namespace Lab.Tests.Controllers
{
	[TestClass]
	public class LabFunctionTest
	{
		[TestMethod]
		public void AssertThatOneIsReturned()
		{
			// Arrange
			var fileContentString = "2,3,4,5,6,2,2,2,2,2,2,2,2";

			// Act
			var result = LabFunctions.GetLeader(fileContentString);

			// Assert
			Assert.AreSame(result, "1");
		}

		[TestMethod]
		public void AssertThatNegativeOneIsReturned()
		{
			// Arrange
			var fileContentString = "2,3,4,5,6,2,2";

			// Act
			var result = LabFunctions.GetLeader(fileContentString);

			// Assert
			Assert.AreSame(result, "-1");
		}

		[TestMethod]
		public void AssertThatNullMessageReturnedWhenfileContentStringIsNull()
		{
			// Arrange
			string fileContentString = null;

			// Act
			var result = LabFunctions.GetLeader(fileContentString);

			// Assert
			Assert.AreSame(result, "String is null");
		}
	}
}
