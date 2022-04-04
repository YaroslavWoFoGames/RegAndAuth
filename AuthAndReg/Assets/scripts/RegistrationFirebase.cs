using Firebase.Auth;
using Firebase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RegistrationFirebase : MonoBehaviour
{
    [SerializeField] private InputField inputFieldName, inputFieldEmail, inputFieldPassword, inputFieldURLPhoto;
    [SerializeField] private ErrorManager errorManager;
    [SerializeField] private UIManager uiManager;

    public void RegisterButton()
    {
        StartCoroutine(RegisterPlayer(inputFieldName.text, inputFieldEmail.text, inputFieldPassword.text, inputFieldURLPhoto.text));
    }


    private IEnumerator RegisterPlayer(string name, string email, string password, string url)
    {
        var registerTask = ConnectionFirebase.AuthorizationPlayer.CreateUserWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(predicate: () => registerTask.IsCompleted);

        if (registerTask.Exception != null)
        {
            errorManager.WhatErrorOut(registerTask.Exception.GetBaseException() as FirebaseException);
        }
        else
        {
            ConnectionFirebase.User = registerTask.Result;

            if (ConnectionFirebase.User != null)
            {
                UserProfile profile = new UserProfile { DisplayName = name, PhotoUrl = new System.Uri(url) };

                var profileTask = ConnectionFirebase.User.UpdateUserProfileAsync(profile);
                yield return new WaitUntil(predicate: () => profileTask.IsCompleted);

                if (profileTask.Exception != null)
                {
                    errorManager.UpdateTextError("Ошибка создания профиля!");
                }
                else
                {
                    PlayerPrefs.SetString("email", email);
                    PlayerPrefs.SetString("password", password);
                    uiManager.ChangeWindows((int)WindowsApp.Menu);
                    errorManager.UpdateTextError("");
                }
            }
        }
    }
    

}
