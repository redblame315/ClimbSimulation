using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectScreen : UIScreen
{
    public static CharacterSelectScreen instance = null;
    public UISprite characterSprite;
    public UILabel skinTypeLabel;
    public NameScreen nameScreen;
    public string[] skinTypeArray;
    public GameObject[] characterObjArray;
    [HideInInspector]
    public int skinIndex = 0;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        skinTypeLabel.text = skinTypeArray[skinIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SkinPrevButtonClicked()
    {
        skinIndex--;
        if (skinIndex < 0)
            skinIndex = 0;

        skinTypeLabel.text = skinTypeArray[skinIndex];
        for (int i = 0; i < characterObjArray.Length; i++)
            characterObjArray[i].SetActive(i == skinIndex);
    }

    public void SkinNextButtonClicked()
    {
        skinIndex++;
        if (skinIndex >= skinTypeArray.Length)
        {
            skinIndex = skinTypeArray.Length - 1;
        }

        skinTypeLabel.text = skinTypeArray[skinIndex];
        for (int i = 0; i < characterObjArray.Length; i++)
            characterObjArray[i].SetActive(i == skinIndex);
    }

    public void NextButtonClicked()
    {
        nameScreen.gameObject.SetActive(true);
    }
    public override void Init()
    {
        UIManager.instance.ShowCharacterSelectObj();
        if (GameManager.instance.player != null)
            Destroy(GameManager.instance.player);
    }    
}
