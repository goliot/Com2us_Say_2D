using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // MonoBehaviour : ���� �̺�Ʈ �Լ��� �ڵ����� ȣ��
    // Component : ���� ������Ʈ�� �߰��� �� �ִ� ���� ���
    public float Speed = 3f;
    public float BoarderSize = 2.5f;
    public float UnderCenter = -0.5f;

    private SpriteRenderer _sr;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Speed = Speed <= 0 ? Speed : Speed - 1;
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            Speed++;
        }
        float h = Input.GetAxisRaw("Horizontal"); // ����(�¿�)
        float v = Input.GetAxisRaw("Vertical"); // ����(�¿�)

        Vector2 direction = new Vector2(h, v).normalized;
        if (transform.position.y >= UnderCenter && v > 0)
        {
            direction.y = 0;
        }
        transform.Translate(direction * Speed * Time.deltaTime);

        CheckCameraBound();
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