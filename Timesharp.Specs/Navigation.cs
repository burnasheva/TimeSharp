using System;
using System.Configuration;
using TechTalk.SpecFlow;
using NUnit.Framework;
using WatiN.Core;

namespace Timesharp.Specs
{
    [Binding]
    public class Navigation
    {
        [When(@"I navigate to (.*)")]
        public void WhenINavigateTo(string relativeUrl)
        {
            var rootUrl = new Uri(ConfigurationManager.AppSettings["RootUrl"]);
            var absoluteUrl = new Uri(rootUrl, relativeUrl);
            WebBrowser.Current.GoTo(absoluteUrl);
        }

        [Then(@"I should be on the home page")]
        public void ThenIShouldBeOnTheHomePage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
