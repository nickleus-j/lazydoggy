using Microsoft.VisualStudio.TestTools.UnitTesting;

using Lazydog.Model.Service;
using System.Collections.Generic;

namespace Lazydog.model.Service.Test
{
    [TestClass]
    public class ExcuseMsgTemplateServiceTest
    {
        [TestMethod]
        public void Test_RemoveWordsForTextboxes_NoTilde_hasName()
        {
            string sampleTemplate= @"Hi |sirmam ~, <br/>
            I `Name ~., wish to be excused for my `Excuse ~. <br/>
            |FarewellWord ~, <br/>`Name";
            ExcuseMsgTemplateService msgService = new ExcuseMsgTemplateService();
            string result = msgService.GenerateHtmlOfTemplate(sampleTemplate);
            Assert.IsTrue(result.Contains("Name"));
        }
        [TestMethod]
        public void Test_RemoveWordsForTextboxes_HasInputTag()
        {
            string sampleTemplate = @"Hi, <br/>
            I `Name ~. wish to be excused for I have `Excuse ~. <br/>
            |FarewellWord ~, <br/>
            `Name";
            ExcuseMsgTemplateService msgService = new ExcuseMsgTemplateService();
            string result = msgService.GenerateHtmlOfTemplate(sampleTemplate);
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
        public void Test_RetainBrTag()
        {
            string sampleTemplate = @"Hi, <br/>
            I `Name ~. wish to be excused for I have `Excuse ~. <br/>
            |FarewellWord ~, <br/>
            `Name";
            ExcuseMsgTemplateService msgService = new ExcuseMsgTemplateService();
            string result = msgService.GenerateHtmlOfTemplate(sampleTemplate);
            Assert.IsTrue(result.Contains("<br"));
        }
        [TestMethod]
        public void Test_RemoveTildeQuotaed()
        {
            string sampleTemplate = @"Hi, <br/>
            I `Name ~. wish to be excused for I have `Excuse ~. <br/>
            |FarewellWord ~, <br/>
            `Name";
            ExcuseMsgTemplateService msgService = new ExcuseMsgTemplateService();
            string result = msgService.GenerateHtmlOfTemplate(sampleTemplate);
            Assert.IsFalse(result.Contains('`'));
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
        }
        [TestMethod]
        public void Test_RemoveForMultipleDropDownLists_HasMam()
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
            OptionsList.Add("sir/mam", sirMamOptions);
            string result = msgService.GenerateHtmlOfTemplate(sampleTemplate, OptionsList);
            Assert.IsTrue(result.Contains("mam"));
        }//Thanks
        [TestMethod]
        public void Test_RemoveForMultipleDropDownLists_HasThanks()
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
            OptionsList.Add("sir/mam", sirMamOptions);
            string result = msgService.GenerateHtmlOfTemplate(sampleTemplate, OptionsList);
            Assert.IsTrue(result.Contains("Thanks"));
        }
    }
}
