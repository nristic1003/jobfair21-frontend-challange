using Platformer.BlurredScreenshot;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.UI
{
    public class PauseMenu : MonoBehaviour
    {

        [SerializeField] private BlurredBackground blurredBackground;

        public void Show()
        {
            blurredBackground.Show();
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            blurredBackground.Hide();
            gameObject.SetActive(false);
        }

        #region Event Handlers

        public void BtnResumeClicked()
        {
            Hide();
        }

        public void BtnMainMenuClicked()
        {
            SceneManager.LoadScene("Assets/Scenes/MainScene.unity", LoadSceneMode.Single);
        }

        public void BtnRestartClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        #endregion Event Handlers
    }
}