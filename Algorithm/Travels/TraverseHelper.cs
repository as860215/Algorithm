using System.Collections.Generic;
using System.Linq;
using System;

namespace Algorithm.Travels
{
    /// <summary>旅行小幫手</summary>
    public static class TraverseHelper
    {
        /// <summary>遍歷旅途，找到終點</summary>
        /// <param name="nextPossible">下一關的可能狀態</param>
        /// <param name="now">現在的節點</param>
        /// <param name="destination">目標節點</param>
        /// <param name="trips">旅途路徑</param>
        /// <param name="arrivals">曾經抵達過的地方（防止重複轉圈圈）</param>
        /// <returns>若為true則代表找到終點，將會依序返還</returns>
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
                // 排除已經遍歷過的歷程
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