using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomScript2 : MonoBehaviour {
    [SerializeField] private TMP_InputField inputField1;
    [SerializeField] private TMP_InputField inputField2;
    [SerializeField] private TMP_Text outputText;

    public void OnButton(){
    int userEnterValue1 = ReadIntFromInputField(inputField1);
    int userEnterValue2 = ReadIntFromInputField(inputField2);
    if (userEnterValue1 == userEnterValue2) {
        outputText.text = "оба";
    } else if (userEnterValue1 > userEnterValue2){
        outputText.text = userEnterValue1. ToString();
    }
    if (userEnterValue1 < userEnterValue2) {
        outputText.text = userEnterValue2.ToString();

    }
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
 