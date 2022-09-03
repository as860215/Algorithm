using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;
using System;

namespace Algorithm.Travels
{
    public class TravelsTest
    {
        private readonly ITestOutputHelper output;
        public TravelsTest(ITestOutputHelper output)
            => this.output = output;

        [Theory]
        [InlineData(CaseType.Appeal)]
        public void Travels(CaseType caseType)
        {
            // 目的地
            const CaseStatus destination = CaseStatus.Closed;

            var trips = new List<CaseStatus>();
            TraverseHelper.Traverse((status) => caseType.CreateProvider().GetNextStatus(status), CaseStatus.Create, destination, trips);
            // 因為trips會是從終點新增，將trips反向
            trips.Reverse();

            output.WriteLine($"旅行目標：{string.Join(" => ", trips)}");
        }
    }
}