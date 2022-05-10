using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static string nextScene;
    [SerializeField] Image progressBar;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadScene()
    {
        progressBar.fillAmount = 0f;
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;
            timer += Time.deltaTime * 0.5f;
            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
                if (progressBar.fillAmount == 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}

//    protected static SceneLoader instance;
//    public static SceneLoader Instance
//    {
//        get
//        {
//            if (instance == null)
//            {
//                var obj = FindObjectOfType<SceneLoader>();
//                if (obj != null)
//                {
//                    instance = obj;
//                }
//                else
//                {
//                    instance = Create();
//                }
//            }
//            return instance;
//        }
//        private set
//        {
//            instance = value;
//        }
//    }
//    [SerializeField]
//    private CanvasGroup SceneLoaderCanvasGroup;
//    [SerializeField]
//    private Image progressBar;
//    private string LoadSceneName;
//    public static SceneLoader Create()
//    {
//        var SceneLoaderPrefab = Resources.Load<SceneLoader>("SceneLoader");
//        return Instantiate(SceneLoaderPrefab);
//    }
//    private void Awake()
//    {
//        if (Instance != this)
//        {
//            Destroy(gameObject);

//            return;
//        }
//        DontDestroyOnLoad(gameObject);
//    }
//    public void LoadScene(string sceneName)
//    {
//        gameObject.SetActive(true);
//        SceneManager.sceneLoaded += LoadSceneEnd;
//        LoadSceneName = sceneName;
//        StartCoroutine(Load(sceneName));
//    }

//    private IEnumerator Load(string sceneName)
//    {
//        progressBar.fillAmount = 0f;
//        yield return StartCoroutine(Fade(true));
//        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
//        op.allowSceneActivation = false;
//        float timer = 0.0f;
//        while(!op.isDone)
//        {
//            yield return null;
//            timer += Time.unscaledDeltaTime;
//            if (op.progress < 0.9f)
//            {
//                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount,
//                    op.progress, timer);
//                if (progressBar.fillAmount >= op.progress)
//                {
//                    timer = 0f;
//                }
//            }
//            else
//            {
//                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f,
//                    timer);
//                if(progressBar.fillAmount == 1f)
//                {
//                    op.allowSceneActivation = true;
//                    yield break;
//                }
//            }
//        }
//    }
//    private void LoadSceneEnd(Scene scene, LoadSceneMode loadSceneMode)
//    {
//        if(scene.name == LoadSceneName)
//        {
//            StartCoroutine(Fade(false));
//            SceneManager.sceneLoaded -= LoadSceneEnd;
//        }
//    }
//    private IEnumerator Fade(bool isFadeIn)
//    {
//        float timer = 0f;
//        while (timer <= 1f)
//        {
//            yield return null;
//            timer += Time.unscaledDeltaTime * 0.5f;/* *2f */;
//            SceneLoaderCanvasGroup.alpha = Mathf.Lerp(isFadeIn ? 0 : 1, isFadeIn ? 1 : 0, timer);
//        }
//        if(!isFadeIn)
//        {
//            gameObject.SetActive(false);
//        }
//    }
//}