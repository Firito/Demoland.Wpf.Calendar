using System;
using System.Globalization;
using System.Linq;

namespace Calendar
{
    public static class ChineseCalendarExtension
    {
        private static readonly ChineseLunisolarCalendar ChineseCalendar = new ChineseLunisolarCalendar();

        /// <summary>
        ///     返回农历年
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static int GetLunarYear(this DateTime dateTime)
        {
            return ChineseCalendar.GetYear(dateTime);
        }

        /// <summary>
        ///     返回农历月
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <param name="isLeapMonth">是否是闰月</param>
        public static int GetLunarMonth(this DateTime dateTime, out bool isLeapMonth)
        {
            var lunarMonth = ChineseCalendar.GetMonth(dateTime);
            var leapMonth = ChineseCalendar.GetLeapMonth(dateTime.GetLunarYear());
            isLeapMonth = leapMonth > 0 && leapMonth == lunarMonth;

            if (lunarMonth >= leapMonth)
            {
                lunarMonth --;
            }
            
            return lunarMonth;
        }

        /// <summary>
        ///     返回农历月名称
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string GetLunarMonthName(this DateTime dateTime)
        {
            var month = dateTime.GetLunarMonth(out var isLeapMonth);
            return (isLeapMonth ? "闰" : string.Empty) + ChineseCalendarData.LunarMonths[month - 1];
        }

        /// <summary>
        ///     返回农历日
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static int GetLunarDayOfMonth(this DateTime dateTime)
        {
            return ChineseCalendar.GetDayOfMonth(dateTime);
        }

        /// <summary>
        ///     返回农历日名称
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string GetLunarDayOfMonthName(this DateTime dateTime)
        {
            var chineseNumbers = ChineseCalendarData.ChineseNumbers;
            var chineseNumberPrefixes = ChineseCalendarData.ChineseNumberPrefixes;

            var day = dateTime.GetLunarDayOfMonth();
            if (day < 10)
            {
                return chineseNumberPrefixes[0] + chineseNumbers[day];
            }
            else if(day < 20)
            {
                return chineseNumberPrefixes[1] + chineseNumbers[day - 10];
            }
            else if(day < 30)
            {
                return chineseNumberPrefixes[2] + chineseNumbers[day - 20];
            }
            else
            {
                return ChineseCalendarData.ChineseNumberPrefixes[3] + ChineseCalendarData.ChineseNumbers[day - 30];
            }
        }

        /// <summary>
        ///     返回农历天干名称
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string GetCelestialStem(this DateTime dateTime)
        {
            var sexagenaryYear = ChineseCalendar.GetSexagenaryYear(dateTime);
            var index = ChineseCalendar.GetCelestialStem(sexagenaryYear) - 1;
            return ChineseCalendarData.CelestialStems[index];
        }

        /// <summary>
        ///     返回农历地支名称
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string GetTerrestrialBranch(this DateTime dateTime)
        {
            var sexagenaryYear = ChineseCalendar.GetSexagenaryYear(dateTime);
            var index = ChineseCalendar.GetTerrestrialBranch(sexagenaryYear) - 1;
            return ChineseCalendarData.EarthlyBranches[index];
        }

        /// <summary>
        ///     返回农历生肖名称
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string GetChineseZodiac(this DateTime dateTime)
        {
            var sexagenaryYear = ChineseCalendar.GetSexagenaryYear(dateTime);
            var index = ChineseCalendar.GetTerrestrialBranch(sexagenaryYear) - 1;
            return ChineseCalendarData.ChineseZodiacs[index];
        }

        /// <summary>
        ///     判断当前日期是否是农历节日
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="lunarHolidayInfo"></param>
        /// <returns></returns>
        public static bool TryGetLunarHoliday(this DateTime dateTime, out LunarHolidayInfo lunarHolidayInfo)
        {
            lunarHolidayInfo = null;

            var lunarMonth = dateTime.GetLunarMonth(out var isLeapMonth);
            if (isLeapMonth)
            {
                //闰月不计算节日
                return false;
            }

            var lunarDayOfMonth = dateTime.GetLunarDayOfMonth();
            var holidayInfo = ChineseCalendarData.LunarHolidays.FirstOrDefault(x =>
                x.Month == lunarMonth && x.DayOfMonth == lunarDayOfMonth);
            if (holidayInfo != null)
            {
                lunarHolidayInfo = holidayInfo;
                return true;
            }

            //除夕判断
            if (lunarMonth != 12) return true;

            var year = dateTime.GetLunarYear();
            var isLeapYear = ChineseCalendar.IsLeapYear(year);
            var days = isLeapYear
                ? ChineseCalendar.GetDaysInMonth(year, 13)
                : ChineseCalendar.GetDaysInMonth(year, 12);

            if (lunarDayOfMonth != days) return false;

            lunarHolidayInfo = new LunarHolidayInfo(lunarMonth, lunarDayOfMonth, "除夕");
            return true;
        }
    }
}
