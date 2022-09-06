using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//ゲーム開始とともにジェンガにゲームオーバー処理に必要なタグを付与するスクリプト　☆必ずゲーム管理用空オブジェクトを用意し、そこにアタッチすること

public class Startmanage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //tagの付与(下例は第2引数の名前のオブジェクトに含まれるオブジェクトすべて(孫)に「jenga」タグを付与)
        AddTagList("jenga");
        AddTag("jenga","GameObject");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //参考 https://qiita.com/seinosuke/items/e8c7ee2e1f98a76070e2
    void AddTagList(string tagname) {
        UnityEngine.Object[] asset = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset");
        // if ((asset != null) && (asset.Length > 0)) {
        //     SerializedObject so = new SerializedObject(asset[0]);
        //     SerializedProperty tags = so.FindProperty("tags");

        //     // //引数のタグがすでにリストに存在するか確認
        //     // for (int i = 0; i < tags.arraySize; ++i) {
        //     //     if (tags.GetArrayElementAtIndex(i).stringValue == tagname) {
        //     //         return;
        //     //     }
        //     // }

        //     int index = tags.arraySize;
        //     tags.InsertArrayElementAtIndex(index);//空の要素をインデックス「index」に挿入
        //     tags.GetArrayElementAtIndex(index).stringValue = tagname;//引数のタグを追加
        //     so.ApplyModifiedProperties();//更新処理
        //     so.Update();
        // }
        SerializedObject so = new SerializedObject(asset[0]);
        SerializedProperty tags = so.FindProperty("tags");
        int index = tags.arraySize;
        tags.InsertArrayElementAtIndex(index);//空の要素をインデックス「index」に挿入
        tags.GetArrayElementAtIndex(index).stringValue = tagname;//引数のタグを追加
        so.ApplyModifiedProperties();//更新処理
        so.Update();
    }

    void AddTag(string tagname,string objectsname){
        //ジェンガオブジェクトすべてを持つオブジェクトの名前objectsnameを利用　参考 https://qiita.com/No2DGameNoLife/items/696a9ddbe32847955303 https://sunagitsune.com/unitygetchild/
        GameObject gameobjects;
        GameObject gegameobjects;//子
        GameObject gegegameobjects;//孫
        gameobjects=GameObject.Find(objectsname);//
        for(int i=0;i<gameobjects.transform.childCount;i++){//子オブジェクト
            gegameobjects=gameobjects.transform.GetChild(i).gameObject;
            //(暫定)ジェンガではないのでtagやOnCollisionEnterSampleはつけない
            for(int m=0;m<gegameobjects.GetComponent<Transform>().transform.childCount;m++){//孫オブジェクト
             gegegameobjects=gegameobjects.GetComponent<Transform>().transform.GetChild(m).gameObject;
             //Debug.Log(gegegameobjects.name);
             gegegameobjects.tag=tagname;
             //OnCollisionEnterSampleを付与
             gegegameobjects.AddComponent<OnCollisionEnterSample>();
            } 
        }
        
    }


}
