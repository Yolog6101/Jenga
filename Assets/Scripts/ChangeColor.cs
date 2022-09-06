using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;

public class ChangeColor : MonoBehaviour
{
    public GameObject cube;
    public Material mat;

    // Start is called before the first frame update
    void Start()
    {

    }

    //キューブの色をHSVで取得
    public float[] GetHSVColor()
    {
        float[] hsv = new float[3];
        Color.RGBToHSV(cube.GetComponent<Renderer>().material.color, out hsv[0], out hsv[1], out hsv[2]);
        return hsv;
    }

    //キューブの色をHSVで変更
    public void SetHSVColor(float h, float s, float v)
    {
        cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(h, s, v);
    }

    void Update()
    {
        //キューブの色をHSVで取得
        float[] hsv = GetHSVColor();
        //キューブの色をHSVで変更
        SetHSVColor(hsv[0], hsv[1], hsv[2]);
    }

    //掴まれた時にキューブの色を変更
    public void OnGrab()
    {
        //キューブの色をHSVで取得
        float[] hsv = GetHSVColor();
        //キューブの色をHSVで変更
        SetHSVColor(hsv[0], hsv[1], hsv[2]+0.1f);

        //キューブの色を赤色に変更
        // cube.GetComponent<Renderer>().material.color = Color.red;
    }

    //離された時にキューブの色を変更
    public void OnRelease()
    {
        // //キューブの色をHSVで取得
        // float[] hsv = GetHSVColor();
        // //キューブの色をHSVで変更
        // SetHSVColor(hsv[0], hsv[1], hsv[2]);

        //キューブの色をmaterialの色に変更
        cube.GetComponent<Renderer>().material.color = mat.color;
    }
}
