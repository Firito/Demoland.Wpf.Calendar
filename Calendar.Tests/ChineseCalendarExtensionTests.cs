using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calendar.Tests
{
    [TestClass()]
    public class ChineseCalendarExtensionTests
    {
        [TestMethod()]
        [DataRow(2020, 4, 25, 4, "四月", false)]
        [DataRow(2020, 5, 25, 4, "闰四月", true)]
        [DataRow(2020, 6, 25, 5, "五月", false)]
        public void GetLunarMonthTest(int year, int month, int dayOfMonth, int expectedLunarMonth, string expectedLunarMonthName, bool expectedIsLeapMonth)
        {
            var dateTime = new DateTime(year, month, dayOfMonth);
            var lunarMonth = dateTime.GetLunarMonth(out var isLeapMonth);
            var lunarMonthName = dateTime.GetLunarMonthName();

            Assert.AreEqual(expectedLunarMonth, lunarMonth);
            Assert.AreEqual(expectedLunarMonthName, lunarMonthName);
            Assert.AreEqual(expectedIsLeapMonth, isLeapMonth);
        }

        [TestMethod()]
        public void GetLunarDayOfMonthTest()
        {
            var dateTime = DateTime.Today;
            var dayOfMonth = dateTime.GetLunarDayOfMonth();
            var expected = dayOfMonth switch
            {
                1 => "初一",
                2 => "初二",
                3 => "初三",
                4 => "初四",
                5 => "初五",
                6 => "初六",
                7 => "初七",
                8 => "初八",
                9 => "初九",
                10 => "初十",
                11 => "十一",
                12 => "十二",
                13 => "十三",
                14 => "十四",
                15 => "十五",
                16 => "十六",
                17 => "十七",
                18 => "十八",
                19 => "十九",
                20 => "廿十",
                21 => "廿一",
                22 => "廿二",
                23 => "廿三",
                24 => "廿四",
                25 => "廿五",
                26 => "廿六",
                27 => "廿七",
                28 => "廿八",
                29 => "廿九",
                30 => "三十",
                31 => "三一",
                _ => string.Empty
            };

            Assert.AreEqual(expected, dateTime.GetLunarDayOfMonthName());
        }
        
        [TestMethod()]
        [DataRow(2021, 2, 11, true, "除夕")]
        [DataRow(2014, 10, 2, true, "重阳节")]
        [DataRow(2014, 11, 1, false, "重阳节")]
        public void TryGetLunarHolidayTest(int year, int month, int dayOfMonth, bool expectedIsLunarHoliday, string expectedLunarHolidayName)
        {
            var dateTime = new DateTime(year, month, dayOfMonth);
            var isLunarHoliday = dateTime.TryGetLunarHoliday(out var lunarHolidayInfo);

            Assert.AreEqual(expectedIsLunarHoliday, isLunarHoliday);
            if (isLunarHoliday)
            {
                Assert.AreEqual(expectedLunarHolidayName, lunarHolidayInfo.HolidayName);
            }
        }
    }
}