using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // ��ư�� ������ �� ȣ��Ǵ� �޼���
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);  // �� ��ȯ
    }
}
