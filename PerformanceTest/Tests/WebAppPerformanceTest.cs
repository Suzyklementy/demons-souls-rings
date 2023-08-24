using NBomber.CSharp;
using NBomber.Http.CSharp;
using NBomber.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTest.Tests
{
    internal class WebAppPerformanceTest
    {
        internal void AccessWebApp100Times()
        {
            HttpClient client = new();
            const string url = "https://localhost:7044/";

            var scenario = Scenario.Create("access web app", async context =>
            {
                var request = Http.CreateRequest("Get", url)
                .WithHeader("Accept", "text/html");

                return await Http.Send(client, request);
            })
                .WithWarmUpDuration(TimeSpan.FromSeconds(5))
                .WithLoadSimulations(Simulation.KeepConstant(100, TimeSpan.FromSeconds(5)));

            NBomberRunner.RegisterScenarios(scenario).Run();
        }
    }
}
