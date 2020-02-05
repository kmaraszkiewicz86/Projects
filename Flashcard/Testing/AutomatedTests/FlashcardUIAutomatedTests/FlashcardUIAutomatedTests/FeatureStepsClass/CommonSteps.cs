using System;
using System.Linq;
using FlashcardUIAutomatedTests.Attributes;
using FlashcardUIAutomatedTests.Helpers;
using TechTalk.SpecFlow;

namespace FlashcardUIAutomatedTests.FeatureStepsClass
{
	[Binding]
	public class CommonSteps
	{
		private object _basePage;

		[When(@"I enter '(.*)' value to '(.*)' input")]
		public void WhenIEnterLoginInput(string value, string propertyName)
		{
			
		}
	}
}