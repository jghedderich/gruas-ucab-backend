using FirebaseAdmin;

namespace Providers.Application.Settings;

public interface IFirebaseAppClient
{
    void CreateFirebaseApp();
}

public class FirebaseAppClient : IFirebaseAppClient
{
    public void CreateFirebaseApp()
    {
        if (FirebaseApp.DefaultInstance == null)
        {
            FirebaseApp.Create();
        }
    }
}
