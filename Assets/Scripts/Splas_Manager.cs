using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splas_Manager : MonoBehaviour
{
    private int SceneNumber;
    // Start is called before the first frame update
    void Start()
    {
        SceneNumber = SceneManager.GetActiveScene().buildIndex;
        if (SceneNumber == 0) {
            StartCoroutine (ToMenu());//0'dan 1'e
        }
        if (SceneNumber == 2){
            StartCoroutine (ToOther()); //2'den 3'e
        }
        if (SceneNumber == 5 || 4 == SceneNumber){
            StartCoroutine (ToLevel());// 5 veya 4'den 6'ya
        }
        if (SceneNumber == 8 || 7 == SceneNumber || 9 == SceneNumber || 10 == SceneNumber){
            StartCoroutine (ToEnd());// 8 veya 7 veya 9'dan 6'ya
        }
        if(SceneNumber == 12){
            StartCoroutine(introToIntro());
        }
        if(SceneNumber == 11){
            StartCoroutine(ToFinish());
        }
        
    }
    IEnumerator introToIntro(){
        yield return new WaitForSeconds(22);
        SceneManager.LoadScene(2); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    //IEnumerator WaitThenGo(){
    //    yield return new WaitForSeconds(waitForXSeconds);
   //     SceneManager.LoadScene(SceneNumber+1);
   // }



    IEnumerator ToMenu(){
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }

    IEnumerator ToOther(){
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(3);
    }

     IEnumerator ToLevel(){
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(6);
    }
    
    IEnumerator ToEnd(){
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(11);
    }

    IEnumerator ToFinish(){
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
