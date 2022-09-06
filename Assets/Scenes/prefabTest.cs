using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PrefabTest : MonoBehaviour {
 
    // Use this for initialization
    void Start () {
        // blockpairプレハブをGameObject型で取得
        GameObject obj = (GameObject)Resources.Load ("blockPair");
        // blockpairプレハブを元に、インスタンスを生成、
        Instantiate (obj, new Vector3(0.0f,2.0f,0.0f), Quaternion.identity);
    }
 
}
