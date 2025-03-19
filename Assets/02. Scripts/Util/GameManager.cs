using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindAnyObjectByType<GameManager>();
            }
            return _instance;
        }
    }

    public GameObject MainCamera;
    public Player player;
    public UI_Game UI;

    private void Awake()
    {
        MainCamera = Camera.main.gameObject;
        Time.timeScale = 1;
    }

    public void PlayerDieSlowDown()
    {
        Time.timeScale = 0.5f;
        MainCamera.GetComponent<CameraShake>().DieShake();
    }
}
