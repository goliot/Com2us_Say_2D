using UnityEngine;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using System.Collections;
using UnityEngine.UI;

public class UI_Game : MonoBehaviour
{
    public static UI_Game Instance = null;

    public List<GameObject> Booms;

    public TextMeshProUGUI KillCountText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GoldText;
    public Slider BossHpSlider;
    public Slider BossSubSlider;
    public GameObject WarnigPanel;

    private int _prevKillCount = 0;
    private int _prevScore = 0;
    private int _prevGold = 0;

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
    }

    private void Start()
    {
        Refresh();
        RefreshScore();
        RefreshGold();
    }

    public void ActiveWarning()
    {
        WarnigPanel.SetActive(true);
        BossHpSlider.gameObject.SetActive(true);
        BossSubSlider.gameObject.SetActive(true);
        //BossHpSlider.GetComponent<UI_BossHp>().boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
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
        if (_prevKillCount < PlayerStats.KillCount) 
        {
            _prevKillCount = PlayerStats.KillCount;
            KillCountText.transform.DOScale(1.4f, 0.2f).SetEase(Ease.OutBounce)
            .OnComplete(() => KillCountText.transform.DOScale(1f, 0.1f));
        }
    }

    public void RefreshScore()
    {
        ScoreText.text = $"Score : {PlayerStats.Score.ToString("N0")}";
        if (_prevScore < PlayerStats.Score)
        {
            _prevScore = PlayerStats.Score;
            ScoreText.transform.DOScale(1.4f, 0.2f).SetEase(Ease.OutBounce)
                .OnComplete(() => ScoreText.transform.DOScale(1f, 0.1f));
        }
    }

    public void RefreshGold()
    {
        GoldText.text = $"{CurrenyManager.Instance.Gold.ToString("N0")}";
        if (_prevGold<CurrenyManager.Instance.Gold)
        {
            _prevGold = CurrenyManager.Instance.Gold;
            GoldText.transform.DOScale(1.4f, 0.2f).SetEase(Ease.OutBounce)
                .OnComplete(() => GoldText.transform.DOScale(1f, 0.1f));
        }
    }

    public void BossAlert()
    {
        StartCoroutine(CoBossAlert());
    }

    private IEnumerator CoBossAlert()
    {
        yield return null;
    }
}