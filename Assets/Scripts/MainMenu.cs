using TMPro;
using UnityEngine;


namespace AlexzanderCowell
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private TMP_InputField username;
        [SerializeField] private TMP_InputField password;
        [SerializeField] private DataManager dataManager;
        private AudioSource menuMusic;
        public float delayInSeconds = 0.5f;

        private void Start()
        {
            dataManager.LoadUserData();

            menuMusic = GetComponent<AudioSource>();
            Invoke("PlayMusic", delayInSeconds);
        }

        public void OnLoginButtonClicked()
        {
            string usernameText = this.username.text;
            string passwordText = this.password.text;
            UserData userData = CreateNewUserData(usernameText, passwordText);
            dataManager.AddUserData(userData);
            dataManager.SaveUserData();
            this.username.text = "";
            this.password.text = "";
        }

        private UserData CreateNewUserData(string usernameText, string passwordText)
        {
            UserData userData = ScriptableObject.CreateInstance<UserData>();
            userData.username = usernameText;
            userData.password = passwordText;
            return userData;
        }

        private void PlayMusic()
        {
            menuMusic.Play();
        }
    }
}
