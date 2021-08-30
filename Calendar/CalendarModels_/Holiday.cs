namespace Calendar
{
    /// <summary>
    ///     节日信息
    /// </summary>
    public abstract class HolidayInfo
    {
        protected HolidayInfo(int month, int dayOfMonth, string name, bool isLunarHoliday)
        {
            Month = month;
            DayOfMonth = dayOfMonth;
            HolidayName = name;
            IsLunarHoliday = isLunarHoliday;
        }

        public bool IsLunarHoliday { get; }

        public int Month { get; }

        public int DayOfMonth { get; }

        public string HolidayName { get; }
    }

    /// <summary>
    ///     公历节目信息
    /// </summary>
    public class SolarHolidayInfo : HolidayInfo
    {
        public SolarHolidayInfo(int month, int dayOfMonth, string name) : base(month, dayOfMonth, name, true)
        {
        }
    }

    /// <summary>
    ///     农历节目信息
    /// </summary>
    public class LunarHolidayInfo : HolidayInfo
    {
        public LunarHolidayInfo(int month, int dayOfMonth, string name) : base(month, dayOfMonth, name, true)
        {
        }
    }
}
