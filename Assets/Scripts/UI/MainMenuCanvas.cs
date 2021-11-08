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
        [SerializeField] private GameObject levelSelectPanel;
        [SerializeField] private Text levelName;

        private static MainMenuCanvas _instance;
        public static MainMenuCanvas Instance => _instance;

        void Awake()
        {
            if (_instance == null) _instance = this;

            inputUsername.onValueChanged.AddListener(OnUsernameInputChanged);
            inputUsername.text = GameDatabase.Instance.CurrentUser.Username;
            if(inputUsername.text=="")
                btnPlay.interactable = false;
            else
                btnPlay.interactable = true;
        }

        public void SelectLevel(string level)
        {
            GameDatabase.Instance.setLevelName(level);
            levelSelectPanel.SetActive(false);
            levelName.text = GameDatabase.Instance.getLevelName();
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
                string levelName = GameDatabase.Instance.getLevelName();
                if(levelName==null)
                {
                    SceneManager.LoadScene("Assets/Scenes/LevelScene.unity", LoadSceneMode.Single);
                }else
                {
                    SceneManager.LoadScene(levelName);
                }
               
            
                
            }
    
            else
            {
                againText.SetActive(true);
            }
        }

        public void BtnLevelSelectClicked()
        {
            levelSelectPanel.SetActive(true);
        }

        #endregion Event Handlers
    }
}