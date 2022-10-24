using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public static EndPoint instance = null;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (GameManager.instance.gameState == GameState.WIN)
            return;

        GameManager.instance.gameState = GameState.WIN;
        UIManager.instance.EndStage();
    }
}
