using UnityEngine;
using System.Collections;

public class KeyPiece : MonoBehaviour {

	public AnimationClip keyAnimation;


	private bool isBeingFound = false;

	public bool IsBeingFound {
		get { return isBeingFound; }
	}

	public bool keyanimover = false;

	protected Piece piece;


	void Awake() {
		piece = GetComponent<Piece> ();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}



	public virtual void keyFound()
	{

		isBeingFound = true;
		StartCoroutine (FoundCoroutine ());
	}

	private IEnumerator FoundCoroutine()
	{
		Animator animator = GetComponent<Animator> ();

		if (animator) {
			animator.Play (keyAnimation.name);

			yield return new WaitForSeconds (keyAnimation.length);



		}
		keyanimover = true;
		Destroy (gameObject);
	}
}
