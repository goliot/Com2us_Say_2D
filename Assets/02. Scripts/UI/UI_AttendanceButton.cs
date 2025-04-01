using Coffee.UIEffects;
using Coffee.UIExtensions;
using DG.Tweening;
using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_AttendanceButton : MonoBehaviour
{
    public Attendance _attendance;

    public TextMeshProUGUI DayTextUI;
    public TextMeshProUGUI AmountTextUI;

    [Header("Click Effect")]
    public GameObject ClickParticle;
    private bool _isClickHold = false;
    private Coroutine _coClickHold;
    public UIEffect UiEffect;

    private Image _image;
    private Button _button;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
        //ClickParticle.Stop();
        UiEffect = GetComponent<UIEffect>();
    }

    public void Refresh()
    {
        _image.color = _attendance.IsRewarded ? Color.black : Color.white;
        _button.interactable = !_attendance.IsRewarded;
        DayTextUI.text = (_attendance.Data.Day + 1).ToString();
        AmountTextUI.text = _attendance.Data.RewardAmount.ToString();
    }

    public void OnClick()
    {
        
    }

    public void OnClickHold()
    {
        if (_coClickHold == null)
        {
            _coClickHold = StartCoroutine(CoClickHold());
        }
    }

    public void OnClickUp()
    {
        Debug.Log("클릭!");

        if(AttendanceManager.Instance.TryGetReward(_attendance))
        {
            GameObject go = Instantiate(ClickParticle, transform);
            go.transform.position = transform.position;
            var uiParticle = go.AddComponent<UIParticle>();
            uiParticle.scale = 100;

            uiParticle.Play();

            Refresh();
        }
        
        _isClickHold = false;
    }

    IEnumerator CoClickHold()
    {
        _isClickHold = true;
        transform.DOScale(0.9f, 0.2f).SetEase(Ease.Linear).OnComplete(() => transform.localScale = new Vector3(0.9f, 0.9f, 0.9f));

        while (_isClickHold)
        {
            yield return null;
        }

        transform.DOScale(1, 0.2f).SetEase(Ease.InOutSine);
        _coClickHold = null;
    }
}