using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfo
{
    public string nickName
    {
        get
        {
            return _nickName;
        }
        set
        {
            _nickName = value;
        }
    }

    public int playerIndex
    {
        get
        {
            return _playerIndex;
        }
        set
        {
            _playerIndex = value;
        }
    }

    public float energy
    {
        get
        {
            return _energy;
        }
        set
        {
            _energy = value;
        }
    }

    private string _nickName = "";
    private int _playerIndex = 0;
    private float _energy = 0;
    public PlayerInfo()
    {        
    }
   
    public void Save()
    {
        PlayerPrefs.SetString("nickName", _nickName);
        PlayerPrefs.SetInt("playerIndex", _playerIndex);
        PlayerPrefs.SetFloat("energy", _energy);
    }

    public void Load()
    {
        _nickName = PlayerPrefs.GetString("nickName", "");
        _playerIndex = PlayerPrefs.GetInt("playerIndex", 0);
        _energy = PlayerPrefs.GetFloat("energy", 0f);
    }
}
public enum GameState { NONE,RUNNING,WIN,LOSE}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerInfo playerInfo = new PlayerInfo();
    public Transform spawnPointOfPlayer;
    public float timeLimit;
    public float energyLimit;
    [HideInInspector]
    public float curTime = 0;
    [HideInInspector]
    public float altitude;
    [HideInInspector]
    public float curAltitude;
    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public GameState gameState = GameState.NONE;

    private UIManager uiManager;
    [HideInInspector]
    public MainScreen mainScreen;

    private void Awake()
    {
        instance = this;
        playerInfo.Load();
        playerInfo.energy = energyLimit;
    }
    // Start is called before the first frame update
    void Start()
    {
        uiManager = UIManager.instance;
        mainScreen = MainScreen.instance;
        altitude = EndPoint.instance.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState != GameState.RUNNING)
            return;

        curTime += Time.deltaTime;
        if (curTime > timeLimit)
        {
            gameState = GameState.LOSE;
            UIManager.instance.EndStage();
        }

        mainScreen.UpdateGameStateInfo();
            
        if(Input.GetKey(KeyCode.Escape))
        {
            playerInfo.nickName = "";
            playerInfo.Save();
            SceneManager.LoadSceneAsync(0);
        }
    }

    public void InstantiatePlayer()
    {
        if (spawnPointOfPlayer == null)
            return;

        player = Instantiate(Resources.Load("Players/player" + playerInfo.playerIndex.ToString()) as GameObject) as GameObject;
        player.transform.parent = spawnPointOfPlayer;
        player.transform.localPosition = Vector3.zero;
        player.transform.localRotation = Quaternion.identity;

        gameState = GameState.RUNNING;
        curTime = 0;
        playerInfo.energy = energyLimit;
    }

    public void AddEnergy(float addEnergy)
    {
        if (gameState != GameState.RUNNING)
            return;

        playerInfo.energy += addEnergy;
        if(playerInfo.energy < 0)
        {
            gameState = GameState.LOSE;
            uiManager.EndStage();
        }
        mainScreen.UpdatePlayerInfoUI();
    }
}
