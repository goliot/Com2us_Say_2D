using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // MonoBehaviour : ���� �̺�Ʈ �Լ��� �ڵ����� ȣ��
    // Component : ���� ������Ʈ�� �߰��� �� �ִ� ���� ���

    private void Update()
    {
        // ���� �ʴ� 3���� ��������
        transform.Translate(Vector2.up * 3f * Time.deltaTime);
    }
}
