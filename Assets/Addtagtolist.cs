using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//ゲーム開始とともにジェンガにゲームオーバー処理に必要なタグを付与するスクリプト　☆必ずゲーム管理用空オブジェクトを用意し、そこにアタッチすること

public class Addtagtolist : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //tagの付与(下例は「Cube」という名前のオブジェクトに「jenga」タグを付与)
        AddTag("jenga","Cube");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //参考 https://qiita.com/seinosuke/items/e8c7ee2e1f98a76070e2
    void AddTag(string tagname,string objectname) {
        UnityEngine.Object[] asset = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset");
        if ((asset != null) && (asset.Length > 0)) {
            SerializedObject so = new SerializedObject(asset[0]);
            SerializedProperty tags = so.FindProperty("tags");

            //引数のタグがすでにリストに存在するか確認
            for (int i = 0; i < tags.arraySize; ++i) {
                if (tags.GetArrayElementAtIndex(i).stringValue == tagname) {
                    return;
                }
            }

            int index = tags.arraySize;
            tags.InsertArrayElementAtIndex(index);//空の要素をインデックス「index」に挿入
            tags.GetArrayElementAtIndex(index).stringValue = tagname;//引数のタグを追加
            so.ApplyModifiedProperties();//更新処理
            so.Update();
        }

        //☆objectnameそのものだけでなく連番などobjectnameを含む名前のオブジェクトすべてに付与できるようにする


        
        GameObject gameobject;
        gameobject=GameObject.Find(objectname);
        gameobject.tag=tagname;

    }


}
