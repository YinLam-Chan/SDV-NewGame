using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PasswordRegController : MonoBehaviour
{
    public GameObject RegisterPanel;
    public GameObject PasswordPanel;
    public InputField Username;
    public InputField Password;

    private void HidePanels()
    {
        RegisterPanel.SetActive(false);
        PasswordPanel.SetActive(false);
    }

    private void ShowRegisterPanel()
    {
        RegisterPanel.SetActive(true);
        PasswordPanel.SetActive(false);
    }

    private void ShowPasswordPanel()
    {
        RegisterPanel.SetActive(false);
        PasswordPanel.SetActive(true);
    }

    public void Cancel()
    {
        HidePanels();
    }

    public void OK()
    {
        HidePanels();
    }

    public void CheckPassword()
    {
        HidePanels();
        switch (GameModel.CheckPassword(Username.text, Password.text))
        {
            case GameModel.PasswdMode.OK:
                HidePanels();
                SceneManager.LoadScene("GamePlay");
                break;
            case GameModel.PasswdMode.NeedUsername:
                ShowRegisterPanel();
                break;
            case GameModel.PasswdMode.NeedPassword:
                ShowPasswordPanel();
                break;
        }
    }

    public void RegisterPlayer()
    {
        GameModel.RegisterPlayer(Username.text, Password.text);
        HidePanels();
        SceneManager.LoadScene("GamePlay");
    }

    // Start is called before the first frame update
    void Start()
    {
        RegisterPanel.SetActive(false);
        PasswordPanel.SetActive(false);
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
