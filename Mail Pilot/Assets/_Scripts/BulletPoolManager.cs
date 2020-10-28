using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    public GameObject bullet;
    public GameController gameController;
    public int maxBullets = 7;
    //TODO: create a structure to contain a collection of bullets
    private Queue<GameObject> BulletPool = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // TODO: add a series of bullets to the Bullet Pool
        BuildBulletPool();
    }

    void BuildBulletPool(){
        for (int i = 0; i < maxBullets; i++) {
            BulletPool.Enqueue(Instantiate(bullet));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet()
    {
        if (IsPoolEmpty()) {
            maxBullets += 1;
            BulletPool.Enqueue(Instantiate(bullet));
        }
        BulletPool.Peek().SetActive(true);
        return BulletPool.Dequeue();
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        BulletPool.Enqueue(bullet);
        BulletPool.Peek().SetActive(false);
    }

    public int GetPoolSize() {
        return BulletPool.Count;
    }
    public bool IsPoolEmpty() {
        if (GetPoolSize() == 0)
            return true;
        else
            return false;
    }
}
