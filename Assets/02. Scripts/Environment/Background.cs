using UnityEngine;

public class Background : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Material _material;

    public float ScrollSpeed = 1f;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _material = GetComponent<Renderer>().material;

        // 원본 material의 복사본의 인스턴스 vs sharedMaterial
        //_material = _spriteRenderer.material; 

        //그걸 다시 내 spriteRenderer에 적용
        //_spriteRenderer.material = _material;
    }

    private void Update()
    {
        Vector2 direction = Vector2.up;

        _material.mainTextureOffset += direction * ScrollSpeed * Time.deltaTime;
    }
}
