using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugManager;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private string scenetoLoad;
    [SerializeField] private string sceneTransitionName;

    private float waitToLoadTime = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            SceneManagement.Instance.SetTransitionName(sceneTransitionName);
            StartCoroutine(LoadSceneRoutine());
        }
    }

    private IEnumerator LoadSceneRoutine()
    {
        while (waitToLoadTime >= 0)
        {
            waitToLoadTime -= Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(scenetoLoad);
    }
}
