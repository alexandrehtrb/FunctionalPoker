namespace Poker.Domain.UnitTestsFSharp

open System
open Xunit
open Poker.Domain.PokerGame
open type Poker.Domain.PokerGame.Rank

module Tests =

    let royalStraightFlushHand =
        [ (Diamonds, King); (Diamonds, Ten); (Diamonds, Queen); (Diamonds, Ace); (Diamonds, Jack); ]

    let straightFlushHand =
        [ (Hearts, King); (Hearts, Queen); (Hearts, Jack); (Hearts, Ten); (Hearts, Nine); ]

    let fourOfAKindHand =
        [ (Hearts, Queen); (Spades, Queen); (Hearts, Three); (Diamonds, Queen); (Clubs, Queen); ]

    let fullHouseHand =
        [ (Hearts, Four); (Spades, Ace); (Hearts, Ace); (Diamonds, Ace); (Clubs, Four); ]

    let flushHand =
        [ (Clubs, Four); (Clubs, Nine); (Clubs, Three); (Clubs, Seven); (Clubs, Two); ]

    let straightHand =
        [ (Hearts, Four); (Spades, Ace); (Hearts, Three); (Diamonds, Five); (Clubs, Two); ]

    let threeOfAKindHand =
        [ (Hearts, Six); (Spades, Ace); (Spades, Six); (Diamonds, Five); (Clubs, Six); ]

    let twoPairsHand =
        [ (Hearts, Eight); (Spades, Ace); (Spades, Six); (Diamonds, Six); (Clubs, Eight); ]

    let onePairHand =
        [ (Hearts, Two); (Spades, Eight); (Spades, Six); (Diamonds, Nine); (Clubs, Eight); ]

    let highCardHand =
        [ (Hearts, Five); (Spades, Eight); (Spades, Six); (Diamonds, Jack); (Clubs, Three); ]

    let allHands : obj[] list =
        [
            [| HandRanking.RoyalStraightFlush; royalStraightFlushHand |]
            [| HandRanking.StraightFlush; straightFlushHand |]
            [| HandRanking.FourOfAKind; fourOfAKindHand |]
            [| HandRanking.FullHouse; fullHouseHand |]
            [| HandRanking.Flush; flushHand |]
            [| HandRanking.Straight; straightHand |]
            [| HandRanking.ThreeOfAKind; threeOfAKindHand |]
            [| HandRanking.TwoPairs; twoPairsHand |]
            [| HandRanking.OnePair; onePairHand |]
            [| HandRanking.HighCard; highCardHand |]
        ]

    [<Theory>]
    [<MemberData(nameof(allHands))>]
    let ``Should match expected hand rankings`` (expectedRanking, hand) =
        Assert.Equal(expectedRanking, getHandRanking(hand))
