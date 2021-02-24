using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HexCase : MonoBehaviour {

	public bool start,end = false;//est-ce que c'est une case de départ ou de fin ?
	public int etat ;// case vide =0; case rouge =2; case bleu = 1, case de depart = 4 ...
	public bool canChange = true; //peut-on cliquer sur la case ?

	private void OnMouseOver()
	{
		// souris survole le GameObject avec le script attaché si l'objet a un collider 
		//temporisation elle permet de faire durée l'effet un mement 
		StartCoroutine (ChangeScale ());
	}

	//Effet zoom quand on passe sur une case 
	IEnumerator ChangeScale (){
		//Si on peut cliquer sur la case 
		if (canChange) {
			//Modifier la taille d'un objet : augmenter la taille de la case pondant 0.1 seconde qu'on passe sur elle 
			iTween.ScaleTo (this.gameObject,new Vector3(1.2f,1.2f,1.2f), 0.1f);
			//Pationter 0.1 seconde 
			yield return new WaitForSeconds (0.1f);
			//modifier la taille de la case à 1
			iTween.ScaleTo (this.gameObject,new Vector3(1,1,1), 0.1f);
		}
	}

	//Mode joueur1 contre joueur2 humains 
	private void OnMouseUp(){
		if(canChange ){
			if (!HexGameManager.end) {
				if (etat == 0) {
					if (HexGameManager.player == 1) {
						GetComponent<SpriteRenderer> ().color = Color.blue;// le tour du joeur 1 le joueur 1 joue en bleu 
						HexGameManager.player = 2;//le tour du jouer 2
						etat = 1;
					} else {
						GetComponent<SpriteRenderer> ().color = Color.red;// le tour du joeur 2 le joueur 2 joue en rouge 
						HexGameManager.player = 1;//le tour du jouer 1
						etat = 1;
					}


					//TODO 2eme joeur ou IA

				}
				
			} 
			else {
				print ("la Partie est finie !");
			}
		}
	}


	public void checkIfWin(){
		
	}

 /*private void OnMouseUp(){
	if(canChange && HexGameManager.player == 1){
		if (!HexGameManager.end) {
			if (etat == 0) {
				GetComponent<SpriteRenderer> ().color = Color.blue;// le tour du joeur 1 le joueur 1 joue en bleu 
				HexGameManager.player = 2;//le tour du jouer 2
				etat =1;
				//fonction qui demande à IA de jouer 
					StartCoroutine (HexIAPlay());
			}

		} 
		else {
			print ("la Partie est finie !");
		}
	}
}
	IEnumerator HexIAPlay(){
		//Pationter 0.5 seconde 
		yield return new WaitForSeconds(0.2f);
		// elle appele le script de IA 
		GameObject.Find("GM").GetComponent<HexAI>().IaPlay();
	}*/


}