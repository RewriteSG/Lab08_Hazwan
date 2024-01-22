using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Calculator : MonoBehaviour
{
    public ConvertTo convertTo;
    public float Input;
    public TMP_InputField inputField;
    public TextMeshProUGUI resultField;
    public TextMeshProUGUI DebuggingText;
    float USDConversionRate = 0.75f;
    float JPYConversionRate = 110.27f;
    public void SGDInput(string sgd)
    {

        try
        {
            Input = float.Parse(sgd);
        }
        catch (System.FormatException)
        {
            if(sgd.Length>0)
            sgd = sgd.Remove(sgd.Length - 1);
            inputField.text = sgd;
            StartCoroutine(hehe());
        }
    }
    IEnumerator hehe()
    {
        DebuggingText.text = "PLEASE ENTER VALID AMOUNT";
        DebuggingText.color = Color.red;
        DebuggingText.fontSize = 46.6f;
        yield return new WaitForSeconds(2);
        DebuggingText.text = "Debugging Text";
        DebuggingText.color = Color.white;
        DebuggingText.fontSize = 16.6f;
    }
    public void ToggleSelected(Yoggle toggle)
    {
        convertTo = toggle.toConvert;
        if (toggle.Toggled())
            convertTo = ConvertTo.None;
    }
    public void CalculateMoney()
    {
        switch (convertTo)
        {
            case ConvertTo.USD:
                resultField.text = "$"+System.Math.Round(Input * USDConversionRate,2).ToString();
                break;
            case ConvertTo.JPY:
                resultField.text = System.Math.Round(Input * JPYConversionRate, 2).ToString() + " Yen";
                break;
        }
    }
    
    public void Clear()
    {
        FindObjectOfType<Toggle>().isOn = true;
        FindObjectOfType<Yoggle>().Toggled();
        resultField.text = "";
        inputField.text = "";
    }
}
[System.Serializable]
public enum ConvertTo
{
    USD, JPY, None
}
