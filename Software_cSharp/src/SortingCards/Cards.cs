using System;

namespace SortingCards
{
  class Card : IComparable<Card>
  {
    public int rank; 
    public int suit;

    public Card(int rank, int suit) {
      this.rank = rank;
      this.suit = suit;
    }

    public int CompareTo(Card c) {
      if (this.suit == c.suit) {
        if (this.rank < c.rank) {
          return -1;
        }
        else {
          return 1;
        }
      }
      else {
        if (this.suit < c.suit) {
          return -1;
        }
        else {
          return 1;
        }    
      }
    }

    public override string ToString() {
      return this.rank.ToString() + ", " + this.suit.ToString();
    }
  }
}