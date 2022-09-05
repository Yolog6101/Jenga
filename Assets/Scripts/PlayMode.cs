using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.UI;


public class PlayMode : MonoBehaviour
{
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //クリック時に掴めるようにする
    public void PlayGame()
    {
        cube.GetComponent<NearInteractionGrabbable>().enabled = true;
        cube.GetComponent<NearInteractionTouchable>().enabled = true;
        cube.GetComponent<ObjectManipulator>().enabled = true;
    }

}
