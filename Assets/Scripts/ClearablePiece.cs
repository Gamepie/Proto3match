using UnityEngine;
using System.Collections;

public class ClearablePiece : MonoBehaviour {

	public AnimationClip clearAnimation;

	private bool isBeingCleared = false;

	public bool IsBeingCleared {
		get { return isBeingCleared; }
	}

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

	public virtual void Clear()
	{
		//piece.GridRef.level.OnPieceCleared (piece);
		isBeingCleared = true;
		StartCoroutine (ClearCoroutine ());
	}

	private IEnumerator ClearCoroutine()
	{
		Animator animator = GetComponent<Animator> ();

		if (animator) {
			animator.Play (clearAnimation.name);

			yield return new WaitForSeconds (clearAnimation.length);
			if (this.gameObject.tag == "Robbed") {
				isBeingCleared = true;
			}
			Destroy (gameObject);
		}
	}
}
