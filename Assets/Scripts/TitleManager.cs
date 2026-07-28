using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
   public Animator animator;
   
   void Start()
   {
      var currentScene = SceneManager.GetActiveScene();
      if (currentScene.buildIndex == 2)
      {
         animator.SetBool("Win", true);
      }

      if (currentScene.buildIndex == 3)
      {
         animator.SetBool("Lose", true);
      }
   }
   
   public void OnTitleClicked()
   {
      SceneManager.LoadScene(sceneBuildIndex: 0);
   }
   
   public void OnPlayClicked()
   {
      SceneManager.LoadScene(sceneBuildIndex: 1);
   }

   public void OnQuitClicked()
   {
      Application.Quit();
      Debug.Log("Quit");
   }
}
