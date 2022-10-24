using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreen : UIScreen
{
    public static MainScreen instance = null;
    public UILabel nickNameLabel;
    public UISprite heroSprite;
    public UIProgressBar energyProgressBar;
    public UISprite timerSprite;
    public UILabel timerLabel;
    public UISlider altitudeSlider;
    public UILabel altitudeLabel;
    public UILabel curAltitudeLabel;

    GameManager gameManager;
    PlayerInfo playerInfo;

    private void Awake()
    {
        instance = this;
    }
    public override void Init()
    {
        gameManager = GameManager.instance;
        playerInfo = gameManager.playerInfo;
        gameManager.mainScreen = this;

        UIManager.instance.HideCharacterSelectObj();
        gameManager.InstantiatePlayer();
        altitudeLabel.text = string.Format("{0:0,0.00}",EndPoint.instance.transform.position.y) + "m";

        nickNameLabel.text = playerInfo.nickName;
        heroSprite.spriteName = "player" + playerInfo.playerIndex.ToString();

        UpdatePlayerInfoUI();
        UpdateGameStateInfo();
    }

    public void UpdatePlayerInfoUI()
    {
        //energy show
        energyProgressBar.value = playerInfo.energy / GameManager.instance.energyLimit;
    }

    public void UpdateGameStateInfo()
    {
        timerSprite.fillAmount = gameManager.curTime / gameManager.timeLimit;
        //timerLabel.text = string.Format("{0:0.00;(0.00);zero}",gameManager.timeLimit - gameManager.curTime);
        timerLabel.text = Mathf.RoundToInt(gameManager.timeLimit - gameManager.curTime).ToString() + "s";
        altitudeSlider.value = gameManager.player.transform.position.y / gameManager.altitude;
        curAltitudeLabel.text = string.Format("{0:0.00;(0.00);zero}",gameManager.player.transform.position.y) + "m";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
