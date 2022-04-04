using Firebase.Database;
using System.Collections;
using UnityEngine;

public class Account : MonoBehaviour
{
    private string _name ;
    private string _id;
    private int _age;
    public int Score { get; set; }

    private void Start()
    {
        //StartCoroutine(GetScoreFromFirebase("1235"));
    }

    public void UpdateDataAccount(string name, int age, string id)
    {
        _name = name;
        _age = age;
        _id = id;
        StartCoroutine(UpdateName(_name, id));
        StartCoroutine(UpdateAge(_age, id));
        StartCoroutine(UpdateScore(Score, id));
    }
    private void CreateProfileDB(string name, int age, int score, string id)
    {
        StartCoroutine(UpdateName(name,id));
        StartCoroutine(UpdateAge(age, id));
        StartCoroutine(UpdateScore(score, id));
    }

    private IEnumerator UpdateName(string name , string id)
    {
        var loginTask = ConnectionFirebase.reference.Child(id).Child("name").SetValueAsync(name);
        yield return new WaitUntil(predicate: () => loginTask.IsCompleted);
    }
    private IEnumerator UpdateAge(int age, string id)
    {
        var loginTask = ConnectionFirebase.reference.Child(id).Child("age").SetValueAsync(age);
        yield return new WaitUntil(predicate: () => loginTask.IsCompleted);
    }
    private IEnumerator UpdateScore(int score, string id)
    {
        var loginTask = ConnectionFirebase.reference.Child(id).Child("score").SetValueAsync(score);
        yield return new WaitUntil(predicate: () => loginTask.IsCompleted);
    }
    //private IEnumerator GetScoreFromFirebase(string id)
    //{
    //    var loginTask = ConnectionFirebase.reference.GetValueAsync();
    //    yield return new WaitUntil(predicate: () => loginTask.IsCompleted);

    //    if(loginTask.Exception != null)
    //    {
    //        Debug.Log("Ошибка!");
    //    }
    //    else if (loginTask.Result.Value == null)
    //    {
    //        Debug.Log("no");
    //    }
    //    else
    //    {
    //        DataSnapshot dataSnapshot = loginTask.Result;
    //    }
    //}


}
