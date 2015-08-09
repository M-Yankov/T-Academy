namespace SantaseTest
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using NUnit.Framework;
    using Santase.Logic;
    using Santase.Logic.Cards;
    using Santase.Logic.Players;
    using Santase.Logic.RoundStates;

    [TestFixture]
    public class PlayerActionValidaterTest
    {
        private static PlayerActionValidater validator = new PlayerActionValidater();

        [Test]
        public void TestSimpleValidAction()
        {
            // PlayerActionValidater validato2r = new PlayerActionValidater();
            MoreThanTwoCardsLeftRoundState middleState = new MoreThanTwoCardsLeftRoundState(new GameRound(new Player(), new Player(), PlayerPosition.FirstPlayer));

            PlayerAction action = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Heart, CardType.King), Announce.None);
            PlayerTurnContext context = new PlayerTurnContext(middleState, new Card(CardSuit.Spade, CardType.Jack), 6);
            IList<Card> cards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardType.Ten), 
                new Card(CardSuit.Heart, CardType.King), 
                new Card(CardSuit.Spade, CardType.King),
                new Card(CardSuit.Club, CardType.King),
                new Card(CardSuit.Club, CardType.Nine),
                new Card(CardSuit.Diamond, CardType.Nine)
            };

            Assert.IsTrue(validator.IsValid(action, context, cards));
        }

        [Test]
        public void TestPlayNonExistentCard()
        {
            MoreThanTwoCardsLeftRoundState middleState = new MoreThanTwoCardsLeftRoundState(new GameRound(new Player(), new Player(), PlayerPosition.FirstPlayer));

            PlayerAction action = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Diamond, CardType.Ace), Announce.None);
            PlayerTurnContext context = new PlayerTurnContext(middleState, new Card(CardSuit.Spade, CardType.Jack), 6);
            IList<Card> cards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardType.Ten), 
                new Card(CardSuit.Heart, CardType.King), 
                new Card(CardSuit.Spade, CardType.King),
                new Card(CardSuit.Club, CardType.King),
                new Card(CardSuit.Club, CardType.Nine),
                new Card(CardSuit.Diamond, CardType.Nine)
            };

            Assert.IsFalse(validator.IsValid(action, context, cards));
        }

        [Test]
        public void TestAnnounceTwenty()
        {
            MoreThanTwoCardsLeftRoundState middle = new MoreThanTwoCardsLeftRoundState(new GameRound(new Player(), new Player(), PlayerPosition.FirstPlayer));

            PlayerAction action = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Heart, CardType.King), Announce.Twenty);
            PlayerTurnContext context = new PlayerTurnContext(middle, new Card(CardSuit.Spade, CardType.Jack), 6);
            IList<Card> cards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardType.Ten),
                new Card(CardSuit.Heart, CardType.King), 
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Club, CardType.King),
                new Card(CardSuit.Club, CardType.Nine),
                new Card(CardSuit.Diamond, CardType.Nine)
            };

            // a card is played. Just to avoid context.AmITheFirstPlayer;
            context.FirstPlayedCard = new Card(CardSuit.Club, CardType.King);

            validator.IsValid(action, context, cards);
            Assert.AreEqual(Announce.Twenty, action.Announce);
        }

        [Test]
        public void TestAnnounceFourty()
        {
            MoreThanTwoCardsLeftRoundState stateOfMiddle = new MoreThanTwoCardsLeftRoundState(new GameRound(new Player(), new Player(), PlayerPosition.FirstPlayer));

            PlayerAction action = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Spade, CardType.King), Announce.Fourty);
            PlayerTurnContext context = new PlayerTurnContext(stateOfMiddle, new Card(CardSuit.Spade, CardType.Jack), 6);
            IList<Card> cards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Spade, CardType.King), 
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Club, CardType.King),
                new Card(CardSuit.Club, CardType.Nine),
                new Card(CardSuit.Diamond, CardType.Nine)
            };

            // a card is played. Just to avoid context.AmITheFirstPlayer;
            context.FirstPlayedCard = new Card(CardSuit.Club, CardType.King);

            validator.IsValid(action, context, cards);
            Assert.AreEqual(Announce.Fourty, action.Announce);
        }

        [Test]
        public void TestAnnounceFakeTwentyToBeNone()
        {
            MoreThanTwoCardsLeftRoundState stateOfMiddle = new MoreThanTwoCardsLeftRoundState(new GameRound(new Player(), new Player(), PlayerPosition.FirstPlayer));

            PlayerAction action = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Club, CardType.Nine), Announce.Twenty);
            PlayerTurnContext context = new PlayerTurnContext(stateOfMiddle, new Card(CardSuit.Spade, CardType.Jack), 6);
            IList<Card> cards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Spade, CardType.King), 
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Club, CardType.King),
                new Card(CardSuit.Club, CardType.Nine),
                new Card(CardSuit.Diamond, CardType.Nine)
            };

            // a card is played. Just to avoid context.AmITheFirstPlayer;
            context.FirstPlayedCard = new Card(CardSuit.Club, CardType.King);

            validator.IsValid(action, context, cards);
            Assert.AreEqual(Announce.None, action.Announce);
        }

        [Test]
        public void TestAnnounceOnFirstHand()
        {
            MoreThanTwoCardsLeftRoundState stateOfMiddle = new MoreThanTwoCardsLeftRoundState(new GameRound(new Player(), new Player(), PlayerPosition.FirstPlayer));

            PlayerAction action = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Heart, CardType.King), Announce.Twenty);
            PlayerTurnContext context = new PlayerTurnContext(stateOfMiddle, new Card(CardSuit.Spade, CardType.Jack), 6);
            IList<Card> cards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Heart, CardType.King), 
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Club, CardType.King),
                new Card(CardSuit.Club, CardType.Nine),
                new Card(CardSuit.Diamond, CardType.Nine)
            };

            validator.IsValid(action, context, cards);
            Assert.AreEqual(Announce.None, action.Announce);
        }

        [Test]
        public void TestValidMoveWithTrumpCard()
        {
            // Using this state to enter in context.State.ShouldObserveRules.
            FinalRoundState endRound = new FinalRoundState();

            PlayerTurnContext context = new PlayerTurnContext(endRound, new Card(CardSuit.Spade, CardType.Jack), 0);

            // a card is played. Just to avoid context.AmITheFirstPlayer;
            context.FirstPlayedCard = new Card(CardSuit.Club, CardType.Nine);

            PlayerAction action = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Spade, CardType.Nine), Announce.None);
            IList<Card> cards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Spade, CardType.King), 
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Diamond, CardType.King),
                new Card(CardSuit.Spade, CardType.Nine),
                new Card(CardSuit.Diamond, CardType.Nine)
            };

            Assert.IsTrue(validator.IsValid(action, context, cards));
        }

        [Test]
        public void TestInvalidPlayedCard()
        {
            FinalRoundState endState = new FinalRoundState();

            PlayerTurnContext context = new PlayerTurnContext(endState, new Card(CardSuit.Spade, CardType.Jack), 0);

            context.FirstPlayedCard = new Card(CardSuit.Club, CardType.Ten);

            PlayerAction action = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Heart, CardType.Queen), Announce.None);
            IList<Card> cards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Spade, CardType.King), 
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Club, CardType.King),
                new Card(CardSuit.Spade, CardType.Nine),
                new Card(CardSuit.Diamond, CardType.Nine)
            };

            Assert.IsFalse(validator.IsValid(action, context, cards));
        }

        // This Test fails on old rules see: PlayerActionValidater.cs additional rule line 48;
        [Test]
        public void TestOtherCardWhenNoHaveTrump()
        {
            FinalRoundState finalState = new FinalRoundState();

            PlayerTurnContext context = new PlayerTurnContext(finalState, new Card(CardSuit.Diamond, CardType.Jack), 0);

            context.FirstPlayedCard = new Card(CardSuit.Club, CardType.Ten);

            // Have a club, but played Spade. False. Must play Club
            PlayerAction action = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Spade, CardType.Queen), Announce.Twenty);
            IList<Card> cards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Spade, CardType.King), 
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Club, CardType.King),
                new Card(CardSuit.Spade, CardType.Nine),
                new Card(CardSuit.Spade, CardType.Nine)
            };

            Assert.IsFalse(validator.IsValid(action, context, cards));
        }

        [Test]
        public void TestWithIncorrectTrumpCard()
        {
            FinalRoundState finalState = new FinalRoundState();

            PlayerTurnContext context = new PlayerTurnContext(finalState, new Card(CardSuit.Diamond, CardType.Jack), 0);

            context.FirstPlayedCard = new Card(CardSuit.Club, CardType.Ten);

            // You have a needed suit card but played trump. False -> Must play Club
            PlayerAction action = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Diamond, CardType.Nine), Announce.None);
            IList<Card> cards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Spade, CardType.King), 
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Club, CardType.King),
                new Card(CardSuit.Spade, CardType.Nine),
                new Card(CardSuit.Diamond, CardType.Nine)
            };

            Assert.IsFalse(validator.IsValid(action, context, cards));
        }

        [Test]
        public void TestInvalidMoveCardWithLowerValueWhenHaveBigger()
        {
            FinalRoundState finalState = new FinalRoundState();

            PlayerTurnContext context = new PlayerTurnContext(finalState, new Card(CardSuit.Diamond, CardType.Jack), 0);

            context.FirstPlayedCard = new Card(CardSuit.Club, CardType.King);

            // You must play card with bigger value.
            PlayerAction action = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Club, CardType.Nine), Announce.None);
            IList<Card> cards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Spade, CardType.King), 
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Club, CardType.Ace),
                new Card(CardSuit.Club, CardType.Nine),
                new Card(CardSuit.Diamond, CardType.Nine)
            };

            Assert.IsFalse(validator.IsValid(action, context, cards));
        }

        [Test]
        public void TestInvalidClosingGameInMiddleRound()
        {
            MoreThanTwoCardsLeftRoundState middle = new MoreThanTwoCardsLeftRoundState(new GameRound(new Player(), new Player(), PlayerPosition.FirstPlayer));

            PlayerTurnContext context = new PlayerTurnContext(middle, new Card(CardSuit.Diamond, CardType.Jack), 6);

            context.FirstPlayedCard = new Card(CardSuit.Club, CardType.King);

            // Cannot Close game because it's already played a card.
            PlayerAction action = new PlayerAction(PlayerActionType.CloseGame, new Card(CardSuit.Club, CardType.Nine), Announce.None);
            IList<Card> cards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Spade, CardType.King), 
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Club, CardType.Ace),
                new Card(CardSuit.Club, CardType.Nine),
                new Card(CardSuit.Diamond, CardType.Nine)
            };

            Assert.IsFalse(validator.IsValid(action, context, cards));
        }

        [Test]
        public void TestInvalidClosingGameInTheBegining()
        {
            StartRoundState begin = new StartRoundState(new GameRound(new Player(), new Player(), PlayerPosition.FirstPlayer));

            PlayerTurnContext context = new PlayerTurnContext(begin, new Card(CardSuit.Diamond, CardType.Jack), 12);

            PlayerAction action = new PlayerAction(PlayerActionType.CloseGame, new Card(CardSuit.Club, CardType.Nine), Announce.None);
            IList<Card> cards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Spade, CardType.King), 
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Club, CardType.Ace),
                new Card(CardSuit.Club, CardType.Nine),
                new Card(CardSuit.Diamond, CardType.Nine)
            };

            Assert.IsFalse(validator.IsValid(action, context, cards));
        }

        [Test]
        public void TestWrongChangeTrumpInTheBegining()
        {
            StartRoundState begin = new StartRoundState(new GameRound(new Player(), new Player(), PlayerPosition.FirstPlayer));

            PlayerTurnContext context = new PlayerTurnContext(begin, new Card(CardSuit.Diamond, CardType.Jack), 12);

            PlayerAction action = new PlayerAction(PlayerActionType.ChangeTrump, new Card(CardSuit.Club, CardType.Nine), Announce.None);
            IList<Card> cards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Spade, CardType.King), 
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Club, CardType.Ace),
                new Card(CardSuit.Club, CardType.Nine),
                new Card(CardSuit.Diamond, CardType.Nine)
            };

            Assert.IsFalse(validator.IsValid(action, context, cards));
        }

        [Test]
        public void TestWrongChangeTrumpIfNotYourTurn()
        {
            MoreThanTwoCardsLeftRoundState midle = new MoreThanTwoCardsLeftRoundState(new GameRound(new Player(), new Player(), PlayerPosition.FirstPlayer));

            PlayerTurnContext context = new PlayerTurnContext(midle, new Card(CardSuit.Diamond, CardType.Jack), 6);

            context.FirstPlayedCard = new Card(CardSuit.Diamond, CardType.King);

            PlayerAction action = new PlayerAction(PlayerActionType.ChangeTrump, new Card(CardSuit.Club, CardType.Nine), Announce.None);
            IList<Card> cards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Spade, CardType.King), 
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Club, CardType.Ace),
                new Card(CardSuit.Club, CardType.Nine),
                new Card(CardSuit.Diamond, CardType.Nine)
            };

            Assert.IsFalse(validator.IsValid(action, context, cards));
        }

        [Test]
        public void TestWrongChangeTrumpIfYouHaveNotNeededCard()
        {
            MoreThanTwoCardsLeftRoundState midle = new MoreThanTwoCardsLeftRoundState(new GameRound(new Player(), new Player(), PlayerPosition.FirstPlayer));

            PlayerTurnContext context = new PlayerTurnContext(midle, new Card(CardSuit.Diamond, CardType.Jack), 6);

            PlayerAction action = new PlayerAction(PlayerActionType.ChangeTrump, new Card(CardSuit.Club, CardType.Nine), Announce.None);
            IList<Card> cards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Spade, CardType.King), 
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Club, CardType.Ace),
                new Card(CardSuit.Club, CardType.Nine),
                new Card(CardSuit.Diamond, CardType.Ace)
            };

            Assert.IsFalse(validator.IsValid(action, context, cards));
        }

        [Test]
        public void TestValidChangeTrumpCard()
        {
            MoreThanTwoCardsLeftRoundState midle = new MoreThanTwoCardsLeftRoundState(new GameRound(new Player(), new Player(), PlayerPosition.FirstPlayer));

            PlayerTurnContext context = new PlayerTurnContext(midle, new Card(CardSuit.Diamond, CardType.Ten), 6);

            PlayerAction action = new PlayerAction(PlayerActionType.ChangeTrump, new Card(CardSuit.Club, CardType.Nine), Announce.None);
            IList<Card> cards = new List<Card>()
            {
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Spade, CardType.King), 
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Club, CardType.Ace),
                new Card(CardSuit.Club, CardType.Nine),
                new Card(CardSuit.Diamond, CardType.Nine)
            };

            Assert.IsTrue(validator.IsValid(action, context, cards));
        }
    }
}
