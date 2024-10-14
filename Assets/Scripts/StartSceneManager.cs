using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    public InputField nameInput;
    public Button joinButton;
    public Text errorText;

    void Start()
    {
        joinButton.onClick.AddListener(JoinGame);
        nameInput.onValueChanged.AddListener(ValidateInput);
        errorText.gameObject.SetActive(false);
    }

    void ValidateInput(string input)
    {
        joinButton.interactable = input.Length >= 2 && input.Length <= 10;
    }

    void JoinGame()
    {
        if (nameInput.text.Length >= 2 && nameInput.text.Length <= 10)
        {
            PlayerPrefs.SetString("PlayerName", nameInput.text);
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            errorText.text = "이름은 2~10글자 사이여야 합니다.";
            errorText.gameObject.SetActive(true);
        }
    }
}