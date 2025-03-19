using UnityEngine;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;

public class UI_Game : MonoBehaviour
{
    public List<GameObject> Booms;

    public TextMeshProUGUI KillCountText;
    public TextMeshProUGUI ScoreText;

    private void Awake()
    {
        Refresh();
    }

    public void Refresh()
    {
        for(int i=0; i<3; i++)
        {
            Booms[i].SetActive(i < PlayerStats.BoomCount);
        }

        KillCountText.text = $"Kills : {PlayerStats.KillCount}";
        KillCountText.transform.DOScale(1.2f, 0.2f).OnComplete(() => KillCountText.transform.localScale = Vector3.one);

        ScoreText.text = $"Score : {PlayerStats.Score}";
        ScoreText.transform.DOScale(1.2f, 0.2f).OnComplete(() => ScoreText.transform.localScale = Vector3.one);
    }
}
