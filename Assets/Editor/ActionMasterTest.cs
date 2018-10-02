using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ActionMasterTest {

	private List<int> pinFalls;
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

	[SetUp]
	public void Setup(){
		pinFalls = new List<int> ();
	}

	[Test]
	public void T00PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01OneStrike(){
		pinFalls.Add (10);
		Assert.AreEqual(endTurn,ActionMaster.NextAction(pinFalls));
		
	}

	[Test]
	public void T02Bowl8(){
		pinFalls.Add (8);
		Assert.AreEqual(tidy,ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T03Bowl28Spare(){
		int[] rolls = { 8, 2 };
		Assert.AreEqual (endTurn,ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T04StrikeInLastFrame(){
		int[] rolls={1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10};
		Assert.AreEqual(reset,ActionMaster.NextAction(rolls.ToList()));
	}


	[Test]
	public void T05SpareInLastFrame(){
		int[] rolls={1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9};
		Assert.AreEqual(reset,ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T06GameEndsAt21(){
		int[] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 8,2, 9};
		Assert.AreEqual (endGame, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T07GameEndsAt20(){
		int[] rolls={1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		Assert.AreEqual (endGame,ActionMaster.NextAction(rolls.ToList()));
	}


	[Test]
	public void T08ResetAt20(){
		int[] rolls={1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,1};
		Assert.AreEqual (tidy, ActionMaster.NextAction(rolls.ToList()));
	}


	[Test]
	public void T09TidyAt20ForGutter(){
		int[] rolls={1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,0};

		Assert.AreEqual (tidy, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T10SecondChanceStrike(){
		int[] rolls = { 0, 10, 5,1};
		Assert.AreEqual (endTurn, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T11TripleStrike(){
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10,10,10};

		Assert.AreEqual (endGame,ActionMaster.NextAction(rolls.ToList()));
	}


	[Test]
	public void T12GutterFirst(){
		int[] rolls = { 0, 1 };
		Assert.AreEqual (endTurn, ActionMaster.NextAction(rolls.ToList()));
	}
}
