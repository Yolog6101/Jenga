using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createmap : MonoBehaviour
{
    //３段以上の任意の高さのジェンガを自動で作る
    public GameObject object1;//アタッチするのでここでは宣言のみ
    public GameObject object2;

    // Start is called before the first frame update
    void Start()
    {
        float count=1.0f;
        while(count<5){       
        Instantiate(object1, new Vector3( 0.0f, count, 3.0f), Quaternion.identity);
        Instantiate(object2, new Vector3( 0.0f, count+0.5f, 3.0f), Quaternion.identity);
            count+=1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
