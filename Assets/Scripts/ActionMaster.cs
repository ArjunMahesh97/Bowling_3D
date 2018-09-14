using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster{

	private int[] bowls = new int[21];
	private int bowl=1;

	public enum Action{Tidy, Reset, EndTurn, EndGame}; 

	public Action Bowl(int pins){
		
		if (pins < 0 || pins > 10) {throw new UnityException ("Invalid pins");}

		bowls [bowl - 1] = pins;

		if (bowl >= 19 && Bowl21Awarded ()) {
			bowl += 1;
			return Action.Reset;
		}

		if (pins == 10) {
			bowl += 2;
			return Action.EndTurn;

		}

		if (bowl % 2 != 0) {
			bowl += 1;
			return Action.Tidy;
		} else if (bowl % 2 == 0) {
			bowl += 1;
			return Action.EndTurn;
		}

		throw new UnityException ("Not Sure");
	}

	private bool Bowl21Awarded(){
		return (bowls [18] + bowls [19] >= 10);
	}
}
