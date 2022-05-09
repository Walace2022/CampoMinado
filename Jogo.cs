using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoCampoMinado
{
    internal class Jogo
    {
        private string[,] real, visible;
        private int bomb;
        bool lose;

        public Jogo(int x, int y, int b)
        {
            real = new string[x, y];
            visible = new string[x, y];
            bomb = b;
        }

        public void Play()
        {
            int i = real.GetLength(0) * real.GetLength(1);
            int tempX, tempY;
            PrencherCampo();
            PosicionarBombas(bomb);
            EscreverCampo();

            do
            {
                Console.Write("Qual linha? ");
                tempX = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Qual Coluna?");
                tempY = int.Parse(Console.ReadLine()) - 1;
                VerificarBomba(tempX, tempY);
                EscreverCampo();
                i--;
            } while (!(lose || i ==bomb));

            string Fim = (lose) ? "Você Perdeu!!" : "Você Venceu!!";
            Console.WriteLine(Fim);
        }
        void PrencherCampo()
        {
            for (int i = 0; i < visible.GetLength(0); i++)
            {
                for (int j = 0; j < visible.GetLength(1); j++)
                {
                    visible[i, j] = "X";
                }

            }
        }

        void EscreverCampo()
        {
            Console.Clear();
            for (int i = 0; i < visible.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < visible.GetLength(1); j++)
                {

                    Console.Write(visible[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
        void PosicionarBombas(int x)
        {
            Random r = new Random();
            int i = 0;
            while (i < x)
            {
                int a = r.Next(0, real.GetLength(0));
                int b = r.Next(0, real.GetLength(1));
                if (real[a, b] != "B")
                {
                   real[a,b] = "B";
                    i++;
                }
                
            }
        }
        void VerificarBomba(int x, int y)
        {
            if (real[x, y] == "B")
            {
                lose = true;
                visible[x, y] = "B";
            }
            else
            {
                VerificarArredores(x, y);
            }
        }
        void VerificarArredores(int x, int y)
        {
            int count = 0;
            for (int i = 0; i < real.GetLength(0); i++)
            {
                for (int j = 0; j < real.GetLength(1); j++)
                {
                    if (i == x && j == y)
                    {
                        if (x > 0)
                        {
                            if (real[i - 1, j] == "B") { count++; }
                        }
                        if (y > 0)
                        {
                            if (real[i, j - 1] == "B") { count++; }
                        }
                        if (x > 0 && y > 0)
                        {
                            if (real[i - 1, j - 1] == "B") { count++; }
                        }
                        if (y < real.GetLength(1) - 1)
                        {
                            if (real[i, j + 1] == "B") { count++; }
                        }
                        if (x > 0 && y < real.GetLength(1) - 1)
                        {
                            if (real[i - 1, j + 1] == "B") { count++; }
                        }
                        if (x < real.GetLength(0) - 1)
                        {
                            if (real[i + 1, j] == "B") { count++; }
                        }
                        if (x < real.GetLength(0) - 1 && y > 0)
                        {
                            if (real[i + 1, j - 1] == "B") { count++; }
                        }
                        if (x < real.GetLength(0) - 1 && y < real.GetLength(1) - 1)
                        {
                            if (real[i + 1, j + 1] == "B") { count++; }
                        }
                    }



                }
                visible[x, y] = count.ToString();
            }

        }


    }
}
