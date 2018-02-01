using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public static SpawnManager instance;

	public GameObject enemy;
	public GameObject spawPoint;
	public int[] nbEnemiesPerPhase;
	public float spawningDelay;

	private int _currentPhase;
	private int _currentNbKilled;
	private int _currentNbSpawned;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		StartPhase (0);
	}
		
	IEnumerator Spawn(int phaseNumber, float wait){
		while (true) {

			if (_currentNbSpawned < nbEnemiesPerPhase[phaseNumber]) {
				Vector2 _spawnPos = new Vector3 (spawPoint.transform.position.x + Random.Range (-7f, 7f), spawPoint.transform.position.y + Random.Range (-0.3f, 0.3f), 0f);
				Instantiate (enemy, _spawnPos, Quaternion.identity);
				_currentNbSpawned++;

				yield return new WaitForSeconds (wait);

			} else {
				yield break;
			}
		}
	}

	IEnumerator PresentPhase(int phaseNumber, float wait){
		while (true) {
			GUIManager.instance.ShowPhase (phaseNumber + 1);
			yield return new WaitForSeconds (wait);
			GUIManager.instance.HidePhase();
			StartCoroutine (Spawn (phaseNumber, spawningDelay));
			yield break;
		}
	}

	IEnumerator EndGame(){
		while (true) {

			GUIManager.instance.ShowWinGame ();
			AudioManager.instance.PlayWinSound ();
			yield return new WaitForSeconds (7f);
			GameManager.instance.LoadScene ("Menu");
			yield break;
		}
	}

	void StartPhase(int phaseNumber){
		if (phaseNumber < nbEnemiesPerPhase.Length) {
			_currentPhase = phaseNumber;
			_currentNbKilled = 0;
			_currentNbSpawned = 0;
			StartCoroutine (PresentPhase(phaseNumber, 4f));
		} else {
			StartCoroutine (EndGame());
		}
	}

	public void EnemyKilled(){
		_currentNbKilled++;

		if (_currentNbKilled ==  nbEnemiesPerPhase[_currentPhase]) {
			_currentPhase++;
			StartPhase (_currentPhase);
		}
	}

	/*public void EndSpawning(){
		StopCoroutine (Spawn());
		StopCoroutine (PresentPhase ());
	}*/

}
