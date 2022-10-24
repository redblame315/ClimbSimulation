using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEffect : MonoBehaviour
{   

    public float maxIntensity = 2f;
    public float minIntensity = .3f;
    public float intensitySpeed = .5f;

    Light light;
    int alpha = 1;
    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (light.intensity > maxIntensity)
            alpha = -1;

        if (light.intensity < minIntensity)
            alpha = 1;

        light.intensity += alpha * intensitySpeed * Time.deltaTime;
    }
}
