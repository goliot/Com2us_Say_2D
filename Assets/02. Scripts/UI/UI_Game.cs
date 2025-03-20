using UnityEngine;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;

public class UI_Game : MonoBehaviour
{
    public static UI_Game Instance = null;

    public List<GameObject> Booms;

    public TextMeshProUGUI KillCountText;
    public TextMeshProUGUI ScoreText;

    private int _prevKillCount = 0;
    private int _prevScore = 0;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        Refresh();
    }

    public void Refresh()
    {
        Debug.Log(gameObject.name);

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
        if (_prevKillCount != PlayerStats.KillCount) 
        {
            _prevKillCount = PlayerStats.KillCount;
            KillCountText.transform.DOScale(1.4f, 0.2f).SetEase(Ease.OutBounce)
            .OnComplete(() => KillCountText.transform.DOScale(1f, 0.1f));
        }
        
        if (_prevScore != PlayerStats.Score)
        {
            _prevScore = PlayerStats.Score;
            ScoreText.text = $"Score : {PlayerStats.Score.ToString("N0")}";
            ScoreText.transform.DOScale(1.4f, 0.2f).SetEase(Ease.OutBounce)
                .OnComplete(() => ScoreText.transform.DOScale(1f, 0.1f));
        }
    }
}