using UnityEngine;

public class Attendance
{
    public readonly AttendanceDataSO Data;

    private bool _isRewarded;
    public bool IsRewarded
    {
        get => _isRewarded;
        set
        {
            _isRewarded  = value;
        }
    }


    //데이터와 보상 유무
    public Attendance(AttendanceDataSO data, bool isRewarded)
    {
        Data = data;
        _isRewarded = isRewarded;
    }
}
