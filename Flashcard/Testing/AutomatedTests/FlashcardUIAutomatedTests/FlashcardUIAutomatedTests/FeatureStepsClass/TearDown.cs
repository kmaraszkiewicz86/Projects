using TechTalk.SpecFlow;
using static FlashcardUIAutomatedTests.Helpers.BrowserHelper;

namespace FlashcardUIAutomatedTests.FeatureStepsClass
{
	/// <summary>
	/// After scenario class.
	/// </summary>
	[Binding]
	internal class TearDown
	{
		/// <summary>
		/// Afters the scenario.
		/// </summary>
		[AfterScenario]
		public void AfterScenario()
		{
			if (Firefox != null)
			{
				Firefox.Close();
			}
		}
	}
}