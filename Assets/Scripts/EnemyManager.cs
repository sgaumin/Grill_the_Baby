using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public float moveSpeed;
	public float wait;
	public float waitForReload;
	public Collider2D movingArea;
	public GameObject bullet;

	private Rigidbody2D _RB;
	private Vector2 _target;
	// private Vector2 _minBound;
	// private Vector2 _maxBound;
	private PlayerManager _PM;

	// Use this for initialization
	void Start () {
		movingArea.gameObject.SetActive (true);
		_RB = GetComponent<Rigidbody2D> ();
		_PM = FindObjectOfType<PlayerManager> ();
        _target = Vector2.zero;
		// _minBound = movingArea.bounds.min;
		// _maxBound = movingArea.bounds.max;

		StartCoroutine (Move (wait));
		StartCoroutine (Shoot (waitForReload));
	}

	IEnumerator Move(float wait){
		while (true) {

            _target = new Vector2 (Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed);

            /*if ( (transform.position.x + _pos.x) >  _maxBound.x || (transform.position.x -_pos.x) <  _minBound.x || (transform.position.y + _pos.y) > _maxBound.y || (transform.position.y - _pos.y) < _minBound.y) {
				_pos = Vector2.zero;
			}*/

            float alea = Random.Range(wait * 0.5f, wait);
            Vector2 _finalTarget = alea * _target;

            Vector2 _finalPos = new Vector2(transform.position.x, transform.position.y);

            _finalPos += _finalTarget;

            if (!movingArea.bounds.Contains(_finalPos))
            {
                _target = Vector2.zero;
            }
 
            yield return new WaitForSeconds(alea);
            _target = Vector2.zero;
			yield return new WaitForSeconds(Random.Range(wait * 0.5f, wait));
		}
	}

	IEnumerator Shoot(float wait){
		while (true) {
			yield return new WaitForSeconds (wait + Random.Range(-0.5f * wait, 0.5f * wait));
			Instantiate (bullet, transform.position, transform.rotation);
		}
	}

	void FixedUpdate(){
		_RB.velocity = _target;

	}

	void OnDestroy(){

		SpawnManager.instance.EnemyKilled ();
		GUIManager.instance.ChangeScore (1);
	}
}
