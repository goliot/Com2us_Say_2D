using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject MainCamera;
    public Player player;
    public Spawner spawner;

    public bool IsBossSpawned = false;
    public bool IsFever = false;
    public bool IsGamePaused = false;

    public Action GamePaused;

    private void Awake()
    {
        //PlayerStats.Load();

        MainCamera = Camera.main.gameObject;
        Time.timeScale = 1;
    }

    private void Start()
    {
        //UI_Game.Instance.OpenAttendancePanel();
        //IsGamePaused = true;
        //Time.timeScale = 0;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            spawner.SpawnBoss();
        }
    }

    public void PlayerDieSlowDown()
    {
        Time.timeScale = 0.5f;
        MainCamera.GetComponent<CameraShake>().DieShake();
    }

    public IEnumerator CoFever()
    {
        IsFever = true;
        Time.timeScale = 4f;
        foreach (var fever in player.GetComponent<PlayerSkill>().FeverEffects)
        {
            fever.SetActive(true);
        }
        yield return new WaitForSeconds(12f);
        Time.timeScale = 1f;
        foreach (var fever in player.GetComponent<PlayerSkill>().FeverEffects)
        {
            fever.SetActive(false);
        }
        IsFever = false;
    }
}
