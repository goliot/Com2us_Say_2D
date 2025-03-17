using DG.Tweening;
using UnityEngine;

public abstract class ItemRoot : MonoBehaviour
{
    protected EItemType itemType;

    protected GameObject PlayerObject;

    private Tweener _moveTweener = null;
    private float _triggerTimer = 0f;
    private float _deactiveTimer = 0f;
    private float _deactiveTime = 3f;
    private bool _isTweenComplete = false;

    private float _percent = 0f;
    private Vector2 _controlPoint = Vector2.zero;
    private float _distance = 0;
    private float _duration = 0;
    public float Speed = 5f;

    [Header("# VFX")]
    public GameObject ItemGetVFX;

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

        /*if (Vector3.Distance(transform.position, PlayerObject.transform.position) < 3f)
        {
            _duration = _distance / Speed;
            if (_controlPoint == Vector2.zero)
                _controlPoint = (Vector2)(transform.position + PlayerObject.transform.position) / 2 + Random.insideUnitCircle;

            _percent += Time.deltaTime / _duration;
            transform.position = Bezier(transform.position, _controlPoint, PlayerObject.transform.position, _percent);
        }*/

        if (Vector3.Distance(transform.position, PlayerObject.transform.position) < 3f)
        {
            if (_moveTweener == null)
            {
                TowardPlayer();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Effect();
            Instantiate(ItemGetVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private Vector2 Bezier(Vector2 start, Vector2 center, Vector2 end, float t)
    {
        Vector2 p1 = Vector2.Lerp(start, center, t);
        Vector2 p2 = Vector2.Lerp(center, end, t);
        Vector2 final = Vector2.Lerp(p1, p2, t);

        return final;
    }

    protected void TowardPlayer()
    {
        Vector3 targetPos = PlayerObject.transform.position;

        Vector3[] path = new Vector3[]
        {
            transform.position,
            transform.position + (Vector3)Random.insideUnitCircle * 0.5f,
            PlayerObject.transform.position
        };
        _moveTweener = transform.DOPath(path, 0.2f, PathType.CatmullRom)
            .SetEase(Ease.InOutSine).OnComplete(()=>_isTweenComplete = true);
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _triggerTimer += Time.deltaTime;
            if (_triggerTimer > 1f)
            {
                Effect();
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
    }*/
}
