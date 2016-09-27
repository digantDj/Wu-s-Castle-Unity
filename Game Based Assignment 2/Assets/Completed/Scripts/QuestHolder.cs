using UnityEngine;
using System.Collections;

namespace Completed
{
	public class QuestHolder : MonoBehaviour {


		private QuestManager qMan;

		// Use this for initialization
		void Start () {
			qMan = FindObjectOfType<QuestManager> ();
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		//OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
		private void OnTriggerStay2D (Collider2D other)
		{
			if (other.gameObject.name == "Player") {
				if (Input.GetKeyUp (KeyCode.Space)) {
					//other.gameObject.transform.position = new Vector3(transform.position.x, 3, transform.position.z);
					if (!qMan.questActive) {
						qMan.SetupQuest ();
					}
					//other.gameObject.transform.position = new Vector3(columns-2, rows-1, transform.position.z);
				}
			}
		}
	}
}
