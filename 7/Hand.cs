using System.Collections;
using System.Collections.Concurrent;

namespace day7 {

public class Hand : IComparable<Hand> {
  private String hand;
  private long score;
  private HandType? handType;

    public static Dictionary<char, int> cardMap = new(){
        {'A', 12},
        {'K', 11},
        {'Q' , 10},
        {'J' , 9},
        {'T' , 8},
        {'9' , 7},
        {'8' , 6},
        {'7' , 5},
        {'6' , 4},
        {'5' , 3},
        {'4' , 2},
        {'3' , 1},
        {'2' , 0},        
    };

  // Constructor
  public Hand(String hand, long score) {
      this.hand = hand;
      this.score = score;
      this.handType = null;

        Dictionary<char, int> counts = new Dictionary<char, int>();

        foreach (char c in hand)
        {
            if (counts.ContainsKey(c))
            {
                counts[c]++;
            }
            else
            {
                counts[c] = 1;
            }
        }

        bool onePair = false;
        foreach (var value in counts.Values) {
            if (value == 5) {
                this.handType = HandType.FIVE_OF_A_KIND;
                break;
            }
            
            if (value == 4) {
                this.handType = HandType.FOUR_OF_A_KIND;
                break;
            }
            
            if (value == 3 && counts.Keys.Count == 2) {
                this.handType = HandType.FULL_HOUSE;
                break;
            } 

            if (value == 3) {
                this.handType = HandType.THREE_OF_A_KIND;
                break;
            }

            if (value == 2 && onePair) {
                this.handType = HandType.TWO_PAIR;
                break;
            }

            if (value == 2) {
                onePair = true;
            }
        }

        if (this.handType == null) {
            if (onePair) {
                this.handType = HandType.ONE_PAIR;
            } else {
                this.handType = HandType.HIGH_CARD;
            }
        }
  }

  // Getters and Setters
  public String getHand() {
      return this.hand;
  }

  public void setHand(String hand) {
      this.hand = hand;
  }

  public long getScore() {
      return this.score;
  }

  public void setScore(long score) {
      this.score = score;
  }

  public void setHandType(HandType handType) {
      this.handType = handType;
  }

        public int CompareTo(Hand? other)
        {
            if (other == null) {
                return 1;
            }

            if (this.handType > other.handType) {
                return 1;
            }

            if (this.handType < other.handType) {
                return -1;
            }

            for (int i = 0; i < this.hand.Length; i++) {
                if (cardMap[this.hand[i]] < cardMap[other.hand[i]]) {
                    return -1;
                }

                if (cardMap[this.hand[i]] > cardMap[other.hand[i]]) {
                    return 1;
                }
            }

            return 0;
        }
    }


public enum HandType {
   FIVE_OF_A_KIND = 6,
   FOUR_OF_A_KIND = 5,
   FULL_HOUSE = 4,
   THREE_OF_A_KIND = 3,
   TWO_PAIR = 2,
   ONE_PAIR = 1,
   HIGH_CARD = 0
}

}