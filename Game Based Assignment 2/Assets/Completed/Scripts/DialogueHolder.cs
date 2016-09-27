using UnityEngine;
using System.Collections;

public class DialogueHolder : MonoBehaviour {

	public string dialogue;
	private DialogueManager dMan;

	public string[] dialogueLines;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogueManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			if (Input.GetKeyUp (KeyCode.Space)) {
				//dMan.ShowBox (dialogue);
				other.gameObject.transform.position = new Vector3(transform.position.x, 3, transform.position.z);

				if (!dMan.dialogActive) {
					dMan.dialogLines = dialogueLines;
					dMan.currentLine = 0;
					dMan.ShowDialogue ();
				}
			}
		}
	}
}
