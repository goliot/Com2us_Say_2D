using System.Collections.Generic;
using UnityEngine;

public class UI_Stat : Singleton<UI_Stat>
{
    public List<UI_StatButton> UI_StatButtons;

    private void Start()
    {
        for (int i = 0; i < (int)EStatType.Count; i++)
        {
            UI_StatButtons[i]._stat = StatManager.Instance.Stats[i];
            UI_StatButtons[i].Refresh();
        }

        StatManager.Instance.OnDataChangedCallback = Refresh;

        Refresh();
    }

    public void Refresh()
    {
        for (int i = 0; i < (int)EStatType.Count; i++)
        {
            UI_StatButtons[i].Refresh();
        }
    }
}