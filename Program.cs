namespace JogoCampoMinado
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Quantas Linhas? ");
            int tempX = int.Parse(Console.ReadLine());
            Console.Write("Quantas Colunas? ");
            int tempY=int.Parse(Console.ReadLine());
            Console.Write("Quantas Bombas? ");
            int tempB = int.Parse(Console.ReadLine());

            Jogo J = new Jogo(tempX, tempY, tempB);
            J.Play();
        
        
        }
    }
}