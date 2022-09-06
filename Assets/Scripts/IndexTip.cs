using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;

public class IndexTip : MonoBehaviour
{
    //表示するObject
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        //表示する立方体の作成
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //大きさの調整
        cube.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        //色の調整
        // cube.GetComponent<Renderer>().material.color = Color.red;
        //rendering modeをTransparentにする
        // cube.GetComponent<Renderer>().material.renderQueue = 3000;
        cube.GetComponent<Renderer>().material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        cube.GetComponent<Renderer>().material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        cube.GetComponent<Renderer>().material.SetInt("_ZWrite", 0);
        cube.GetComponent<Renderer>().material.DisableKeyword("_ALPHATEST_ON");
        cube.GetComponent<Renderer>().material.EnableKeyword("_ALPHABLEND_ON");
        cube.GetComponent<Renderer>().material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        cube.GetComponent<Renderer>().material.renderQueue = 3000;
        cube.GetComponent<Renderer>().material.SetColor("_Color", new Color(1, 0, 0, 0f));
        //RGBAで透明にする
        // cube.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
        //rigidbodyの追加
        cube.AddComponent<Rigidbody>();
        //重力の無効化
        cube.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        //右手の人差し指の先端の位置を取得
        if(HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose))
        {
            //立方体の位置を変更
            cube.transform.position = pose.Position;
            //立方体の回転を変更
            cube.transform.rotation = pose.Rotation;
        }
        
    }
    
}
