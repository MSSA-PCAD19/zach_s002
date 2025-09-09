using DeckLibrary;
namespace LearnMethods;
// create a seperate ClassLibrary Project
// move reusable class into the Class Library
// make project reference to class library
// use class library classes in your test or UI code

[TestClass]
public class DeckTest
{
    [TestMethod]
    public void ADeckHas52Cards()
    {
        string[] aDeck = Deck.GetDeck();
        Assert.AreEqual(52, aDeck.Length);
    }

    [TestMethod]
    public void ADeckHas52UniqueCards()
    {
        HashSet<string> cardSet = new();
        string[] aDeck = Deck.GetDeck();
        // aDeck[0] == aDeck[1]; // to make test fail
        foreach (var card in aDeck)
        {
            if (!cardSet.Add(card)) 
            {
                Assert.Fail($"There is a duplicate card {card}");
            }
            
        }

    }

    [TestMethod]
    public void ANewDeckHaveSortedCardsBySuit()
    {
        string[] aDeck = Deck.GetDeck();
        string[] spade = aDeck[0..13]; // 0 is inclusive, 13 is exclusive
        string[] heart = aDeck[13..26];
        string[] diamond = aDeck[26..39];
        string[] club = aDeck[39..];
        Assert.AreEqual(1, spade.Select(card => card[0]).Distinct().Count());
        Assert.AreEqual(1, heart.Select(card => card[0]).Distinct().Count());
        Assert.AreEqual(1, diamond.Select(card => card[0]).Distinct().Count());
        Assert.AreEqual(1, club.Select(card => card[0]).Distinct().Count());

    }


    [TestMethod]
    public void ANewDeckHasAceOfSpadeFirst()
    {
        string[] aDeck = Deck.GetDeck();
        Assert.AreEqual("\U0001F0A1", aDeck[0]);
    }

    [TestMethod]
    public void ShuffleCardsMovesCardsAround()
    {
        string[] newDeck = Deck.GetDeck();
        string[] shuffledDeck = Deck.GetDeck();

        Deck.Shuffle(shuffledDeck);

        Assert.IsTrue(shuffledDeck.SequenceEqual(newDeck)); //shuffled deck should not have the same sequence of cards as the newDeck
        CollectionAssert.AreEquivalent(newDeck, shuffledDeck); //should have same elements as new deck, no more/no less
    }

    [TestMethod]
    public void DrawCardsReturnCorrectNumberOfCardsTest()
    {
        string[] newDeck = Deck.GetDeck();
        string[] hand = Deck.DrawCards(ref newDeck, 5);
        Assert.AreEqual(5, hand.Length);
    }

    [TestMethod]
    public void MultipleDrawDoesNotReturnDuplicateCards()
    {
        string[] newDeck = Deck.GetDeck();
        string[] hand1 = Deck.DrawCards(ref newDeck, 10);
        string[] hand2 = Deck.DrawCards(ref newDeck, 10);
        CollectionAssert.AreNotEquivalent(hand1, hand2); //make sure its not dealing the same 10 card twice
        HashSet<string> hand1Set = new(hand1);
        HashSet<string> hand2Set = new(hand2);
        Assert.AreEqual(0, hand1Set.Intersect(hand2).Count());//2 hands must not have card in common
    }
}
