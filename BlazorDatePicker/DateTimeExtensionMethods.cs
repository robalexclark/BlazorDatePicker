using System;
using System.Collections.Generic;

namespace RobAlexClark.BlazorDatePicker
{
    internal static class DateTimeExtensionMethods
    {
        /// <summary>
        /// Returns the first day of the month of the specified <see cref="DateTime"/>.
        /// </summary>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        internal static DateTime StartOfMonth(this DateTime currentDate)
        {
            return currentDate.AddDays(1 - currentDate.Day);
        }

        /// <summary>
        /// Returns the last day of the month of the specified <see cref="DateTime"/>.
        /// </summary>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        internal static DateTime EndOfMonth(this DateTime currentDate)
        {
            return currentDate.StartOfMonth().AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// Returns the first day before of the specified <see cref="DateTime"/> that has the same <see cref="DateTime.DayOfWeek"/> as <paramref name="startOfWeek"/>.
        /// </summary>
        /// <param name="currentDate"></param>
        /// <param name="startOfWeek"></param>
        /// <returns></returns>
        internal static DateTime StartOfWeek(this DateTime currentDate, DayOfWeek startOfWeek)
        {
            DateTime local = currentDate;
            while (local.DayOfWeek != startOfWeek)
            {
                local = local.AddDays(-1);
            }

            return local;
        }

        /// <summary>
        /// Returns the last day of the week containing the specified <see cref="DateTime"/>, where the week begins on <paramref name="startOfWeek"/>.
        /// </summary>
        /// <param name="currentDate"></param>
        /// <param name="startOfWeek"></param>
        /// <returns></returns>
        internal static DateTime EndOfWeek(this DateTime currentDate, DayOfWeek startOfWeek)
        {
            var endOfWeek = startOfWeek.Prev();
            DateTime local = currentDate;
            while (local.DayOfWeek != endOfWeek)
            {
                local = local.AddDays(1);
            }

            return local;
        }

        /// <summary>
        /// Returns true if the day is <see cref="DayOfWeek.Saturday"/> or <see cref="DayOfWeek.Sunday"/>, false otherwise.
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        //internal static bool IsWeekend(this DayOfWeek day)
        //{
        //    if (day == DayOfWeek.Saturday ||
        //        day == DayOfWeek.Sunday)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        /// <summary>
        /// Returns true if the day is <see cref="DayOfWeek.Monday"/>, <see cref="DayOfWeek.Tuesday"/>, <see cref="DayOfWeek.Wednesday"/>, <see cref="DayOfWeek.Thursday"/> or <see cref="DayOfWeek.Friday"/>, false otherwise.
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        internal static bool IsWeekday(this DayOfWeek day)
        {
            if (day == DayOfWeek.Saturday ||
                day == DayOfWeek.Sunday)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Returns Midnight of the Date of the current <see cref="Instant"/> as a <see cref="DateTimeTime"/> type in UTC.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        //internal static DateTime StartOfToday(this IClock source)
        //{
        //	if (source == null)
        //		throw new ArgumentNullException(nameof(source));

        //	return source.GetCurrentInstant().InUtc().DateTimeTime.Date.AtMidnight();
        //}

        /// <summary>
        /// Returns the preceding <see cref="DayOfWeek"/>.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        internal static DayOfWeek Prev(this DayOfWeek source)
        {
            switch (source)
            {
                case DayOfWeek.Monday:
                    return DayOfWeek.Sunday;
                case DayOfWeek.Tuesday:
                    return DayOfWeek.Monday;
                case DayOfWeek.Wednesday:
                    return DayOfWeek.Tuesday;
                case DayOfWeek.Thursday:
                    return DayOfWeek.Wednesday;
                case DayOfWeek.Friday:
                    return DayOfWeek.Thursday;
                case DayOfWeek.Saturday:
                    return DayOfWeek.Friday;
                case DayOfWeek.Sunday:
                    return DayOfWeek.Saturday;
                default:
                    throw new ArgumentException("source is invalid");
            }
        }

        /// <summary>
        /// Returns the next <see cref="DayOfWeek"/>
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        internal static DayOfWeek Next(this DayOfWeek source)
        {
            switch (source)
            {
                case DayOfWeek.Monday:
                    return DayOfWeek.Tuesday;
                case DayOfWeek.Tuesday:
                    return DayOfWeek.Wednesday;
                case DayOfWeek.Wednesday:
                    return DayOfWeek.Thursday;
                case DayOfWeek.Thursday:
                    return DayOfWeek.Friday;
                case DayOfWeek.Friday:
                    return DayOfWeek.Saturday;
                case DayOfWeek.Saturday:
                    return DayOfWeek.Sunday;
                case DayOfWeek.Sunday:
                    return DayOfWeek.Monday;
                default:
                    throw new ArgumentException("source is invalid");
            }
        }

        /// <summary>
        /// Returns every <see cref="DateTime"/> in-between <paramref name="startDateTime"/> and <paramref name="endDateTime"/>.
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="inclusive">Include <paramref name="startDateTime"/> and <paramref name="endDateTime"/> in the return sequence.</param>
        /// <returns></returns>
        //internal static IEnumerable<DateTime> FullDaysBetween(this DateTime startDateTime, DateTime endDateTime, bool inclusive = false)
        //{
        //    if (endDateTime < startDateTime)
        //        throw new ArgumentException($"{nameof(endDateTime)} must be later than {nameof(startDateTime)}.");

        //    var begin = inclusive ? startDateTime.Date : startDateTime.Date.AddDays(1);
        //    var end = inclusive ? endDateTime.Date.AddDays(1) : endDateTime.Date;
        //    var days = (end - begin).Days;

        //    for (int i = 0; i < days; i++)
        //    {
        //        yield return begin.AddDays(i);
        //    }
        //}

        /// <summary>
        /// Returns the first and last years of the decade that contains <paramref name="year"/>.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        internal static (int, int) GetDecade(this int year)
        {
            var year0 = (year / 10) * 10; // has the effect of rounding down to first year of current decade
            var year9 = year0 + 9;

            return (year0, year9);
        }

        /// <summary>
        /// Returns the first and last years of the decade that contains <paramref name="date"/>.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        internal static (int, int) GetDecade(this DateTime date)
        {
            return date.Year.GetDecade();
        }

        internal static string GetDecadeString(this DateTime date, string format = "{0}-{1}")
        {
            // returns the bounding years of the decade of the specified date
            // e.g. 2018 -> 2010-2019
            //      2001 -> 2000-2009

            var (year0, year9) = date.GetDecade();

            return string.Format(format, year0, year9);
        }

        /// <summary>
        /// Returns the first and last decades of the century that contains <paramref name="year"/>.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        internal static (int, int) GetCentury(this int year)
        {
            var year0 = (year / 100) * 100; // has the effect of rounding down to first year of current decade
            var year90 = year0 + 90;

            return (year0, year90);
        }
        /// <summary>
        /// Returns the first and last decades of the century that contains <paramref name="date"/>.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        internal static (int, int) GetCentury(this DateTime date)
        {
            return date.Year.GetCentury();
        }

        internal static string GetCenturyString(this DateTime date, string format = "{0}-{1}")
        {
            // returns the bounding decades of the century of the specified date
            // e.g. 2018 -> 2000-2090
            //      1985 -> 1900-1990

            var (year0, year90) = date.GetCentury();

            return string.Format(format, year0, year90);
        }
    }
}