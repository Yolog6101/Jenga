using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        // 始めは白色
        GetComponent<Renderer>().material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        // キューブの色を取得
        // Color color = cube.GetComponent<Renderer>().material.color;

        // キューブの色をRGBAで取得
        // float r = color.r;
        // float g = color.g;
        // float b = color.b;
        // float a = color.a;

        //RGBを5ずつ変化させる


        // キューブの色を変更
        // GetComponent<Renderer>().material.color = new Color(r, g, b, a);



        if (Input.GetKeyDown(KeyCode.Space))
        {
            // GetComponent<Renderer>().material.color = Color.red;
            Color color = cube.GetComponent<Renderer>().material.color;
            float r = color.r;
            float g = color.g;
            float b = color.b;

            //rgbを表示
            Debug.Log(r);
            Debug.Log(g);
            Debug.Log(b);
        }
    }
}
