using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneManager : MonoBehaviour
{
    TextMeshProUGUI sceneText;
    // Start is called before the first frame update

    void Start()
    {
        sceneText = GameObject.Find("sceneText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchScenes()
    {

    }
}
