using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinDialog : MonoBehaviour
{
    public UILabel consumeEnergyLabel;
    public UILabel timeLabel;
    public UILabel climbSpeedLabel;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init()
    {
        gameManager = GameManager.instance;
        float consumeEnergy = gameManager.energyLimit - gameManager.playerInfo.energy;
        consumeEnergyLabel.text = string.Format("{0:0.00}", consumeEnergy) + "[99ff00]kJ[-]";
        timeLabel.text = string.Format("{0:0.00}", gameManager.curTime) + "[99ff00]s[-]";
        climbSpeedLabel.text = string.Format("{0:0.00}", gameManager.altitude / gameManager.curTime) + "[99ff00]m/s[-]";
    }

    public void RestartButtonClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0);
    }
}
