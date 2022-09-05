using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
            gameOverText.text="GameOver";
            
            
        }
    }
}
