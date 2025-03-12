using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class CalculatorScript : MonoBehaviour 
{
    [SerializeField] private TMP_InputField inputField1;
    [SerializeField] private TMP_InputField inputField2;
    [SerializeField] private TMP_Text outputText;
 
    public void OnButtonMinus() {
        int value1 = ReadIntFromInputField(inputField1);
        int value2 = ReadIntFromInputField(inputField2);
        outputText.text = (value1 - value2).ToString();
    }
    public void OnButtonPlus(){
        int value1 = ReadIntFromInputField(inputField1);
        int value2 = ReadIntFromInputField(inputField2);
        outputText.text = (value1 + value2).ToString();
    }
    public void OnButtonDiv(){
        int value1 = ReadIntFromInputField(inputField1);
        int value2 = ReadIntFromInputField(inputField2);
        outputText.text = (value1 / value2).ToString();
    }
    public void OnButtonMulti(){
        int value1 = ReadIntFromInputField(inputField1);
        int value2 = ReadIntFromInputField(inputField2);
        outputText.text = (value1 * value2).ToString();
    }
    private int ReadIntFromInputField(TMP_InputField inputField) {
        string str = inputField.text;
        if (str != null && str.Length > 0) {
            if (int.TryParse(str, out int intValue)) {
                return intValue;
            }
        }
        return 0;
    }
    
}