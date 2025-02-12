using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game(new List<string> { "Player 1", "Player 2" });
        game.Play();
    }
}

class Game
{
    private List<Player> players;
    private Queue<Card> deck;
    private static Random rnd = new Random();
    private const int maxRounds = 10;

    public Game(List<string> playerNames)
    {
        players = playerNames.Select(name => new Player(name)).ToList();
        deck = GenerateDeck();
        ShuffleDeck();
        DealCards();
    }

    private Queue<Card> GenerateDeck()
    {
        var deck = new List<Card>();
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] ranks = { "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

        foreach (var suit in suits)
            foreach (var rank in ranks)
                deck.Add(new Card(suit, rank));

        return new Queue<Card>(deck);
    }

    private void ShuffleDeck()
    {
        deck = new Queue<Card>(deck.OrderBy(_ => rnd.Next()));
    }

    private void DealCards()
    {
        int playerIndex = 0;
        while (deck.Count > 0)
        {
            players[playerIndex].AddCard(deck.Dequeue());
            playerIndex = (playerIndex + 1) % players.Count;
        }
    }

    public void Play()
    {
        int round = 0;
        while (round < maxRounds)
        {
            round++;
            Console.WriteLine($"--- Round {round} ---");
            foreach (var player in players)
            {
                Console.WriteLine($"{player.Name} has cards: {player.GetCards()}\n");
            }

            var playedCards = new List<(Player player, Card card)>();

            foreach (var player in players)
            {
                if (!player.HasCards()) continue;
                var card = player.PlayCard();
                playedCards.Add((player, card));
                Console.WriteLine($"{player.Name} played {card}");
            }

            var winner = playedCards.OrderByDescending(pc => pc.card.Value).First().player;
            Console.WriteLine($"{winner.Name} wins the round!");

            foreach (var (player, card) in playedCards)
                winner.AddCard(card);

            Console.WriteLine("Press Enter for the next round...");
            Console.ReadLine();
        }

        var winnerPlayer = players.OrderByDescending(p => p.CardCount()).First();
        Console.WriteLine($"Game over! {winnerPlayer.Name} wins with {winnerPlayer.CardCount()} cards!");
    }
}

class Player
{
    public string Name { get; }
    private Queue<Card> hand;

    public Player(string name)
    {
        Name = name;
        hand = new Queue<Card>();
    }

    public void AddCard(Card card)
    {
        hand.Enqueue(card);
    }

    public Card PlayCard()
    {
        return hand.Dequeue();
    }

    public bool HasCards()
    {
        return hand.Count > 0;
    }

    public int CardCount()
    {
        return hand.Count;
    }

    public string GetCards()
    {
        return string.Join(", ", hand.Select(card => card.ToString()));
    }
}

class Card
{
    public string Suit { get; }
    public string Rank { get; }
    public int Value { get; }

    private static readonly Dictionary<string, int> RankValues = new Dictionary<string, int>
    {
        { "6", 6 }, { "7", 7 }, { "8", 8 }, { "9", 9 }, { "10", 10 },
        { "Jack", 11 }, { "Queen", 12 }, { "King", 13 }, { "Ace", 14 }
    };

    public Card(string suit, string rank)
    {
        Suit = suit;
        Rank = rank;
        Value = RankValues[rank];
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}
