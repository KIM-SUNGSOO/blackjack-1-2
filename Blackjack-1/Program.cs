using System;
using System.Runtime.CompilerServices;
using System.Text;

Card card = new Card();
Player player = new Player();
Dealer dealer = new Dealer();


Console.WriteLine("=== 블랙잭 게임 ===");
Console.WriteLine();
card.cardShuffle();
Console.WriteLine("=== 초기 패 ===");
Console.WriteLine();
dealer.AddDcard(card.cardDraw());
dealer.AddDcard(card.cardDraw());
dealer.ShowDcard();
player.AddPcard(card.cardDraw());
player.AddPcard(card.cardDraw());
player.ShowPcard();



class Card
{
    int index1 = 0;
    int index2 = 0;

    public StringBuilder[,] cardImoge = new StringBuilder[4,13];
    
    public Card()
    {
        for (int i = 0; i < 4; i++)
        {
            
            for (int j = 0; j < 13; j++)
            {
                cardImoge[i,j] = new StringBuilder();
                if (i == 0)
                {
                    cardImoge[i, j].Append("◆");
                }
                else if (i == 1)
                {
                    cardImoge[i, j].Append("♥");
                }
                else if (i == 2)
                {
                    cardImoge[i, j].Append("♣");
                }
                else if (i == 3)
                {
                    cardImoge[i, j].Append("♠");
                }
                if (0 < j && j < 10)
                {
                    cardImoge[i, j].Append($"{j + 1}");
                }
                else if (j == 0)
                {
                    cardImoge[i, j].Append($"A");
                }

                else if (j == 10)
                {
                    cardImoge[i, j].Append($"J");
                }

                else if (j == 11)
                {
                    cardImoge[i, j].Append($"Q");
                }
                else if (j == 12)
                {
                    cardImoge[i, j].Append($"K");
                }
            }

        }
        cardImoge.ToString();
    }
    
    public string cardDraw()
    {
        

        string str = cardImoge[index1, index2].ToString();
        index2++;
        if (index2 == 12)
            index1++;
        return str;
    }
    public void cardShuffle() //Clear
    {
        Random r = new Random();
        int total = cardImoge.Length;
        for (int i = total-1; i > 0; i--)
        {
            int j = r.Next(i + 1);
            int x1 = i / 13;
            int y1 = i % 13;
            int x2 = j / 13;
            int y2 = j % 13;
            StringBuilder temp = cardImoge[x1, y1];
            cardImoge[x1, y1] = cardImoge[x2, y2];
            cardImoge[x2, y2] = temp;

        }
        Console.WriteLine("카드 섞는중 ....");
    }


}

class Player
{
    int i= 0;
    private string[] pcard = new string[8];
    public int pscore = 0;

    public Player()
    {

    }
    public void AddPcard(string pcards)
    {
        

        pcard[i] = pcards;
        i++;
    }
    public void ShowPcard()
    {
        Console.Write($"플레이어의 패:");
        for (int i = 0; i < pcard.Length; i++)
        {
            if(pcard[i] != null)
            {
                Console.Write($"[{pcard[i]}] ");
            }
            
        }
        Console.WriteLine();
    }

    public void TurnPlayer()
    {

        //if()///*H를 입력했을때*/
        //{

        //}
        //else if () ///*S를 입력했을때*/ 
        //{

        //}
    }

}

class Dealer
{
    private string[] dcard = new string[8];
    public int dscore = 0;
    int i = 0;
    public Dealer()
    {

    }

    public void AddDcard(string dcards)
    {
        
        dcard[i] = dcards;
        i++;
    }

    public void ShowDcard()
    {

        Console.Write($"딜러의 패: ");
        for (int i = 0; i < dcard.Length; i++)
        {
            if (i == 0)
            {
                Console.Write("[??] ");
            }
            else if(dcard[i] != null)
            {
                Console.Write($"[{dcard[i]}] ");
            }
            
        }
        Console.WriteLine();
        
    }

    public void TurnDealer()
    {
        //while( >17)
        //{

        //}
    }
}




