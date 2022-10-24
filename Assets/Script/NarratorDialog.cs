using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorDialog : MonoBehaviour
{
    public static NarratorDialog instance = null;
    public UILabel scriptLabel;

    private TypewriterEffect typewriterEffect;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        typewriterEffect = gameObject.GetComponent<TypewriterEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if(GetVisible())
                SetVisible(false);
        }
    }

    public void TypeNarratorScript(string _script)
    {
        StopAllCoroutines();
        _script = _script.Replace("[n]", "\n");        
        scriptLabel.text = _script;        
        StartCoroutine(HideScript());
    }

    public void SetVisible(bool visible)
    {
        transform.localScale = visible ? Vector3.one : Vector3.zero;
    }

    public bool GetVisible()
    {
        return transform.localScale.x == 1;
    }

    IEnumerator HideScript()
    {
        SetVisible(true);
        yield return new WaitForSeconds(10f);
        SetVisible(false);
    }
}
