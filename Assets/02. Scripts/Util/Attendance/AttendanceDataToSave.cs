using System.Collections.Generic;
using System;

[Serializable]
public class AttendanceDataToSave
{
    public string LastLoginDate;
    public int AttendanceCount;
    public List<bool> IsRewardedList = new List<bool>();
}