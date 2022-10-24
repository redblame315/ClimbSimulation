using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorTrigger : MonoBehaviour
{
    public string scriptContent;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!string.IsNullOrEmpty(scriptContent))
            NarratorDialog.instance.TypeNarratorScript(scriptContent);

        gameObject.SetActive(false);
    }
}
