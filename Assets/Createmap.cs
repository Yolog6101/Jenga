//Startmanageとの整合が取れないので現在は使用しない

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createmap : MonoBehaviour
{
    //３段以上の任意の高さのジェンガを自動で作る
    // Start is called before the first frame update
    void Start()
    {
      generate(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake(){
      
    }

    public void generate(int num)//指定段数のジェンガを作成できる関数　numは段数(>=3) object1,2は横並びジェンガ
    {
        GameObject object1=GameObject.Find("tate");
        GameObject object2=GameObject.Find("yoko");
        float x=0.0f;//☆状況に応じて変更！
        float z=3.0f;//☆状況に応じて変更！
        float count=1.0f;//while処理に使用        
        if (num%2==1){//段数が奇数(3,5,7...)
            while(count<(num/2)){//2段は用意済みなのであとどれだけ追加するか       
                Instantiate(object1, new Vector3( x, count, z), Quaternion.identity);
                Instantiate(object2, new Vector3( x, count+0.5f, z), Quaternion.identity);
                count+=1.0f;
            }
            Instantiate(object1, new Vector3( x, count, z), Quaternion.identity);//あまりの１段分
        }
        else{//段数が偶数(4,6,8...)
            while(count<(num/2)){//2段は用意済みなのであとどれだけ追加するか       
                Instantiate(object1, new Vector3( x, count, z), Quaternion.identity);
                Instantiate(object2, new Vector3( x, count+0.5f, z), Quaternion.identity);
                count+=1.0f;
            }
        }
          
    }
}
