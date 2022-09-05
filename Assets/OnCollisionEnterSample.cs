using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//ある名前空間を持つスクリプトのコンポーネントを使うにはこれ(using そのスクリプトに書かれている名前空間)が必要になる 参考:https://kamikoppu.info/unityengine-consideration/ 参考2:https://creive.me/archives/16164/
using Microsoft.MixedReality.Toolkit.Input;//NearInteractionGrabbableのある名前空間
using Microsoft.MixedReality.Toolkit.UI;//ObjectManipulatorのある名前空間

public class OnCollisionEnterSample : MonoBehaviour
{
    //private TMPro.TMP_Text gameover;
    public TextMeshProUGUI gameOverText = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //衝突したオブジェクトがPlaneだった場合
        if(collision.gameObject.name=="Plane"){
            //色を黒に変化させる(https://xr-hub.com/archives/3993)
            GetComponent<Renderer>().material.color = Color.black;
            
            
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
            
            //ゲームオーバーの文字表示
            gameOverText.text="GameOver";
            
        }
    }
}
