namespace JewelCollector;
/// <summary>
    /// A classe Map implementa o espaço virtual através do qual o robô se locomove. Ela armazena todas as informações dos elementos do mapa.
/// </summary>
public class Map
{
    /// <summary>
        /// Armazena a dimensão do mapa, que se inicia com tamanho igual 10x10 na primeira fase, e incrementando 1 un. a cada nova rodada (e.g. Rodada 2 - 11x11, Rodada 3 - 12x12 etc.).
    /// </summary>
    public int Dimension { get; set; }

    /// <summary>
        /// A matrix é um array de duas dimensões, e armazena objetos do tipo Entity. Desse modo, como todos os elementos do mapa herdam de Entity, o mapa consegue acomodar Jewel, OpenSpace, Robot, Radioactive e Obstacle.
    /// </summary>
    public Entity[,] matrix = new Entity[10, 10];

    /// <summary>
        /// O mapa mantém uma contagem de quantas joias ainda estão espalhadas. Quando Jewels = 0, uma nova matriz é criada.
    /// </summary>
    public int Jewels { get; set; }

    /// <summary>
        /// O construtor de Map atribui espaços vazios (OpenSpace) a todos os índices de sua matriz quando Map é inicializado.
    /// </summary>
    public Map() {

        Dimension = 10;
        
        for ( int i = 0; i < 10; i++) {
            for (int j = 0; j < 10; j++) {
                matrix[i, j] = new OpenSpace(); 
            }
        }
        this.Jewels = 0;
    }

    /// <summary>
        /// A função draw() imprime a matrix de Map no console. Um sistema de cores é utilizado para facilitar a visualização do mapa e de seus elementos.
    /// </summary>
    public void draw(){
        Console.Clear();
        for (int i = 0; i < Dimension; i++)
        {
            for (int j = 0; j < Dimension; j++)
            {
                if (matrix[i, j].GetType() == typeof(Robot)) 
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(matrix[i, j]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (matrix[i, j].GetType() == typeof(JewelBlue))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(matrix[i, j]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (matrix[i, j].GetType() == typeof(JewelRed))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(matrix[i, j]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (matrix[i, j].GetType() == typeof(JewelGreen))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(matrix[i, j]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (matrix[i, j].GetType() == typeof(Tree))
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(matrix[i, j]);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (matrix[i, j].GetType() == typeof(Water))
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(matrix[i, j]);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (matrix[i, j].GetType() == typeof(Radioactive))
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(matrix[i, j]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write(matrix[i, j]);
                }
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    /// <summary>
        /// A função newMap() cria um novo mapa baseado na propriedade Dimensão do próprio objeto. Quando o jogador avança uma fase, a dimensão aumenta em uma unidade. Esta função apenas preenche o mapa com espaços vazios. 
    /// </summary>
    public void newMap()
    { 
        matrix = new Entity[Dimension, Dimension];
        for (int i = 0; i < Dimension; i++)
        {
            for (int j = 0; j < Dimension; j++)
            {
                matrix[i, j] = new OpenSpace();
            }
        }
    }

    /// <summary>
        /// A função insertEntity insere um elemento do jogo (obstáculo ou jóia) na coordenada especificada. Além disso, se a entidade adicionada for uma joia, a propriedade Jewels recebe incremento de uma unidade.
    /// </summary>
    /// <param name="i">Especifica a coordenada x da matrix de Map</param>
    /// <param name="j">Especifica a coordenada y da matrix de Map</param>
    /// <param name="e">Especifica a entidade a ser inserida (Tree, Water ou Jewel)</param>
    public void insertEntity(int i, int j, Entity e){
        matrix[i, j] = e; 

        if (e.GetType() == typeof(JewelBlue) ||
            e.GetType() == typeof(JewelRed) ||
            e.GetType() == typeof(JewelGreen))
        {
            this.Jewels++;
        }
    }

    /// <summary>
        /// A função removeJewel retira uma joia do mapa, inserindo um espaço vazio em seu lugar e subtraindo 1 do contador de joias.
    /// </summary>
    /// <param name="x">Especifica a coordenada x da joia em Map</param>
    /// <param name="y">Especifica a coordenada y da joia em Map</param>
    public void removeJewel(int x, int y)
    {
        matrix[x, y] = new OpenSpace();
        Jewels--;
    }

    /// <summary>
        /// Esta função imprime uma mensagem de vitória para o jogador.
    /// </summary>
    public void youWin()
    {
        Console.WriteLine();
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("=-=-=-=- CONGRATULATIONS! YOU WIN! -=-=-=-=");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
    }

    /// <summary>
        /// Esta função imprime uma mensagem de derrota para o jogador.
    /// </summary>
    public void youLose()
    {
        Console.WriteLine();
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("=-=-=-=- GAME OVER! YOU LOSE! -=-=-=-=");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
    }
}
