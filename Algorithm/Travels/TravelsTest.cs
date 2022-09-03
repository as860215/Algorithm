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
            // �ت��a
            const CaseStatus destination = CaseStatus.Closed;

            var trips = new List<CaseStatus>();
            TraverseHelper.Traverse((status) => caseType.CreateProvider().GetNextStatus(status), CaseStatus.Create, destination, trips);
            // �]��trips�|�O�q���I�s�W�A�Ntrips�ϦV
            trips.Reverse();

            output.WriteLine($"�Ȧ�ؼСG{string.Join(" => ", trips)}");
        }
    }
}