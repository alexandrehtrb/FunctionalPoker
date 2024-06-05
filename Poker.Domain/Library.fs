namespace Poker.Domain

module PokerGame =

    // this is a discriminated union ♠️ ♣️ ♥️ ♦️
    type Suit = Spades | Clubs | Hearts | Diamonds

    // this is an enum, just like C#
    type Rank =
    | Two = 2 | Three = 3 | Four = 4 | Five = 5 | Six = 6 | Seven = 7 | Eight = 8
    | Nine = 9 | Ten = 10 | Jack = 11 | Queen = 12 | King = 13 | Ace = 14

    // this is a tuple
    type Card = Suit * Rank

    type Hand = Card list

    type HandRanking =
    | RoyalStraightFlush = 10
    | StraightFlush = 9
    | FourOfAKind = 8
    | FullHouse = 7
    | Flush = 6
    | Straight = 5
    | ThreeOfAKind = 4
    | TwoPairs = 3
    | OnePair = 2
    | HighCard = 1

    let hasStraight(hand: Hand) =
        hand
        |> Seq.sortBy(fun (_,rank) -> rank)
        |> Seq.pairwise
        |> Seq.forall(fun ((_,rank1), (_,rank2)) ->
            (int rank2) - (int rank1) = 1 || (rank2 = Rank.Ace && rank1 = Rank.Five))

    let hasFlush(hand: Hand) =
        let (someSuit, someRank) = Seq.head hand
        hand
        |> Seq.map (fun (suit,_) -> suit)
        |> Seq.forall ((=)someSuit)

    let hasKingAndAce(hand: Hand) =
        let hasKing = Seq.exists(fun (_,rank) -> rank = Rank.King)(hand)
        let hasAce = Seq.exists(fun (_,rank) -> rank = Rank.Ace)(hand)
        hasKing && hasAce

    let getSortedQuantitiesPerRank(hand: Hand) =
        hand
        |> Seq.countBy(fun (_, rank) -> rank)
        |> Seq.sortBy(fun (_, qtyForRank) -> qtyForRank)
        |> Seq.map(fun (_, qtyForRank) -> qtyForRank)
        |> Seq.toList

    let getHandRanking(hand: Hand) =
        match getSortedQuantitiesPerRank(hand) with
        | [ 1; 4 ] -> HandRanking.FourOfAKind
        | [ 2; 3 ] -> HandRanking.FullHouse
        | [ 1; 1; 3 ] -> HandRanking.ThreeOfAKind
        | [ 1; 2; 2 ] -> HandRanking.TwoPairs
        | [ 1; 1; 1; 2 ] -> HandRanking.OnePair
        | _ -> match (hasStraight(hand), hasFlush(hand), hasKingAndAce(hand)) with
               | (true, true, true) -> HandRanking.RoyalStraightFlush
               | (true, true, false) -> HandRanking.StraightFlush
               | (true, false, _) -> HandRanking.Straight
               | (false, true, _) -> HandRanking.Flush
               | _ -> HandRanking.HighCard
