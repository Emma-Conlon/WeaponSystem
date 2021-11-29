using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class NewTestScript
{
    private BulletControl game;
    // A Test behaves as an ordinary method
    [SetUp]
    public void Setup()
    {
        //GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("prefabs/BulletControl"));
        //game = gameGameObject.GetComponent<BulletControl>();
        SceneManager.LoadScene("BulletScene",LoadSceneMode.Single);
    }

    [TearDown]
    public void Teardown()
    {
       // Object.Destroy(game.gameObject);
        SceneManager.UnloadSceneAsync("BulletScene");
    }

    [UnityTest]
    ///checks to see if bullets changed direction
    public IEnumerator BulletsMoveLeft()
    {
        GameObject bl = GameObject.Find("Bullet");
        //bl.GetComponent<BulletControl>().fire();    
           float initialXPos = bl.transform.position.x;
            yield return new WaitForSeconds(0.1f);
            Assert.Greater(-bl.transform.position.x, initialXPos);
        

    }

    [UnityTest]
    public IEnumerator BulletsMoveRight()
    {
        GameObject br = GameObject.Find("Bullet");
        //bl.GetComponent<BulletControl>().fire();    
        float initialXPos = br.transform.position.x;
        yield return new WaitForSeconds(0.1f);
        Assert.Greater(br.transform.position.x, initialXPos);
    }

}
