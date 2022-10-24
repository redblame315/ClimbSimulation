using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;
    public UIScreen characterUIScreen;
    public UIScreen mainUIScreen;
    public GameObject characterSelectObj;
    public LoseDialog loseDialog;
    public WinDialog winDialog;
    private PlayerInfo playerInfo;
    private GameManager gameManager;

    private void Awake()
    {
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;        
        playerInfo = GameManager.instance.playerInfo;
        if (string.IsNullOrEmpty(playerInfo.nickName))
            characterUIScreen.Focus();
        else
        {
            mainUIScreen.Focus();
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }    

    public void HideCharacterSelectObj()
    {
        characterSelectObj.SetActive(false);
    }

    public void ShowCharacterSelectObj()
    {
        characterSelectObj.SetActive(true);
    }

    public void EndStage()
    {
        if (GameManager.instance.gameState == GameState.WIN)
        {
            winDialog.gameObject.SetActive(true);
            winDialog.Init();
        }            
        else
            loseDialog.gameObject.SetActive(true);

        GameManager.instance.player.GetComponent<Rigidbody>().isKinematic = true;
        NarratorDialog.instance.SetVisible(false);
    }
}
