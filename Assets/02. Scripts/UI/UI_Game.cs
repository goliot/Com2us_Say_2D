using UnityEngine;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using System.Collections;
using UnityEngine.UI;

public class UI_Game : Singleton<UI_Game>
{
    public List<GameObject> Booms;

    [Header ("# Texts")]
    public TextMeshProUGUI KillCountText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GoldText;

    [Header ("# BossUI")]
    public Slider BossHpSlider;
    public Slider BossSubSlider;
    public GameObject WarnigPanel;

    private int _prevKillCount = 0;
    private int _prevScore = 0;
    private int _prevGold = 0;

    private void Start()
    {
        Refresh();
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
        for (int i = 0; i < 3; i++)
        {
            Booms[i].transform.DOScale(i < PlayerStats.BoomCount ? 1f : 0f, 0.2f);
        }

        UpdateText(KillCountText, ref _prevKillCount, PlayerStats.KillCount, "Kills : ");
        UpdateText(ScoreText, ref _prevScore, PlayerStats.Score, "Score : ");
        UpdateText(GoldText, ref _prevGold, CurrenyManager.Instance.Gold, "");
    }

    /// <summary>
    /// UI 텍스트 갱신 및 애니메이션 처리
    /// </summary>
    /// <param name="textElement">변경할 UI 텍스트</param>
    /// <param name="prevValue">이전 값 저장할 ref 변수</param>
    /// <param name="newValue">새로운 값</param>
    /// <param name="prefix">텍스트 앞에 붙일 문자열</param>
    private void UpdateText(TextMeshProUGUI textElement, ref int prevValue, int newValue, string prefix)
    {
        textElement.text = $"{prefix}{newValue:N0}";

        if (prevValue < newValue)
        {
            prevValue = newValue;
            textElement.transform.DOScale(1.4f, 0.2f)
                .SetEase(Ease.OutBounce)
                .OnComplete(() => textElement.transform.DOScale(1f, 0.1f));
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