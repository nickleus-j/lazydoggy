using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abot2.Core;
using Abot2.Crawler;
using Abot2.Poco;
using Serilog;
using Serilog.Formatting.Json;

namespace DaLazyDog.Models
{
    public class Crawler
    {
        private async Task DemoSimpleCrawler()
        {
            var config = new CrawlConfiguration
            {
                MaxPagesToCrawl = 25,
                MinCrawlDelayPerDomainMilliSeconds = 3000
            };
            var crawler = new PoliteWebCrawler(config);

            crawler.PageCrawlCompleted += Crawler_PageCrawlCompleted;

            var crawlResult = await crawler.CrawlAsync(new Uri("https://diksiyonaryo.ph"));
        }

        private void Crawler_PageCrawlCompleted(object sender, PageCrawlCompletedArgs e)
        {

        }

        private async Task DemoPageRequester()
        {
            var pageRequester =
                new PageRequester(new CrawlConfiguration(), new WebContentExtractor());

            //var result = await pageRequester.MakeRequestAsync(new Uri("http://google.com"));
            var result = await pageRequester.MakeRequestAsync(new Uri("https://diksiyonaryo.ph"));
            Console.WriteLine("{result}" + new { url = result.Uri, status = Convert.ToInt32(result.HttpResponseMessage.StatusCode) });

        }
    }
}
