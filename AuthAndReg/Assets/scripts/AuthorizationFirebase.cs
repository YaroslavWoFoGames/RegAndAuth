using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Firebase;

public class AuthorizationFirebase : MonoBehaviour
{
    [SerializeField] private InputField inputFieldEmail, inputFieldPassword;
    [SerializeField] private ErrorManager errorManager;
    [SerializeField] private UIManager uiManager;


    private void Start()
    {
        if(PlayerPrefs.HasKey("email") && PlayerPrefs.HasKey("password"))
        {
            inputFieldEmail.text = PlayerPrefs.GetString("email");
            inputFieldPassword.text = PlayerPrefs.GetString("password");
            Invoke("LoginButton",1f);
        }
    
    }

    public void LoginButton()
    {
        StartCoroutine(SignIn(inputFieldEmail.text, inputFieldPassword.text));
    }
   private IEnumerator SignIn(string email, string password)
    {
        var loginTask = ConnectionFirebase.AuthorizationPlayer.SignInWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(predicate: () => loginTask.IsCompleted);

        if (loginTask.Exception != null)
        {
            errorManager.WhatErrorOut(loginTask.Exception.GetBaseException() as FirebaseException);
        }
        else
        {
            PlayerPrefs.SetString("email", email);
            PlayerPrefs.SetString("password", password);
            ConnectionFirebase.User = loginTask.Result;
            uiManager.ChangeWindows((int)WindowsApp.Menu);
            errorManager.UpdateTextError("");
        }
    }
}
