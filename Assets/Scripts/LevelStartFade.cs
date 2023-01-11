using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStartFade : MonoBehaviour
{

    private Image image;
    private Text text;

    public float fadeSpeed = 5;

    void Start()
    {
        image = GetComponent<Image>();
        text = GameObject.Find("Level Name").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        var tempColor = image.color;
        tempColor.a -= fadeSpeed * Time.deltaTime;
        
        var tempColorText = text.color;
        tempColorText.a -= fadeSpeed * Time.deltaTime;

        image.color = tempColor;
        text.color = tempColorText;

        if (image.color.a <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
