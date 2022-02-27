using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase;
using UnityEngine.Networking;
public class Menu : MonoBehaviour
{
   [SerializeField] private Text nick;
   [SerializeField] private Image photo;

    private void OnEnable()
    {
        LoadProfile();
    }
    private void LoadProfile()
    {
        nick.text = ConnectionFirebase.User.DisplayName;
        StartCoroutine(PlayerImage(ConnectionFirebase.User.PhotoUrl.ToString()));
    }
    private IEnumerator PlayerImage(string url)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
        {
            yield return uwr.SendWebRequest();
            photo.sprite = Sprite.Create(DownloadHandlerTexture.GetContent(uwr), new Rect(0f, 0f, DownloadHandlerTexture.GetContent(uwr).width, DownloadHandlerTexture.GetContent(uwr).height), new Vector2(0f, 0f));
        }
    }
}
