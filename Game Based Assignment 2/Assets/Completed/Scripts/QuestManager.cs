using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Completed
{
	public class QuestManager : MonoBehaviour {

		public GameObject qBox;
		public GameObject QuestStatement;
		// public GameObject skeletons;
		public Text qstat;
		public bool questActive;

		// Input Variables
		public Dropdown ADropdown;
		public Dropdown BDropdown;
		public Dropdown CDropdown;
		public Button tryButton;

		public string[] questStatementLines;

		public static GameManager gMan;

		public GameObject[] skeletons;
		public Sprite youngSkeleton;
		private SpriteRenderer sr;

		private int food;
		public Text foodText;

		private int tempCounter;

		// Use this for initialization
		void Start () {
			// Adding Listener to Button
			tryButton.onClick.AddListener(delegate() { tryVal(ADropdown.value, BDropdown.value, CDropdown.value); });
			food = GameManager.instance.playerFoodPoints;
		}

		// Update is called once per frame
		void Update () {
			if (questActive) {
			//	ShowQuest ();
			}
		}

		private void tryVal(int aIndex, int bIndex, int cIndex){
			if(GameManager.getLevel() == 1){
				if ((aIndex == 0) && (bIndex == 9) && (cIndex == 1)) {
				// Success Case 
					tempCounter = 0;
					skeletons = GameObject.FindGameObjectsWithTag ("Skeleton");
					foreach (GameObject skeleton in skeletons) {
						// sr = skeleton.GetComponent<SpriteRenderer> ();
						// sr.sprite = youngSkeleton;
						HideQuest ();
					 	Destroy (skeleton);
						tempCounter++;
					}
				} else {
				// Failure Case
					food--;
					foodText.text = "Tries Left: " + food;
					//Since the player has moved and lost food points, check if the game has ended.
					CheckIfGameOver ();
				}
			}
			else if(GameManager.getLevel() == 2){
				
				if ((aIndex == 0) && (bIndex == 9) && (cIndex == 2)) {
					// Success Case 
					skeletons = GameObject.FindGameObjectsWithTag ("Skeleton");
					tempCounter = 0;
					foreach (GameObject skeleton in skeletons) {
						// sr = skeleton.GetComponent<SpriteRenderer> ();
						// sr.sprite = youngSkeleton;
						HideQuest ();
						if (tempCounter % 2 == 0) {
							Destroy (skeleton);
						}
						tempCounter++;
					}
				} else {
					// Failure Case
					food--;
					foodText.text = "Tries Left: " + food;
					//Since the player has moved and lost food points, check if the game has ended.
					CheckIfGameOver ();
				}
			}
			else if(GameManager.getLevel() == 3){
				if ((aIndex == 3) && (bIndex == 7) && (cIndex == 1)) {
					// Success Case 
					tempCounter = 0;
					skeletons = GameObject.FindGameObjectsWithTag ("Skeleton");
					foreach (GameObject skeleton in skeletons) {
						// sr = skeleton.GetComponent<SpriteRenderer> ();
						// sr.sprite = youngSkeleton;
						HideQuest ();
						GameWin ();
						if ((tempCounter >= 3) && (tempCounter <= 7)) {
							Destroy (skeleton);
						}
						tempCounter++;
					}
				} else {
					// Failure Case
					food--;
					foodText.text = "Tries Left: " + food;
					//Since the player has moved and lost food points, check if the game has ended.
					CheckIfGameOver ();
				}
			}
		}

		public void SetupQuest(){
			qstat.text = questStatementLines [GameManager.getLevel() - 1];
			ShowQuest ();
		}

		public void ShowQuest(){
			questActive = true;
			qBox.SetActive (true);
			QuestStatement.SetActive(true);
			// skeletons.SetActive (true);
		}
		public void HideQuest(){
			questActive = false;
			qBox.SetActive (false);
			QuestStatement.SetActive(false);
			// skeletons.SetActive (true);
		}
		//CheckIfGameOver checks if the player is out of food points and if so, ends the game.
		private void CheckIfGameOver ()
		{
			//Check if food point total is less than or equal to zero.
			if (food <= 0) 
			{
				HideQuest ();
				//Call the GameOver function of GameManager.
				GameManager.instance.GameOver ();
			}
		}

		//GameWin function to handle Game Win condition
		private void GameWin(){
			GameManager.instance.GameWin ();
		}
	}
}
