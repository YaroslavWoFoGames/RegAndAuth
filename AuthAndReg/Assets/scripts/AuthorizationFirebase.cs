using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase;

public class AuthorizationFirebase : MonoBehaviour
{
    [SerializeField] private InputField inputFieldEmail, inputFieldPassword;
    [SerializeField] private ErrorManager errorManager;
    [SerializeField] private UIManager uiManager;

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
            ConnectionFirebase.User = loginTask.Result;
            uiManager.ChangeWindows((int)WindowsApp.Menu);
            errorManager.UpdateTextError("");
        }
    }
}
