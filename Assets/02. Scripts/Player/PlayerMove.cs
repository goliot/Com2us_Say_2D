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

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        MinY = Camera.main.transform.position.y - Camera.main.orthographicSize;
    }

    private void Update()
    {
        SpeedUp();
        AxisInput();
        Move();
        CheckCameraBound();
    }

    private void Move()
    {
        if (transform.position.y >= MaxY && _direction.y > 0 || transform.position.y <= MinY && _direction.y < 0)
        {
            _direction.y = 0;
        }
        transform.Translate(_direction * Speed * Time.deltaTime);
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