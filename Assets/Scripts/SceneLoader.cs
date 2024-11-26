using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // 버튼을 눌렀을 때 호출되는 메서드
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);  // 씬 전환
    }
}
