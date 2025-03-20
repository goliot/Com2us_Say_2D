using UnityEngine;
using UnityEngine.UI;

public class UI_BossHp : MonoBehaviour
{
    Slider slider;
    public Boss boss;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        //boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        if(boss != null)
        {
            slider.value = boss.Hp / boss.MaxHp;
        }
    }
}
