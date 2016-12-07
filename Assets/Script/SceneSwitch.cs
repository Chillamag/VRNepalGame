using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

    public GameObject SceneStart;
    public GameObject SceneMenu;
    public GameObject SceneGame;
    public bool isStart;
    public bool isMenu;
    public float fadeTime;
    public float fadeDelay;

    void Start(){
        isStart = true;
        isMenu = true;
        MovePlayer.isMenu = true;
        SceneStart.SetActive(true);
        SceneMenu.SetActive(false);
        SceneGame.SetActive(false);


        if (isStart)
        {
            SceneStart.SetActive(true);
        }
    }

    void Update(){


            //if (isMenu)
            //{
            //    SceneGame.SetActive(false);
            //    SceneMenu.SetActive(true);
            //    MovePlayer.isMenu = true;
            //}else
            //{
            //    SceneGame.SetActive(true);
            //    SceneMenu.SetActive(false);
            //    MovePlayer.isMenu = false;
            //}
        

    }

    public void ChangeScene()
    {
        //GameScene();
        //SceneManager.LoadScene("GameBoard", LoadSceneMode.Additive);
        //Application.LoadLevel("GameBoard");
        //isMenu = false;
        //MovePlayer.isMenu = false;

        //ShiftPoint();
        //SceneFading.BeginFade(-1);
        //SceneGame.SetActive(true);

        if (isStart)
        {
            StartCoroutine("FromStart");
        }
        else
        {
            StartCoroutine("ShiftPoint");
        }

        
    }

    public void BackToStart()
    {
        StartCoroutine("Back");
    }

    IEnumerator Back()
    {
        SceneFading.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        isStart = true;
        SceneStart.SetActive(true);
        SceneMenu.SetActive(false);
        yield return new WaitForSeconds(fadeTime + fadeDelay);
        SceneFading.BeginFade(-1);
    }

    //IEnumerator GameScene(){
    //    float fadeTime = GameObject.Find("GameManager").GetComponent<SceneFading>().BeginFade(1);
    //    yield return new WaitForSeconds(fadeTime);
    //    Application.LoadLevel("GameBoard");
    //    SceneManager.LoadScene("GameBoard", LoadSceneMode.Additive);

    //}

    IEnumerator FromStart()
    {
        SceneFading.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        isStart = false;
        SceneStart.SetActive(false);
        SceneMenu.SetActive(true);
        yield return new WaitForSeconds(fadeTime+fadeDelay);
        SceneFading.BeginFade(-1);
    }

    IEnumerator ShiftPoint()
    {
        SceneFading.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        isMenu = false;
        SceneGame.SetActive(true);
        SceneMenu.SetActive(false);
        MovePlayer.isMenu = false;
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        yield return new WaitForSeconds(fadeTime+fadeDelay);
        //SceneFading.OnLevelWasLoaded();
        SceneFading.BeginFade(-1);

    }


}
