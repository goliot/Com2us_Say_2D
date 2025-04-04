using System.IO;
using System.Text;
using UnityEngine;

public class JsonManager : MonoBehaviour
{
    PlayerData playerData = new PlayerData();

    void Start()
    {
        string data = GetPlayerDataFromPrefs();
        playerData = LoadJsonData();
        DataToStat();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            SaveJsonData();
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadJsonData();
            Debug.Log($"score = {playerData.Score}, killCount = {playerData.KillCount}, BoomCount = {playerData.BoomCount}");
        }
    }

    private void DataToStat()
    {
        if(playerData == null)
        {
            return;
        }

        PlayerStats.MaxHp = playerData.MaxHp;
        PlayerStats.Hp = playerData.Hp;
        PlayerStats.FireCoolTime = playerData.FireCoolTime;
        PlayerStats.Speed = PlayerStats.Speed;
        PlayerStats.KillCount = playerData.KillCount;
        PlayerStats.BoomCount = playerData.BoomCount;
        PlayerStats.Score = playerData.Score;
    }

    private void StatToData()
    {
        playerData.MaxHp = PlayerStats.MaxHp;
        playerData.Hp = PlayerStats.Hp;
        playerData.FireCoolTime = PlayerStats.FireCoolTime;
        playerData.Speed = PlayerStats.Speed;
        playerData.Score = PlayerStats.Score;
        playerData.KillCount = PlayerStats.KillCount;
        playerData.BoomCount = PlayerStats.BoomCount;
    }

    public void CreateJsonData()
    {
        string path = Application.dataPath + "/Resources/Json/PlayerData.json";
        StatToData();

        FileStream fileStream = new FileStream(path, FileMode.Create);

        string data = DataToJson(playerData);
        byte[] bData = Encoding.UTF8.GetBytes(data);
        fileStream.Write(bData, 0, bData.Length);
        fileStream.Close();
    }

    public void SaveJsonData()
    {
        string path = Application.dataPath + "/Resources/Json/PlayerData.json";
        StatToData();

        FileStream fileStream = new FileStream(path, FileMode.Open);

        string data = DataToJson(playerData);
        data = AesEncryption.Encrypt(data);
        byte[] bData = Encoding.UTF8.GetBytes(data);
        fileStream.Write(bData, 0, bData.Length);
        fileStream.Close();

        PlayerPrefs.SetString("PlayerData", data);
    }

    public PlayerData LoadJsonData()
    {
        string path = Application.dataPath + "/Resources/Json/PlayerData.json";
        FileStream fileStream = new FileStream(path, FileMode.Open);
        byte[] bData = new byte[fileStream.Length];
        fileStream.Read(bData, 0, bData.Length);
        fileStream.Close();
        string jsonData = Encoding.UTF8.GetString(bData);
        jsonData = AesEncryption.Decrypt(jsonData);
        return JsonToData(jsonData);
    }

    public string GetPlayerDataFromPrefs()
    {
        return PlayerPrefs.GetString("PlayerData");
    }

    public string DataToJson(PlayerData data)
    {
        string json = JsonUtility.ToJson(data);

        return json;
    }

    public PlayerData JsonToData(string json)
    {
        return JsonUtility.FromJson<PlayerData>(json);
    }
}
