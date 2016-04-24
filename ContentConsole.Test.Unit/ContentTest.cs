using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Core.Infrastructure.Interface;
using Content.Core.Manager;
using NUnit.Framework;
using Rhino.Mocks;

namespace ContentConsole.Test.Unit
{
	[TestFixture]
	public class ContentTest
	{
		private const string pharase = @"The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
		private const string curratedpharase = @"The weather in Manchester in winter is b#d. It rains all the time - it must be h######e for people visiting.";
		private List<string> bannedwordsList = new List<string>() { "swine", "bad", "nasty", "horrible" };
		private const int expectedcount = 2;
		[Test]
		public void GivenPharase_WhenAnalysed_ReturnNegativeWordsCount()
		{
			var mockbannedwordsrepository = MockRepository.GenerateMock<IBannedWords>();
			mockbannedwordsrepository.Expect(b => b.GetBannedWord()).Return(bannedwordsList);
			var contentProcessManager = new ContentProcessManager(mockbannedwordsrepository);
			int actualcount = contentProcessManager.GetNegativeWordCount(pharase);

			Assert.AreEqual(expectedcount, actualcount);
		}
		[Test]
		public void GivenPharase_WhenAnalysed_ReturnHashedStringResult()
		{
			var mockbannedwordsrepository = MockRepository.GenerateMock<IBannedWords>();
			mockbannedwordsrepository.Expect(b => b.GetBannedWord()).Return(bannedwordsList);
			var contentProcessManager = new ContentProcessManager(mockbannedwordsrepository);
			var actual = contentProcessManager.FilterNegativeWords(pharase);
			Assert.AreEqual(curratedpharase, actual);


		}


	}
}
