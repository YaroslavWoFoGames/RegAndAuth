using UnityEngine;
using Firebase.Auth;
using Firebase;
using Firebase.Database;

public class ConnectionFirebase : MonoBehaviour
{
    public static FirebaseAuth AuthorizationPlayer;
    public static DatabaseReference reference;
    public static FirebaseUser User;
    [SerializeField] private ErrorManager errorManager;
    private void Awake()
    {
        //FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        //{
        //    DependencyStatus dependencyStatus = task.Result;
        //    if (dependencyStatus == DependencyStatus.Available)
        //    {
                reference = FirebaseDatabase.DefaultInstance.RootReference;
                AuthorizationPlayer = FirebaseAuth.DefaultInstance;
        //    }
        //    else
        //    {
        //        errorManager.UpdateTextError("Не удалось разрешить все зависимости Firebase: " + dependencyStatus.ToString() + "! Попробуйте зайти позже!");
        //    }
        //});
    }
   

}
