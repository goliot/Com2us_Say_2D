using UnityEngine;

public class Background : MonoBehaviour
{
    private Renderer _renderer;
    private MaterialPropertyBlock _materialPropertyBlock;

    private Vector2 _currentOffset;
    public float ScrollSpeed = 1f;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _materialPropertyBlock = new MaterialPropertyBlock();
    }

    private void Update()
    {
        _currentOffset += new Vector2(0, ScrollSpeed * Time.deltaTime);
        _renderer.GetPropertyBlock(_materialPropertyBlock);
        _materialPropertyBlock.SetVector("_MainTex_ST", new Vector4(1, 1, _currentOffset.x, _currentOffset.y));
        _renderer.SetPropertyBlock(_materialPropertyBlock);
    }
}