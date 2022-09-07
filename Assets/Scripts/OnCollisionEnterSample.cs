using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//ある名前空間を持つスクリプトのコンポーネントを使うにはこれ(using そのスクリプトに書かれている名前空間)が必要になる 参考:https://kamikoppu.info/unityengine-consideration/ 参考2:https://creive.me/archives/16164/
using Microsoft.MixedReality.Toolkit.Input;//NearInteractionGrabbableのある名前空間
using Microsoft.MixedReality.Toolkit.UI;//ObjectManipulatorのある名前空間
using UnityEngine.SceneManagement;

public class OnCollisionEnterSample : MonoBehaviour
{
    //private TMPro.TMP_Text gameover;
    //public TextMeshProUGUI gameOverText = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {   
        Vector3 plane = GameObject.Find("Plane").transform.position;  //床(plane)の(上部分の)y座標
        Vector3 tmp = this.transform.position;
        //jengaのy<planeのyの時Gameover処理を実行する(関数はこれから作る)
        if(tmp.y<plane.y){
           //Debug.Log("y="+tmp.y); 
           Flyawayjenga();
           //ここで関数を呼ぶ
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //衝突したオブジェクトがPlaneだった場合
        if(collision.gameObject.name=="Plane"){
            //オブジェクト自身の色を黒に変化させる(https://xr-hub.com/archives/3993)
            //GetComponent<Renderer>().material.color = Color.black;
            
            
            // //このジェンガを動かせないようにする(https://qiita.com/ryuuuuu000/items/200c4158ca7fc69dc827)
            // NearInteractionGrabbable movemanage=GetComponent<NearInteractionGrabbable>();
            // movemanage.enabled=false;
            // ObjectManipulator manage=GetComponent<ObjectManipulator>();
            // manage.enabled=false;
            //ジェンガすべて(つまり、tag="jenga"のオブジェクトすべて)動かせないようにする
            GameObject[] blocks = GameObject.FindGameObjectsWithTag ("jenga");//"jenga"のタグを持つオブジェクト一覧
            foreach(var b in blocks){
                //Debug.Log(b.name);
                NearInteractionGrabbable othermovemanage=b.GetComponent<NearInteractionGrabbable>();
                othermovemanage.enabled=false;
                ObjectManipulator othermanage=b.GetComponent<ObjectManipulator>();
                othermanage.enabled=false;
            }
            //SceneManager.LoadScene("fail");//Scene「fail」に飛ぶ　飛ばない場合はコメントアウト
            
            // TextMeshProUGUI gameOverText = GameObject.Find("gameover").GetComponent<TextMeshProUGUI>();
            // //ゲームオーバーの文字表示(ほぼ確認用、一応そのまま使えはする)
            // gameOverText.text="GameOver";
            // //このスクリプトから生成したコンポーネントにアタッチしたオブジェクト(=TextMeshPro)の「text」を「GameOver」に変更(アタッチしているのでGetComponentは不要)
            // gameOverText.color=new Color32(0,0,0,255);
            // //このスクリプトから生成したコンポーネントにアタッチしたオブジェクト(=TextMeshPro)の色(文字色 RGBA)を変更(アタッチしているのでGetComponentは不要)            
            // gameOverText.fontSize=100;//float型になる
            // //文字装飾(あらかじめShaderの「outline」をONにしておく)
            // gameOverText.outlineColor=new Color32(255,255,255,255);
            // gameOverText.outlineWidth=0.15f;
            // gameOverText.UpdateFontAsset();//更新
            // gameOverText.fontStyle=TMPro.FontStyles.Italic;//イタリック体(斜字)に(https://docs.unity3d.com/Packages/com.unity.textmeshpro@1.3/api/TMPro.FontStyles.html)           
            // //このスクリプトから生成したコンポーネントにアタッチしたオブジェクト(=TextMeshPro)の位置を上中央(Top)に変更
            // //参考 https://docs.unity3d.com/Packages/com.unity.textmeshpro@1.3/api/TMPro.TextAlignmentOptions.html
            // gameOverText.alignment=TMPro.TextAlignmentOptions.Center;
            

            //☆TextMeshProのプロパティを操作するコード一覧(一部) https://qiita.com/hinagawa/items/b606c6a2fd56d559a375 ☆
        }
    }

    //床(plane)だけでなく地面に落ちる=planeより下にジェンガが飛んでいく場合もGameoverになる
    private void Flyawayjenga(){
        //※処理はOnCollisionEnterに同じ
        GameObject[] blocks = GameObject.FindGameObjectsWithTag ("jenga");//"jenga"のタグを持つオブジェクト一覧
        foreach(var b in blocks){
            //Debug.Log(b.name);
            NearInteractionGrabbable othermovemanage=b.GetComponent<NearInteractionGrabbable>();
            othermovemanage.enabled=false;
            ObjectManipulator othermanage=b.GetComponent<ObjectManipulator>();
            othermanage.enabled=false;
        }
        //SceneManager.LoadScene("fail");//Scene「fail」に飛ぶ　飛ばない場合はコメントアウト

        // TextMeshProUGUI gameOverText = GameObject.Find("gameover").GetComponent<TextMeshProUGUI>();
        // //ゲームオーバーの文字表示(ほぼ確認用、一応そのまま使えはする)
        // gameOverText.text="GameOver";
        // //このスクリプトから生成したコンポーネントにアタッチしたオブジェクト(=TextMeshPro)の「text」を「GameOver」に変更(アタッチしているのでGetComponentは不要)
        // gameOverText.color=new Color32(0,0,0,255);
        // //このスクリプトから生成したコンポーネントにアタッチしたオブジェクト(=TextMeshPro)の色(文字色 RGBA)を変更(アタッチしているのでGetComponentは不要)            
        // gameOverText.fontSize=100;//float型になる
        // //文字装飾(あらかじめShaderの「outline」をONにしておく)
        // gameOverText.outlineColor=new Color32(255,255,255,255);
        // gameOverText.outlineWidth=0.15f;
        // gameOverText.UpdateFontAsset();//更新
        // gameOverText.fontStyle=TMPro.FontStyles.Italic;//イタリック体(斜字)に(https://docs.unity3d.com/Packages/com.unity.textmeshpro@1.3/api/TMPro.FontStyles.html)           
        // //このスクリプトから生成したコンポーネントにアタッチしたオブジェクト(=TextMeshPro)の位置を上中央(Top)に変更
        // //参考 https://docs.unity3d.com/Packages/com.unity.textmeshpro@1.3/api/TMPro.TextAlignmentOptions.html
        // gameOverText.alignment=TMPro.TextAlignmentOptions.Center;
            

        //☆TextMeshProのプロパティを操作するコード一覧(一部) https://qiita.com/hinagawa/items/b606c6a2fd56d559a375 ☆
    }

}
