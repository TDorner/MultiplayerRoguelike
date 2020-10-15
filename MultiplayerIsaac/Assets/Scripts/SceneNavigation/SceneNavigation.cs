using UnityEngine.SceneManagement;
using UnityEngine;

namespace Navigation
{
    public class SceneNavigation : MonoBehaviour
    {
        public void LoadScene(string _scene)
        {
            SceneManager.LoadScene(_scene, LoadSceneMode.Single);
            Debug.Log("Loading Scene: " + _scene);
        }
    }
}
