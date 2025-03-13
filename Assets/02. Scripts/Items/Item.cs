using DG.Tweening;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected EItemType itemType;

    protected GameObject PlayerObject;

    private Tweener _moveTweener = null;
    private float _triggerTimer = 0f;
    private float _deactiveTimer = 0f;
    private float _deactiveTime = 10f;
    private bool _isTweenComplete = false;

    public abstract void Effect();

    private void Awake()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        _deactiveTimer += Time.deltaTime;
        if (_deactiveTimer > _deactiveTime)
        {
            Destroy(gameObject);
        }
        if (Vector3.Distance(transform.position, PlayerObject.transform.position) < 2f)
        {
            if(_isTweenComplete && _moveTweener != null)
                transform.position = Vector3.Lerp(transform.position, PlayerObject.transform.position, Time.deltaTime * 3f);
            else
                TowardPlayer(); 
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _triggerTimer += Time.deltaTime;
            if (_triggerTimer > 1f)
            {
                Effect();
                Debug.Log("Effect");
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _triggerTimer = 0f;
        }
    }

    protected void TowardPlayer()
    {
        Vector3 targetPos = PlayerObject.transform.position;

        //_moveTweener?.Kill();

        //_moveTweener = transform.DOMove(targetPos, 0.2f).SetEase(Ease.Linear).OnComplete(TowardPlayer);

        Vector3[] path = new Vector3[]
        {
            transform.position,
            transform.position + (Vector3)Random.insideUnitCircle * 0.5f,
            PlayerObject.transform.position
        };
        _moveTweener = transform.DOPath(path, 0.2f, PathType.CatmullRom)
            .SetEase(Ease.InOutSine).OnComplete(()=>_isTweenComplete = true);
    }
}
