using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
namespace Lazydog.Model.Service
{
    public class JsonValuesService
    {
        /// <summary>
        /// Gets the Meta JSON of the Letter Template and converts it to dictionary
        /// </summary>
        /// <param name="jsonTemplateMeta"></param>
        /// <returns></returns>
        public static Dictionary<string, IList<string>> GetOptionsFromtemplateMeta(string jsonTemplateMeta)
        {
            Dictionary<string, IList<string>> options= JsonConvert.DeserializeObject<Dictionary<string, IList<string>>>(jsonTemplateMeta);
            return options;
        }
    }
}
