using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.UI;
using Text = UnityEngine.UI.Text;

public class GameManager : MonoBehaviour
{

    
    [SerializeField] Player player;
    [SerializeField] GameObject sky;
    [SerializeField] GameObject playerActive;
    //[SerializeField] Text coinB;
    //[SerializeField] Text time;

    float runningTime;


    private void Update()
    {
        runningTime += Time.deltaTime;
    }
    public void NewGame()
    {

       //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("SampleScene");
    }

    public void GameOverScreen()
    
    {
        //coin.text="Total coins"+player.coinCounter; o //coin.text=player.coinCounter.ToString();
        var time = GameObject.Find("GameManager").GetComponent<GameManager>().runningTime;
        var coin= GameObject.Find("GameManager").GetComponent<GameManager>().player.coinCounter;

        var platformCreator = GameObject. Find("PlatformCreator").GetComponent<PlatformCreator>().isPaused = true;
        var gameOverScreen=Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(e => e.name == "GameOverScreen");
        var audios = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(e => e.name == "Audios");
        

        //gameOverScreen.transform.Find("RunningTime").GetComponent<Text>().text += $" {time.ToString("0")}"; 
        //gameOverScreen.transform.Find("CoinCounter").GetComponent<Text>().text += $" {coin.ToString("0")}";
        gameOverScreen.transform.Find("RunningTime").GetComponent<Text>().text = ""+ Mathf.Ceil (time);
        gameOverScreen.transform.Find("CoinCounter").GetComponent<Text>().text = coin.ToString();
        //coinB.text = player.coinCounter.ToString();


        audios.SetActive(false);
        sky.SetActive(false);
        playerActive.SetActive(false);
        gameOverScreen.SetActive(true);
        Destroy(player);

        //var activeList=Resources.FindObjectsOfTypeAll<GameObject>().ToList().
        //Where(go => go.activeInHierarchy == true).Where(e => e.name == "").FirstOrDefault();

    }
}
