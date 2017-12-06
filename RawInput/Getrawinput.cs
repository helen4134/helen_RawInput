using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RawInput_dll;

namespace RawInputApp
{
    public static class Getrawinput
    {
        public static string CardAsync;
        public static string FilenameAsync;

        public static void GetCardinfo(string CardAsync)
        {
            string cardinfohead = "";
            string cardinfo = "";
            string cardend = "";

            if (int.TryParse(CardAsync.Substring(0, 1), out int n1))  //判斷第一碼是否為數字 4SD0D4 HD1D2
            {
                cardinfohead = CardAsync.Substring(1, 1);                //S
                cardinfo = CardAsync.Substring(2, CardAsync.Length - 2); //D0D4
            }
            else
            {
                cardinfohead = CardAsync.Substring(0, 1);                 //H
                cardinfo = CardAsync.Substring(1, CardAsync.Length - 1);  //D1D2
            }

            for (int i = 0; i < cardinfo.Length; i++)
            {
                if (int.TryParse(cardinfo.Substring(i, 1), out int n2))
                {
                    cardend = cardend + cardinfo.Substring(i, 1);
                }
            }
            cardend = cardinfohead + cardend;  //最後取得的卡號
            
            HttpPost.PostCard(cardend);
            Getrawinput.CardAsync = "";
            FilenameAsync = string.Format(@"Card\{0}", cardend + ".png");
            
        }
    }
}
