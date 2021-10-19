using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] float shakeTimeStandardLight = 0.2f;
    [SerializeField] float strengthStandardLight = 0.2f;
    float screenShakeStrength = 0;
    float screenShakeTimer = 0;
    static CameraController instance;
    Vector3 offset;


    void Awake()
    {
        offset = new Vector3(0, 0, transform.position.z);
        instance = this;
    }

    void Update()
    {
        Vector3 newPos = transform.position;

        if (screenShakeTimer > 0)
        {
            newPos += Random.onUnitSphere * screenShakeStrength;
            screenShakeTimer -= Time.deltaTime;
            transform.position = newPos;
        }

        else 
        {
            transform.position = new Vector3(0f, 0f, -10f);
        }



    }

    public static void ScreenShakeLight()
    {
        instance.screenShakeStrength = instance.strengthStandardLight;
        instance.screenShakeTimer = instance.shakeTimeStandardLight;
    }

    public static void ScreenShake(float strength, float shakeTime)
    {
        instance.screenShakeStrength = strength;
        instance.screenShakeTimer = shakeTime;
    }
}


