using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Validate_Input : MonoBehaviour
{
    InputField inputField;
    Color invalidColor, normalColor;
    Text input;
    Image image;
    public float inputSize;

    void Start()
    {
        inputField = GetComponent<InputField>();
        invalidColor = new Color(1f, 0f, 0f, 0.5f);
        normalColor = new Color(0.9607843f, 0.7843137f, 0f, 0.5882353f);
        input = GetComponent<Text>();
        image = GetComponent<Image>();
    }

    void Update()
    {
        image.color = normalColor;
        if (inputField.text != "")
        {
            int InputNum;
            bool validNum = Int32.TryParse(inputField.text, out InputNum);
            if (!validNum)
            {
                image.color = invalidColor;
            }
            else if (InputNum < 1 || InputNum > 999)
            {
                image.color = invalidColor;
            }
        }
        
    }
}
