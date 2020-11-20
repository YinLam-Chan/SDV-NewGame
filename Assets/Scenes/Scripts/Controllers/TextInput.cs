using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextInput : MonoBehaviour
{
    InputField input;
    InputField.SubmitEvent se;
    InputField.OnChangeEvent ce;
    public Text output;
    private string Username = "";

    // Start is called before the first frame update
    void Start()
    {
        Username = GameModel.currentPlayer != null ? "Hello " + GameModel.currentPlayer.Username + ".\n" : "";
        output.text = Username + GameModel.currentLocation.LocationName + "\n" + GameModel.currentLocation.Story;

        input = this.GetComponent<InputField>();
        se = new InputField.SubmitEvent();
       se.AddListener(SubmitInput);
       input.onEndEdit = se;
        GameModel.getPlayers();
    }

    public void SubmitInput(string arg0)
    {
        string currentText = output.text;

        CommandProcessor aCmd = new CommandProcessor();
        output.text = Username + aCmd.Parse(input.text);

        input.text = "";
        input.ActivateInputField();
        GameModel.StorePlayer();
    }

    public void ChangeInput(string arg0)
    {
        Debug.Log(arg0);
    }
}
