using Microsoft.FSharp.Collections;
using static Poker.Domain.PokerGame;
using static Poker.Domain.PokerGame.Suit;
using static Poker.Domain.PokerGame.Rank;

namespace Poker.Domain.UnitTestsCSharp;

public class UnitTest1
{
    private static readonly (Suit, Rank)[] royalStraightFlushHand =
        new[]{ (Diamonds, King), (Diamonds, Ten), (Diamonds, Queen), (Diamonds, Ace), (Diamonds, Jack) };

    private static readonly (Suit, Rank)[] straightFlushHand =
        new[]{ (Hearts, King), (Hearts, Queen), (Hearts, Jack), (Hearts, Ten), (Hearts, Nine) };

    private static readonly (Suit, Rank)[] fourOfAKindHand =
        new[]{ (Hearts, Queen), (Spades, Queen), (Hearts, Three), (Diamonds, Queen), (Clubs, Queen) };

    private static readonly (Suit, Rank)[] fullHouseHand =
        new[]{ (Hearts, Four), (Spades, Ace), (Hearts, Ace), (Diamonds, Ace), (Clubs, Four) };

    private static readonly (Suit, Rank)[] flushHand =
        new[]{ (Clubs, Four), (Clubs, Nine), (Clubs, Three), (Clubs, Seven), (Clubs, Two) };

    private static readonly (Suit, Rank)[] straightHand =
        new[]{ (Hearts, Four), (Spades, Ace), (Hearts, Three), (Diamonds, Five), (Clubs, Two) };

    private static readonly (Suit, Rank)[] threeOfAKindHand =
        new[]{ (Hearts, Six), (Spades, Ace), (Spades, Six), (Diamonds, Five), (Clubs, Six) };

    private static readonly (Suit, Rank)[] twoPairsHand =
        new[]{ (Hearts, Eight), (Spades, Ace), (Spades, Six), (Diamonds, Six), (Clubs, Eight) };

    private static readonly (Suit, Rank)[] onePairHand =
        new[]{ (Hearts, Two), (Spades, Eight), (Spades, Six), (Diamonds, Nine), (Clubs, Eight) };

    private static readonly (Suit, Rank)[] highCardHand =
        new[]{ (Hearts, Five), (Spades, Eight), (Spades, Six), (Diamonds, Jack), (Clubs, Three) };

    private static IEnumerable<object[]> GetAllTestHands()
    {
        yield return new object[] { HandRanking.RoyalStraightFlush, royalStraightFlushHand };
        yield return new object[] { HandRanking.StraightFlush, straightFlushHand };
        yield return new object[] { HandRanking.FourOfAKind, fourOfAKindHand };
        yield return new object[] { HandRanking.FullHouse, fullHouseHand };
        yield return new object[] { HandRanking.Flush, flushHand };
        yield return new object[] { HandRanking.Straight, straightHand };
        yield return new object[] { HandRanking.ThreeOfAKind, threeOfAKindHand };
        yield return new object[] { HandRanking.TwoPairs, twoPairsHand };
        yield return new object[] { HandRanking.OnePair, onePairHand };
        yield return new object[] { HandRanking.HighCard, highCardHand };
    }

#pragma warning disable CA1825

    [Theory]
    [MemberData(nameof(GetAllTestHands))]
    public static void Should_match_expected_hand_rankings(HandRanking expectedRanking, (Suit,Rank)[] hand)
    {
        var handFs = ListModule.OfSeq(hand.Select(c => new Tuple<Suit, Rank>(c.Item1, c.Item2)));
        Assert.Equal(expectedRanking, getHandRanking(handFs));
    }

#pragma warning restore CA1825

}