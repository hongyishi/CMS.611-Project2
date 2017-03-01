using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMonsterRespawnScript : MonoBehaviour {

    public Vector3 respawnPosition;

    public GameObject Monster;
	// Use this for initialization
	void Start () {
        StartCoroutine(respawn());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator respawn()
    {
        yield return new WaitForSeconds(1.0f);
        GameObject newMonster = Instantiate(Monster, respawnPosition, Quaternion.identity) as GameObject;
        Destroy(this.gameObject);
    }
}
