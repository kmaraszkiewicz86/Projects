using System;
using System.Threading;
using FlashcardUIAutomatedTests.Attributes;
using FlashcardUIAutomatedTests.Helpers;
using OpenQA.Selenium;
using  OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;
using static FlashcardUIAutomatedTests.Helpers.BrowserHelper;
using static FlashcardUIAutomatedTests.Helpers.ConfigManagerHelper;

namespace FlashcardUIAutomatedTests.FeatureStepsClass
{
    [Binding]
	[PageName("Login")]
    internal class LoginFeatureSteps
    {
		/// <summary>
		/// Gets or sets the username input.
		/// </summary>
		/// <value>
		/// The username input.
		/// </value>
		[FindsBy(How = How.Id, Using = "Username")]
	    public IWebElement UsernameInput { get; set; }

		/// <summary>
		/// Gets or sets the password input.
		/// </summary>
		/// <value>
		/// The password input.
		/// </value>
		[FindsBy(How = How.Id, Using = "Password")]
		public IWebElement PasswordInput { get; set; }

		/// <summary>
		/// Gets or sets the submit web element.
		/// </summary>
		/// <value>
		/// The submit web element.
		/// </value>
		[FindsBy(How = How.XPath, Using = "\\button[text()='Sign in']")]
		public IWebElement SubmitWebElement { get; set; }

	    public LoginFeatureSteps()
	    {
		    
	    }

	    /// <summary>
		/// Logins to website using credentials.
		/// </summary>
		/// <param name="loginKey">The login key.</param>
		[Given(@"I login to website using '(.*)' credentials")]
		public void LoginToWebsiteUsingCredentials(string loginKey)
		{
			var login = GetLogin(loginKey);
			var password = GetPassword(loginKey);

			Firefox.Driver.Navigate().GoToUrl(HostUrl);

			Firefox.Driver.WaitUntilElementExists(By.Id("Username"), TimeSpan.FromSeconds(10));

			UsernameInput.SendKeys(loginKey);
			PasswordInput.SendKeys(password);
			SubmitWebElement.Click();

			Thread.Sleep(2000);
		}

		/// <summary>
		/// Enters to page.
		/// </summary>
		/// <param name="pageName">Name of the page.</param>
		[Given(@"I enter to '(.*)' page")]
	    public void EnterToPage(string pageName)
	    {
		    //Firefox.Driver.Navigate().GoToUrl(GetPageUrl(pageName));
	    }
	}
}