using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomProgressBar : MonoBehaviour
{
    public UILabel valueLabel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrentProgress()
    {
        if (UIProgressBar.current != null)
            valueLabel.text = ((int)(UIProgressBar.current.value * GameManager.instance.energyLimit)).ToString();
    }
}
