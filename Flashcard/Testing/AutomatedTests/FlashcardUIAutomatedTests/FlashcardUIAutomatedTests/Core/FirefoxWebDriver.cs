using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace FlashcardUIAutomatedTests.Core
{
	internal sealed class FirefoxWebDriver
	{
		private static FirefoxWebDriver _firefoxWebDriver = null;
		
		private IWebDriver _driver;

		public IWebDriver Driver => _driver;

		public static FirefoxWebDriver Instance
		{
			get
			{
				if (_firefoxWebDriver == null)
				{
					_firefoxWebDriver = new FirefoxWebDriver();
				}

				return _firefoxWebDriver;
			}
		}

		private FirefoxWebDriver()
		{

			var path = Environment.CurrentDirectory;
			var tmpPath = Path.Combine(path, Guid.NewGuid().ToString());

			Directory.CreateDirectory(tmpPath);

			File.Copy(Path.Combine(path, "geckodriver.exe"), Path.Combine(tmpPath, "geckodriver.exe"));
			
			var firefoxOptions = new FirefoxOptions();
			firefoxOptions.AcceptInsecureCertificates = true;

			_driver = new FirefoxDriver(tmpPath, firefoxOptions);
		}

		public void Close()
		{
			_driver.Quit();
			_driver.Dispose();
			_driver = null;
		}
	}
}