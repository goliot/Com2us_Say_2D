using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UI_WarningPanel : MonoBehaviour
{
    public GameObject text;

    float timer = 0;

    private void OnEnable()
    {
        timer = 0;
        text.transform.DOScale(1.5f, 0.5f).SetLoops(3, LoopType.Yoyo);
        gameObject.GetComponent<Image>().DOColor(new Color(255, 0, 0, 0), 0.5f).SetLoops(3, LoopType.Yoyo).OnComplete(() => gameObject.SetActive(false));
    }

    private void Update()
    {
        timer += Time.deltaTime;

        //if (timer > 3)
        //    text.SetActive(false);
        //    gameObject.SetActive(false);
    }
}
