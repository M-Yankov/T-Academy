Hi,
Plaese open UnitTestingHomework.sln in Visual Studio. In Solution Explorer You will see two directories: Task1; Task2 and Task3;

	• Tests for task1 is in StudentsAndCoursesTest/. To see results from Code Coverage I exports it in folder next to .sln file. Open Code Coverage Results window in VS and click on inport results then navigate to user_LENOVO-TestResultsForStudentsTest. Somethimes Test>Analyze code coverage> all tests not works property.

	• For other two Tasks - they are located in SantaseTest. I used for them Nunit Plugin. If you have problems instll it. Some modifications are done beacuse of obey the rules. 
		- Added Class Player.cs to make GameRounds() easly.
		- deleted access modifier setter on PlayerTurnContext.cs FirstPlayerCard. Only for testing purposes.
		- Bug found - onFinalState if you have card from same suit that is played you must respond it, no matter that you have trump or not. Before that you could draw any card.
		- To fix this bug - in PlayerActionValidater added some code lines; ~48-50line /*additionl rule*/
		- Code coverage for Tasks3 PlayerTurnContext.cs is 100%. Open user_LENOVO-TestresultCoverageFor-PlayerActionValidation.coveragexml
		- Task2 is DeckTest.cs
		- Task3 is PlayerActionValidaterTest.cs