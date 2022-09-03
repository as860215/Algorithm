using System.Collections.Generic;
using System.Linq;
using System;

namespace Algorithm.Travels
{
    /// <summary>�Ȧ�p����</summary>
    public static class TraverseHelper
    {
        /// <summary>�M���ȳ~�A�����I</summary>
        /// <param name="nextPossible">�U�@�����i�બ�A</param>
        /// <param name="now">�{�b���`�I</param>
        /// <param name="destination">�ؼи`�I</param>
        /// <param name="trips">�ȳ~���|</param>
        /// <param name="arrivals">���g��F�L���a��]���������^</param>
        /// <returns>�Y��true�h�N������I�A�N�|�̧Ǫ���</returns>
        public static bool Traverse<T>(Func<T, List<T>> nextPossible, T now, T destination, List<T> trips, List<(T from, T target)>? arrivals = null)
        {
            arrivals ??= new List<(T from, T target)>();

            if(now!.Equals(destination))
                return true;

            var result = false;
            var nextStatusPossible = nextPossible.Invoke(now);
            if (nextStatusPossible is null)
                return result;
            foreach(var nextStatus in nextStatusPossible)
            {
                // �ư��w�g�M���L�����{
                if (arrivals.Any(n => n.from!.Equals(now) && n.target!.Equals(nextStatus)))
                    continue;
                arrivals.Add((now, nextStatus));

                if(Traverse(nextPossible, nextStatus, destination, trips, arrivals))
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