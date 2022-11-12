using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject startPlatform, endPlatform, platform;
    [SerializeField]
    int AmountToSpawn = 100, BeginWith = 0;
    float bwd = 0.5f, bht = 0.2f;
    Vector3 lastpos;
    [SerializeField]
    GameObject playerPrefab;
    void Awake()
    {
        InstantiateLevel();
    }

    void InstantiateLevel()
    {
        for(int i=BeginWith; i<AmountToSpawn; i++)
        {
            GameObject newPlatform;
            if (i == 0)
            {
                newPlatform = Instantiate(startPlatform);
                GameObject pfstart = GameObject.Find("pf1 start(Clone)");
                Instantiate(playerPrefab, pfstart.transform);
            }
            else if (i == AmountToSpawn - 1)
            {
                newPlatform = Instantiate(endPlatform);
                newPlatform.tag = "Endpf";
            }
            else
            {
                newPlatform = Instantiate(platform);
            }

            /*if(i == 0)
            {
                // instantiate player at start pf
                lastpos = newPlatform.transform.position;
                Vector3 temp = lastpos;
                temp.y += 0.4f;
                Instantiate(playerPrefab, temp, Quaternion.identity);
            }*/

            // set LevelGenerator GO as the parent of new pfs
            newPlatform.transform.parent = transform;

            // set positioning of diff pfs
            int left = Random.Range(0, 2);
            if(left == 0)
            {
                newPlatform.transform.position = new Vector3(lastpos.x - bwd, lastpos.y + bht, lastpos.z);
            }
            else
            {
                newPlatform.transform.position = new Vector3(lastpos.x, lastpos.y + bht, lastpos.z + bwd);
            }

            // fancy animations
            lastpos = newPlatform.transform.position;
            if(i < 25)
            {
                Vector3 pos = newPlatform.transform.position;
                newPlatform.transform.position = new Vector3(pos.x, pos.y - bht * 3f, pos.z);
                newPlatform.transform.DOLocalMoveY(pos.y, 0.3f).SetDelay(i * 0.1f);
            }
        }
    }
}
