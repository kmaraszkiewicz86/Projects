using FlashcardUIAutomatedTests.Core;

namespace FlashcardUIAutomatedTests.Helpers
{
	internal static class BrowserHelper
	{
		public static FirefoxWebDriver Firefox =>
			FirefoxWebDriver.Instance;
	}
}