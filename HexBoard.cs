using UnityEngine;
using System.Collections;

public class HexBoard : MonoBehaviour {

	//Tableau qui contient toute les cases instancier : implimentation du plateau de jeux sous forme de tableau
	public HexCase[,] board;
	//la case a instancier plusieur fois pour creer le tableau
	public GameObject caseObj;
	int nbCase = 14;

	// Use this for initialization
	void Start () {
		ConstructBoard();
	}

	public void ConstructBoard(){
		
		board = new HexCase[nbCase, nbCase];//Creer le tableau de taille : nbCase * nbCase

		//parcourire les lignes et colones pour instancier les cases
		for (int i = 0; i < nbCase; i++) {
			for (int j = 0; j < nbCase; j++) {
				//Géneration des cases du plateau :
				//instancier caseObj = la case 
				//Vector3(i,0,j) : la position a la quelle en instancier la case depond de i et j 
				//Quaternion.Euler(new Vector3(90,0,0) : en fait une rotation a 90 degré pour que les case soit appelat pas en vue de face 
				GameObject caseInstancier = (GameObject)Instantiate (caseObj, new Vector3 (i, 0, j), Quaternion.Euler (new Vector3 (90, 0, 0)));
				//nommer les case par leur numéro de ligne et de colone pour pouvoir recupérer leur position 
				caseInstancier.name = i + "-" + j;
				//En positionne les case les une a coté des autre sans qu'elle se touche avec un petit décalage 
				caseInstancier.transform.position = new Vector3 (caseInstancier.transform.position.x + 0.5f * j, caseInstancier.transform.position.y, caseInstancier.transform.position.z - 0.2f * j);
				//Pour chaque case instancier en recupére sont composant case et en le stock dans le tableau 
				board [i, j] = caseInstancier.GetComponent<HexCase> ();
				//j'insatancier toute les cases du plateau comme enfant du game manager (GM) moi meme
				caseInstancier.transform.parent = transform;

				//Coloration des cotés
				if (i == 0 || j == 0 || i == nbCase - 1 || j == nbCase - 1) {
					
					caseInstancier.GetComponent<HexCase> ().etat = 4;//Case de départ 
					caseInstancier.GetComponent<HexCase> ().canChange = false;//On clique sur une case de départ 
					caseInstancier.GetComponent<HexCase> ().start = true;//Case de départ 

				}

				//Coloration du coté Rouge 
				if (i == 0 || i == (nbCase - 1)) {
					caseInstancier.GetComponent<SpriteRenderer> ().color = Color.red;
				}

				//Coloration du coté Bleu 
				if (j == 0 || j == (nbCase - 1)) {
					caseInstancier.GetComponent<SpriteRenderer> ().color = Color.blue;
				}
			}
		}
	}
}