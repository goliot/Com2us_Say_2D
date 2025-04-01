using UnityEngine;
using System.Collections.Generic;

public class UI_Attendance : MonoBehaviour
{
    public List<UI_AttendanceButton> UI_AttendanceButtons;

    void Start()
    {
        for(int i = 0; i < AttendanceManager.Instance.Attendances.Count; i++)
        {
            UI_AttendanceButtons[i]._attendance = AttendanceManager.Instance.Attendances[i];
            UI_AttendanceButtons[i].Refresh();
        }
    }

    public void Refresh()
    {
        foreach(UI_AttendanceButton button in UI_AttendanceButtons)
        {
            button.Refresh();
        }
    }
}
