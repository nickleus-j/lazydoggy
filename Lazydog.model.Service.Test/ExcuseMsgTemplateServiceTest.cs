using Microsoft.VisualStudio.TestTools.UnitTesting;

using Lazydog.Model.Service;
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
            Assert.IsTrue(result.Contains('<'));
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
    }
}
