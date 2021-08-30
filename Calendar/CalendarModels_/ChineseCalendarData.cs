namespace Calendar
{
    /// <summary>
    ///     中国日历相关数据
    /// </summary>
    internal static class ChineseCalendarData
    {
        /// <summary>
        ///     农历月
        /// </summary>
        public static readonly string[] LunarMonths = {"正月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "腊月" };

        /// <summary>
        ///     汉字数字
        /// </summary>
        public static readonly string[] ChineseNumbers = { "〇", "一", "二", "三", "四", "五", "六", "七", "八", "九", "十" };

        /// <summary>
        ///     汉字数字（10位）
        /// </summary>
        public static readonly string[] ChineseNumberPrefixes = { "初", "十", "廿", "三" };

        /// <summary>
        ///     十天干
        /// </summary>
        public static readonly string[] CelestialStems = { "甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸" };

        /// <summary>
        ///     十二地支
        /// </summary>
        public static readonly string[] EarthlyBranches = { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };

        /// <summary>
        ///     十二生肖
        /// </summary>
        public static readonly string[] ChineseZodiacs = { "鼠", "牛", "虎", "免", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪" };

        /// <summary>
        ///     二十四节气
        /// </summary>
        public static readonly string[] SolarTerms =
        {
            "小寒", "大寒", "立春", "雨水", "惊蛰", "春分",
            "清明", "谷雨", "立夏", "小满", "芒种", "夏至",
            "小暑", "大暑", "立秋", "处暑", "白露", "秋分",
            "寒露", "霜降", "立冬", "小雪", "大雪", "冬至"
        };

        /// <summary>
        ///     二十八星宿
        /// </summary>
        public static readonly string[] ChineseConstellations =
        {
            "角木蛟", "亢金龙", "女土蝠", "房日兔", "心月狐", "尾火虎", "箕水豹",
            "斗木獬", "牛金牛", "氐土貉", "虚日鼠", "危月燕", "室火猪", "壁水獝",
            "奎木狼", "娄金狗", "胃土彘", "昴日鸡", "毕月乌", "觜火猴", "参水猿",
            "井木犴", "鬼金羊", "柳土獐", "星日马", "张月鹿", "翼火蛇", "轸水蚓"
        };

        /// <summary>
        ///     中国日期固定的农历节
        /// 注：除夕根据情况判定
        /// </summary>
        public static readonly LunarHolidayInfo[] LunarHolidays =
        {
            new LunarHolidayInfo(1, 1, "春节"),
            new LunarHolidayInfo(1, 15, "元宵节"),
            new LunarHolidayInfo(5, 5, "端午节"),
            new LunarHolidayInfo(7, 7, "七夕"),
            new LunarHolidayInfo(7, 15, "中元节"),
            new LunarHolidayInfo(8, 15, "中秋节"),
            new LunarHolidayInfo(9, 9, "重阳节"),
            new LunarHolidayInfo(12, 8, "腊八节"),
            new LunarHolidayInfo(12, 23, "北方小年(扫房)"),
            new LunarHolidayInfo(12, 24, "南方小年(掸尘)"),
        };
    }
}
