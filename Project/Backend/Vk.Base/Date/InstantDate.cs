using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.Base.Date;

public class InstantDate
{
    public static DateTime GetTurkeyLocalTime()
    {
        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
        DateTime turkeyTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);

        int year = turkeyTime.Year;
        int month = turkeyTime.Month;
        int day = turkeyTime.Day;
        int hour = turkeyTime.Hour;
        int minute = turkeyTime.Minute;

        DateTime simplifiedTime = new DateTime(year, month, day, hour, minute, 0, DateTimeKind.Local);

        return simplifiedTime;
    }





}
