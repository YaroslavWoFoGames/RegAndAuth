using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
   [SerializeField] private Text _nick;
   [SerializeField] private Image _photo;
   [SerializeField] private Account _account;
    
    private void OnEnable()
    {
        LoadProfile();
        //_account.UpdateDataAccount("Yar", 22 , ConnectionFirebase.User.UserId);
    }
    private void LoadProfile()
    {
        _nick.text = ConnectionFirebase.User.DisplayName;
        StartCoroutine(PlayerImage(ConnectionFirebase.User.PhotoUrl.ToString()));
    }
    private IEnumerator PlayerImage(string url)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
        {
            yield return uwr.SendWebRequest();
            _photo.sprite = Sprite.Create(DownloadHandlerTexture.GetContent(uwr), new Rect(0f, 0f, DownloadHandlerTexture.GetContent(uwr).width, DownloadHandlerTexture.GetContent(uwr).height), new Vector2(0f, 0f));
        }
    }



}

