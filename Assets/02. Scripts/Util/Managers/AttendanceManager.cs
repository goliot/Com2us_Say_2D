using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class AttendanceManager : Singleton<AttendanceManager>
{
    private const string LOGINDATE_KEY = "LastLoginDate";
    private const string ATTENDANCE_COUNT_KEY = "AttendanceCount";

    // 관리자 : 추가, 삭제, 조회, 정렬
    [SerializeField]
    private List<AttendanceDataSO> _soDatas;

    // 출석 데이터로 만든 출석 객체들
    private List<Attendance> _attendances;
    // 조회
    public List<Attendance> Attendances => _attendances;

    //출석 검증 데이터
    private DateTime _lastLoginDateTime = new DateTime(); //마지막 로그인 날짜
    private int _attendanceCount = 0; // 출석 횟수

    public Action OnDataChanged;

    private void Awake()
    {
        //추가
        //게임 시작할 때 출석 객체 생성(기획자가 세팅한 만큼)
        _attendances = new List<Attendance>(_soDatas.Count); //최적화
        foreach (AttendanceDataSO data in _soDatas)
        {
            Attendance attendance = new Attendance(data);
            _attendances.Add(attendance);
        }
        //PlayerPrefs.DeleteKey(LOGINDATE_KEY);
        Load();
        AttendanceCheck();
        StartCoroutine(SaveDate());
    }

    private void Load()
    {
        string dateString = PlayerPrefs.GetString(LOGINDATE_KEY, DateTime.Today.ToString("yyyy-MM-dd"));
        _lastLoginDateTime = DateTime.ParseExact(dateString, "yyyy-MM-dd", null);

        _attendanceCount = PlayerPrefs.GetInt(ATTENDANCE_COUNT_KEY, 0);

        Debug.Log(_lastLoginDateTime + " " + _attendanceCount);
    }

    private void Save()
    {
        PlayerPrefs.SetString(LOGINDATE_KEY, DateTime.Today.ToString("yyyy-MM-dd"));
        PlayerPrefs.SetInt(ATTENDANCE_COUNT_KEY, _attendanceCount);
    }

    private IEnumerator SaveDate()
    {
        while(true)
        {
            Save();
            yield return new WaitForSeconds(60);
        }
    }

    private void AttendanceCheck()
    {
        DateTime today = DateTime.Today;
        if(today > _lastLoginDateTime)
        {
            _lastLoginDateTime = today;
            _attendanceCount++;
        }
    }

    //보상 받기
    public bool TryGetReward(Attendance attendance)
    {
        // 조건 1 : 이미 보상 받았다면 실패
        if(attendance.IsRewarded)
        {
            return false;
        }
        
        //조건 2 : 실제 그만큼 출석 했는가
        if(_attendanceCount < attendance.Data.Day)
        {
            return false;
        }

        attendance.Data.IsRewarded = true;
        attendance.IsRewarded = true;
        CurrenyManager.Instance.Add(attendance.Data.RewardCurrencyType, attendance.Data.RewardAmount);
        OnDataChanged?.Invoke();

        return true;
    }
}