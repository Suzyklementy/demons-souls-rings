using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Http.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerformanceTest.Tests
{
    internal class ApiPerformanceTest
    {
        internal void GetAllRings10Times()
        {
            HttpClient client = new();
            const string url = "https://localhost:44300/api/Rings";

            var scenario = Scenario.Create("get rings", async context =>
            {
                var request = Http.CreateRequest("Get", url)
                .WithHeader("Content-type", "application/json");

                return await Http.Send(client, request);
            })
                .WithWarmUpDuration(TimeSpan.FromSeconds(5))
                .WithLoadSimulations(Simulation.KeepConstant(10, TimeSpan.FromSeconds(5)));

            NBomberRunner.RegisterScenarios(scenario).Run();
        }

        internal void GetRingbyName10Times()
        {
            HttpClient client = new();
            const string url = "https://localhost:44300/api/Rings/catring";

            var scenario = Scenario.Create("get ring by name", async context =>
            {
                var request = Http.CreateRequest("Get", url)
                .WithHeader("Content-type", "application/json");

                return await Http.Send(client, request);
            })
                .WithWarmUpDuration(TimeSpan.FromSeconds(5))
                .WithLoadSimulations(Simulation.KeepConstant(10, TimeSpan.FromSeconds(5)));

            NBomberRunner.RegisterScenarios(scenario).Run();
        }
    }
}
