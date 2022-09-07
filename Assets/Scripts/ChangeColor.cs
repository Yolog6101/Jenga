using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.UI;

public class ChangeColor : MonoBehaviour
{
    ObjectManipulator objectManipulator;

    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        //nameと同じ名前のオブジェクトを取得
        gameObject = GameObject.Find(name);
        Debug.Log(name);

        objectManipulator = gameObject.GetComponent<ObjectManipulator>();
        objectManipulator.OnManipulationStarted.AddListener(OnManipulationStarted);
        objectManipulator.OnManipulationEnded.AddListener(OnManipulationEnded);

    }

    //キューブの色をHSVで取得
    public float[] GetHSVColor()
    {
        float[] hsv = new float[3];
        Color.RGBToHSV(gameObject.GetComponent<Renderer>().material.color, out hsv[0], out hsv[1], out hsv[2]);
        return hsv;
    }

    //キューブの色をHSVで変更
    public void SetHSVColor(float h, float s, float v)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.HSVToRGB(h, s, v);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnManipulationStarted(ManipulationEventData eventData)
    {
        //キューブの色をHSVで取得
        float[] hsv = GetHSVColor();
        //キューブの色をHSVで変更
        SetHSVColor(hsv[0], hsv[1], hsv[2]+0.2f);
    }

    void OnManipulationEnded(ManipulationEventData eventData)
    {
        //キューブの色をHSVで取得
        float[] hsv = GetHSVColor();
        //キューブの色をHSVで変更
        SetHSVColor(hsv[0], hsv[1], hsv[2]-0.2f);
    }
}
