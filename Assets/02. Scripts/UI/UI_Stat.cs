using System.Collections.Generic;
using UnityEngine;

public class UI_Stat : MonoBehaviour
{
    public List<UI_StatButton> UI_StatButtons;

    private void Start()
    {
        for (int i = 0; i < (int)EStatType.Count; i++)
        {
            UI_StatButtons[i].Refresh();
        }
    }
}
