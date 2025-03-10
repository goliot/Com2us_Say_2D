using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // MonoBehaviour : 여러 이벤트 함수를 자동으로 호출
    // Component : 게임 오브젝트에 추가할 수 있는 여러 기능

    private void Update()
    {
        // 위로 초당 3미터 움직여라
        transform.Translate(Vector2.up * 3f * Time.deltaTime);
    }
}
