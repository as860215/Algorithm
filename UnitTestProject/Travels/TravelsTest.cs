using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

namespace UnitTestProject.Travels
{
    public class TravelsTest
    {
        private readonly ITestOutputHelper output;
        public TravelsTest(ITestOutputHelper output)
            => this.output = output;

        /// <summary>目的地</summary>
        private const CaseStatus Destination = CaseStatus.Closed;

        [Theory]
        [InlineData(CaseType.Appeal)]
        public void Travels(CaseType caseType)
        {
            var trips = new List<CaseStatus>();
            Traverse(caseType.CreateProvider(), CaseStatus.Create, trips);
            // 因為trips會是從終點新增，將trips反向
            trips.Reverse();

            output.WriteLine($"旅行目標：{string.Join(" => ", trips)}");
        }

        /// <summary>遍歷旅途，找到終點</summary>
        /// <param name="provider">服務提供者（防止重複建立實例）</param>
        /// <param name="now">現在的節點</param>
        /// <param name="trips">旅途路徑</param>
        /// <param name="arrivals">曾經抵達過的地方（防止重複轉圈圈）</param>
        /// <returns>若為true則代表找到終點，將會依序返還</returns>
        private bool Traverse(CaseTypeProviderBase provider, CaseStatus now, List<CaseStatus> trips, List<(CaseStatus from, CaseStatus target)>? arrivals = null)
        {
            arrivals ??= new List<(CaseStatus from, CaseStatus target)>();

            if(now == Destination)
                return true;

            var result = false;
            var nextStatusPossible = provider.GetNextStatus(now);
            if (nextStatusPossible is null)
                return result;
            foreach(var nextStatus in nextStatusPossible)
            {
                // 排除已經遍歷過的歷程
                if (arrivals.Any(n => n.from == now && n.target == nextStatus))
                    continue;
                arrivals.Add((now, nextStatus));

                if(Traverse(provider, nextStatus, trips, arrivals))
                {
                    trips.Add(nextStatus);
                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}