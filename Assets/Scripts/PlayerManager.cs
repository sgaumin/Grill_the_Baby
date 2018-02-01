using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public GameObject bullet;
	public float timeReload;
	public int lifePoints;

	private bool _canShoot = true;

	// Use this for initialization
	void Start () {
		StartCoroutine (CheckShooting());
	}
	
	// Update is called once per frame
	void Update () {
		if (_canShoot) {
			if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetButton("Jump")) {
				Instantiate (bullet, gameObject.transform.position, gameObject.transform.rotation);
				_canShoot = false;
			}
		}
	}

	IEnumerator CheckShooting(){
		while (true) {
			if (!_canShoot) {
				yield return new WaitForSeconds (timeReload);
				_canShoot = true;
			} else {
				yield return null;
			}
		}
	}

	IEnumerator End(){
		while (true) {
			AudioManager.instance.PlayLoseSound ();
			GUIManager.instance.ShowLoseGame ();
			yield return new WaitForSeconds (5f);
			GameManager.instance.LoadScene ("Menu");
			yield break;
		}
	}

	public void AddDamage(int value){
		lifePoints -= value;
		GUIManager.instance.ChangeLife (lifePoints);

		if (lifePoints == 0) {
			StartCoroutine (End ());
			//SpawnManager.instance.EndSpawning ();
		}
	}
}
