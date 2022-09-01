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

        /// <summary>�ت��a</summary>
        private const CaseStatus Destination = CaseStatus.Closed;

        [Theory]
        [InlineData(CaseType.Appeal)]
        public void Travels(CaseType caseType)
        {
            var trips = new List<CaseStatus>();
            Traverse(caseType.CreateProvider(), CaseStatus.Create, trips);
            // �]��trips�|�O�q���I�s�W�A�Ntrips�ϦV
            trips.Reverse();

            output.WriteLine($"�Ȧ�ؼСG{string.Join(" => ", trips)}");
        }

        /// <summary>�M���ȳ~�A�����I</summary>
        /// <param name="provider">�A�ȴ��Ѫ̡]����ƫإ߹�ҡ^</param>
        /// <param name="now">�{�b���`�I</param>
        /// <param name="trips">�ȳ~���|</param>
        /// <param name="arrivals">���g��F�L���a��]���������^</param>
        /// <returns>�Y��true�h�N������I�A�N�|�̧Ǫ���</returns>
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
                // �ư��w�g�M���L�����{
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