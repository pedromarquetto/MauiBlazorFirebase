using Firebase.Auth;
using Firebase.Auth.Providers;
using Newtonsoft.Json;
using MauiBlazorFirebase.Models;

namespace MauiBlazorFirebase.Services
{
    public class FirebaseService
    {
        private readonly FirebaseAuthClient _firebaseAuthClient;
        public FirebaseService()
        {
            _firebaseAuthClient = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyDLgCLR6384CPbsaRIXxWfRCEN0FsAQ6OQ",
                AuthDomain = "mauiblazorfirebase.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            });
        }
        public async Task<AppUserModel> Create(string email, string password,string displayName)
        {
            try
            {
                var response = await _firebaseAuthClient.CreateUserWithEmailAndPasswordAsync(email, password,displayName);

                AppUserModel appUser = new AppUserModel()
                {
                    Email = response.User.Info.Email,
                    DisplayName = response.User.Info.DisplayName,
                    Uid = response.User.Uid
                };

                SetPreferences(appUser);
                return appUser;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<AppUserModel> Login(string email, string password)
        {
            try
            {
                var response = await _firebaseAuthClient.SignInWithEmailAndPasswordAsync(email, password);

                AppUserModel appUser = new AppUserModel()
                {
                    Email = response.User.Info.Email,
                    DisplayName = response.User.Info.DisplayName,
                    Uid = response.User.Uid
                };

                SetPreferences(appUser);
                return appUser;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void SetPreferences(AppUserModel user)
        {
            Preferences.Set("auth_credential", JsonConvert.SerializeObject(user));
        }
        public async Task<AppUserModel> GetPreferences()
        {
            string json = Preferences.Get("auth_credential", string.Empty);
            return string.IsNullOrEmpty(json) ? default : JsonConvert.DeserializeObject<AppUserModel>(json);
        }
        public void Logout()
        {
            Preferences.Remove("auth_credential");
        }
    }
}
