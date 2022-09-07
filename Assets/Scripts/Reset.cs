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
    public GameObject[] gameObjects;
    Vector3[] positions;
    Quaternion[] rotations;
    Vector3[] scales;

    // Start is called before the first frame update
    void Start()
    {
        //tagが"jenga"のオブジェクトをすべて取得
        gameObjects = GameObject.FindGameObjectsWithTag("jenga"); 

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
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].transform.position = positions[i];
            gameObjects[i].transform.rotation = rotations[i];
            gameObjects[i].transform.localScale = scales[i];
            gameObjects[i].GetComponent<NearInteractionGrabbable> ().enabled = true;
            gameObjects[i].GetComponent<NearInteractionTouchable>().enabled = true;
            gameObjects[i].GetComponent<ObjectManipulator>().enabled = true;
        }
        TextMeshProUGUI gameOverText = GameObject.Find("gameover").GetComponent<TextMeshProUGUI>();
        gameOverText.text="";

    }
}
