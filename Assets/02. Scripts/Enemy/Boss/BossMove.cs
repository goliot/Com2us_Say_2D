using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;

public class BossMove : MonoBehaviour
{
    [SerializeField] private Vector3 LeftPosition;
    [SerializeField] private Vector3 RightPosition;

    private Boss _boss;
    private BossState _bossState;
    private Tween _finchTween = null;
    private Tween _rageTween = null;

    private void Awake()
    {
        _boss = gameObject.GetComponent<Boss>();
    }

    private void Update()
    {
        if (!_boss.IsEntryEnded)
            return;

        _bossState = _boss.BossState;
        switch(_bossState)
        {
            case BossState.Finch:
            case BossState.Rage:
                if (_finchTween == null)
                    ToFinchMove();
                break;
            default:
                break;
        }
    }

    private void ToFinchMove()
    {
        _finchTween = transform.DOMove(RightPosition, 1.5f)
            .SetEase(Ease.Linear)
            .OnComplete(() => FinchMove());
    }

    private void FinchMove()
    {
        _finchTween = transform.DOMove(LeftPosition, 3f)
            .OnComplete(() => transform.DOMove(RightPosition, 3f))
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void ToRageMove()
    {
        _rageTween = transform.DOMove(RightPosition, 1.5f)
            .SetEase(Ease.Linear)
            .OnComplete(() => RageMove());
    }

    private void RageMove()
    {
        Vector3[] points = { LeftPosition, transform.position + (Vector3)Random.insideUnitCircle * 2f, RightPosition };
        _rageTween = transform.DOPath(points, 3f)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                (points[0], points[2]) = (points[2], points[0]);
                points[1] = transform.position + (Vector3)Random.insideUnitCircle * 2f;
                transform.DOPath(points, 3f);
            })
            .OnComplete(() => _rageTween = null);
    }
}
