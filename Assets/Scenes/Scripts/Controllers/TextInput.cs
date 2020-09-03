using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    
    InputField.SubmitEvent se;
    InputField.OnChangeEvent ce;
    public Text output;
    public InputField input;

    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log(output.text);
       output.text = GameModel.currentLocation.LocationName + "\n" + GameModel.currentLocation.Story;

        //input = this.GetComponent<InputField>();
        //se = new InputField.SubmitEvent();
        //se.AddListener(SubmitInput);
        //input.onEndEdit = se;
    }

    public void SubmitInput()
    {
        string currentText = output.text;

        CommandProcessor aCmd = new CommandProcessor();
        output.text = aCmd.Parse(input.text);

        input.text = "";
        //input.ActiveInputField();
    }

    public void ChangeInput(string arg0)
    {
        Debug.Log(arg0);
    }
}
