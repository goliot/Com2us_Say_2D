using UnityEngine;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;

public class UI_Game : MonoBehaviour
{
    public List<GameObject> Booms;

    public TextMeshProUGUI KillCountText;
    public TextMeshProUGUI ScoreText;

    private int _prevKillCount = 0;
    private int _prevScore = 0;

    private void Awake()
    {
        Refresh();
    }

    public void Refresh()
    {
        for(int i=0; i<3; i++)
        {
            //Booms[i].SetActive(i < PlayerStats.BoomCount);
            if(i < PlayerStats.BoomCount)
            {
                Booms[i].transform.DOScale(1f, 0.2f);
            }
            else
            {
                Booms[i].transform.DOScale(0f, 0.2f);
            }
        }
        
        KillCountText.text = $"Kills : {PlayerStats.KillCount}";
        KillCountText.transform.DOScale(1.2f, 0.2f).OnComplete(() => KillCountText.transform.localScale = Vector3.one);

        ScoreText.text = $"Score : {PlayerStats.Score}";
        ScoreText.transform.DOScale(1.2f, 0.2f).OnComplete(() => ScoreText.transform.localScale = Vector3.one);
    }
}
