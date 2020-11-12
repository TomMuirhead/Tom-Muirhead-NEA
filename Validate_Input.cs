using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Validate_Input : MonoBehaviour
{
    InputField inputField;
    Color invalidColor;
    Text input;
    Image image;
    public float inputSize;

    public void OnValueChanged()
    {
        inputField = GetComponent<InputField>();
        invalidColor = new Color(1f, 0f, 0f, 0.5f);
        input = GetComponent<Text>();
        image = GetComponent<Image>();

        while (input != null)
        {
            bool valid = false;
            while (valid == false)
            {
                image.color = invalidColor;
            }
        }
    }
}
