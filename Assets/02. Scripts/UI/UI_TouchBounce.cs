using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using Coffee.UIEffects;
using Coffee.UIExtensions;

public class UI_TouchBounce : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float EndScale = 0.9f;
    public float StartScale = 1f;
    public float Duration = 0.2f;
    
    private RectTransform _rectTransform;

    [Header("Click Effect")]
    public GameObject ClickParticle;
    public UIEffect UiEffect;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        StartScale = transform.localScale.x;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(EndScale, Duration).SetEase(Ease.InOutBounce).OnComplete(() => transform.localScale = Vector3.one * EndScale);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(StartScale, Duration).SetEase(Ease.InOutBounce).OnComplete(() => transform.localScale = Vector3.one * StartScale);
        GameObject go = Instantiate(ClickParticle, transform);
        go.transform.position = transform.position;
        var uiParticle = go.AddComponent<UIParticle>();
        uiParticle.scale = 100;

        uiParticle.Play();
    }
}
