using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;

public class Reset : MonoBehaviour
{

    Interactable thisButton;
    public GameObject[] gameObjects_2;
    Vector3[] positions;
    Quaternion[] rotations;
    Vector3[] scales;

    // Start is called before the first frame update
    void Start()
    {
        //tagが"jenga"のオブジェクトをすべて取得
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("jenga"); 

        //gameObjects_2にgameObjectsを代入
        gameObjects_2 = gameObjects;

        thisButton = this.GetComponent<Interactable>();
        thisButton.OnClick.AddListener(onClick);

        positions = new Vector3[gameObjects.Length];
        rotations = new Quaternion[gameObjects.Length];
        scales = new Vector3[gameObjects.Length];
        for (int i = 0; i < gameObjects.Length; i++)
        {
            positions[i] = gameObjects[i].transform.position;
            rotations[i] = gameObjects[i].transform.rotation;
            scales[i] = gameObjects[i].transform.localScale;
        }

    }

    void onClick()
    {
        Debug.Log("Clicked");
        for (int i = 0; i < gameObjects_2.Length; i++)
        {
            // gameObjects[i].transform.position = positions[i];
            // gameObjects[i].transform.rotation = rotations[i];
            // gameObjects[i].transform.localScale = scales[i];

            // gameObjects[i].GetComponent<NearInteractionGrabbable>().enabled = true;
            // gameObjects[i].GetComponent<NearInteractionTouchable>().enabled = true;
            // gameObjects[i].GetComponent<ObjectManipulator>().enabled = true;

            //gameObject_2も同じようにする
            gameObjects_2[i].transform.position = positions[i];
            gameObjects_2[i].transform.rotation = rotations[i];
            gameObjects_2[i].transform.localScale = scales[i];

            gameObjects_2[i].GetComponent<NearInteractionGrabbable>().enabled = true;
            gameObjects_2[i].GetComponent<NearInteractionTouchable>().enabled = true;
            gameObjects_2[i].GetComponent<ObjectManipulator>().enabled = true;


        }

    }

}
