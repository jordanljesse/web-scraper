using AngleSharp;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace web_scraper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // use the default configuration for AngleSharp
            var config = Configuration.Default.WithDefaultLoader();

            // set the context for evaluating web pages with the given configuration
            var context = BrowsingContext.New(config);

            // web address to be parsed
            var address = "https://news.ycombinator.com";

            // create an asynchronous request for the specified document to load
            var document = await context.OpenAsync(address);

            // select the content we want from the document
            var cellSelector = "span.titleline a";
            var cells = document.QuerySelectorAll(cellSelector);
            var titles = cells.Select(m => m.TextContent);
            var results = document.QuerySelectorAll(cellSelector)
                .Select(el => el.TextContent);

            // display the results
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }
}