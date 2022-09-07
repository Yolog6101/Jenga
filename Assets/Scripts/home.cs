using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class home : MonoBehaviour
{
    Interactable thisButton;

    // Start is called before the first frame update

    void Start () {
        // this.GetComponent<Button>().onClick.AddListener(OnClick);
        thisButton = this.GetComponent<Interactable>();
        thisButton.OnClick.AddListener(OnClick);        
    }

    void OnClick()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene("start");
    }
    void Update () {

    }
}