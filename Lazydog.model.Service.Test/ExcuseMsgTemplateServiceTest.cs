using Microsoft.VisualStudio.TestTools.UnitTesting;

using Lazydog.Model.Service;
using System.Collections.Generic;

namespace Lazydog.model.Service.Test
{
    [TestClass]
    public class ExcuseMsgTemplateServiceTest
    {
        [TestMethod]
        public void Test_RemoveWordsForTextboxes()
        {
            string sampleTemplate=@"Hi, <br/>
            I `Name ~. wish to be excused for I have `Excuse ~. <br/>
            |FarewellWord ~, <br/>
            `Name";
            ExcuseMsgTemplateService msgService = new ExcuseMsgTemplateService();
            string result = msgService.GenerateHtmlOfTemplate(sampleTemplate);
            Assert.IsFalse(result.Contains('`'));
            Assert.IsTrue(result.Contains("<input"));
        }
        [TestMethod]
        public void Test_RemoveTilde()
        {
            string sampleTemplate = @"Hi, <br/>
            I `Name ~. wish to be excused for I have `Excuse ~. <br/>
            |FarewellWord ~, <br/>
            `Name";
            ExcuseMsgTemplateService msgService = new ExcuseMsgTemplateService();
            string result = msgService.GenerateHtmlOfTemplate(sampleTemplate);
            Assert.IsFalse(result.Contains('~'));
        }
        [TestMethod]
        public void Test_RemoveForDropDownLists()
        {
            string sampleTemplate = @"Hi, <br/>
            I `Name ~. wish to be excused for I have `Excuse ~. <br/>
            |FarewellWord ~, <br/>
            `Name";
            ExcuseMsgTemplateService msgService = new ExcuseMsgTemplateService();
            string result = msgService.GenerateHtmlOfTemplate(sampleTemplate);
            Assert.IsTrue(result.Contains("<select"));
        }
        [TestMethod]
        public void Test_RemoveForMultipleDropDownLists()
        {
            string sampleTemplate = @"Hi |sirmam ~, <br/>
            I `Name ~. wish to be excused for I have `Excuse ~. <br/>
            |FarewellWord ~, <br/>
            `Name";
            var OptionsList = new Dictionary<string, IList<string>>();
            IList<string> sirMamOptions = new List<string>();
            ExcuseMsgTemplateService msgService = new ExcuseMsgTemplateService();

            sirMamOptions.Add("sir");
            sirMamOptions.Add("mam");
            OptionsList.Add("sirmam", sirMamOptions);
            string result = msgService.GenerateHtmlOfTemplate(sampleTemplate,OptionsList);
            Assert.IsTrue(result.Contains(">sir"));
            Assert.IsTrue(result.Contains("mam"));
        }
    }
}
