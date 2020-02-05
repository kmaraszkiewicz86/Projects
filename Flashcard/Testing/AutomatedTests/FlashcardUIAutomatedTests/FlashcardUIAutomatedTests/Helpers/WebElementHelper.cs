using System;
using OpenQA.Selenium;

namespace FlashcardUIAutomatedTests.Helpers
{
	internal static class WebElementHelper
	{
		public static void WaitUntilElementExists(this IWebDriver driver, By by, TimeSpan timeoutTimeSpan)
		{
			var startDateTime = DateTime.Now;
			var success = false;

			do
			{
				var elements = driver.FindElements(by);

				if (elements.Count > 0)
				{
					success = true;
					break;
				}

			} while ((DateTime.Now - startDateTime) > timeoutTimeSpan);

			if (!success)
				throw new NoSuchElementException($"Could not found element");
		}
	}
}