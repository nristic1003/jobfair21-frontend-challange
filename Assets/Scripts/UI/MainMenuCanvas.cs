using Platformer.Model;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class MainMenuCanvas : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputUsername;
        [SerializeField] private Button btnPlay;
        [SerializeField] private GameObject againText;


        private static MainMenuCanvas _instance;
        public static MainMenuCanvas Instance => _instance;

        void Awake()
        {
            if (_instance == null) _instance = this;

            inputUsername.onValueChanged.AddListener(OnUsernameInputChanged);
            inputUsername.text = GameDatabase.Instance.CurrentUser.Username;
            btnPlay.interactable = false;
        }

        private void OnDestroy()
        {
            inputUsername.onValueChanged.RemoveListener(OnUsernameInputChanged);
        }

        #region Event Handlers

        private void OnUsernameInputChanged(string newName)
        {
            if(newName =="")
                btnPlay.interactable = false;
            else
            {
                btnPlay.interactable = true;
                GameDatabase.Instance.SetUsername(newName);
            }
           
           
        }

        public void BtnPlayClicked()
        {
            if(inputUsername.text!="")
            {
                SceneManager.LoadScene("Assets/Scenes/LevelScene.unity", LoadSceneMode.Single);
                Debug.Log(GameDatabase.Instance.CurrentUser.Username);
                
            }
    
            else
            {
                againText.SetActive(true);
            }
        }
        
        #endregion Event Handlers
    }
}