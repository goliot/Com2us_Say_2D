using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // MonoBehaviour : 여러 이벤트 함수를 자동으로 호출
    // Component : 게임 오브젝트에 추가할 수 있는 여러 기능
    public float Speed = 3f;
    public float MaxY = 0f;
    public float MinY = -4.5f;
    public float MaxSpeed = 10f;
    public float MinSpeed = 1f;

    private Vector2 _direction = new Vector2();
    private SpriteRenderer _sr;
    [SerializeField] private GameObject _closestEnemy = null;
    [SerializeField] private Vector3 AutoDefaultPosition;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        MinY = Camera.main.transform.position.y - Camera.main.orthographicSize;
    }

    private void Update()
    {
        SpeedUp();
        if (PlayerMode.PlayMode == PlayMode.Auto)
        {
            FindClosestEnemy();
            SetAutoMoveDirection();
        }
        else
        {
            AxisInput();
        }
        Move();
        CheckCameraBound();
    }

    private void FindClosestEnemy()
    {
        float minDistance = float.MaxValue;
        float currentDistance;
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemy in enemys)
        {
            currentDistance = Vector3.Distance(enemy.transform.position, transform.position);
            if (minDistance > currentDistance)
            {
                _closestEnemy = enemy;
                minDistance = currentDistance;
            }
        }
    }

    private void Move()
    {
        if (transform.position.y >= MaxY && _direction.y > 0 || transform.position.y <= MinY && _direction.y < 0)
        {
            _direction.y = 0;
        }
        transform.Translate(_direction * Speed * Time.deltaTime);
    }

    private void SetAutoMoveDirection()
    {
        if (_closestEnemy == null)
        {
            return;
        }
        // 적이 가까워지면
        // X는 적방향으로, Y는 으로
        if (Vector3.Distance(_closestEnemy.transform.position, transform.position) < 3f)
        {
            _direction.x = _closestEnemy.transform.position.x > transform.position.x ? 1 : -1;
            _direction.y = _closestEnemy.transform.position.y > transform.position.y ? -1 : 1;
            Vector3.Normalize(_direction);
        }
        // 가까운 적이 없으면
        // 위 중앙으로
        else
        {
            if (Vector3.Distance(AutoDefaultPosition, transform.position) < 0.1f)
            {
                _direction = Vector3.zero;
            }
            else
            {
                _direction = Vector3.Normalize(AutoDefaultPosition - transform.position);
            }
        }
    }

    private void AxisInput()
    {
        float h = Input.GetAxisRaw("Horizontal"); // 수평(좌우)
        float v = Input.GetAxisRaw("Vertical"); // 수직(좌우)

        _direction = new Vector2(h, v).normalized;
    }

    private void SpeedUp()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Speed = Mathf.Max(MinSpeed, Speed - 1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Speed = Mathf.Min(MaxSpeed, Speed + 1);
        }
    }

    private void CheckCameraBound()
    {
        float leftEdge = _sr.bounds.min.x;
        float rightEdge = _sr.bounds.max.x;

        float leftCameraEdge = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        float rightCameraEdge = Camera.main.ViewportToWorldPoint(Vector3.one).x;

        if (leftCameraEdge > rightEdge || rightCameraEdge < leftEdge)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, transform.position.z);
        }
    }
}