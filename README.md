# ProjetoFinal_C

Nesse repositório foi desenvolvido um minigame chamado Jewel Collector utilizando a linguagem C#. O objetivo desse jogo é que um robô, controlado pelo teclado, se desloque por um mapa 2D de modo a desviar dos obstáculos e coletar todas as joias.

**Descrição do Projeto**

### **Parte 1**

Desenvolva o minigame chamado Jewel Collector. O objetivo desse jogo é que um robô, controlado pelo teclado, se desloque por um mapa 2D de modo a desviar dos obstáculos e coletar todas as joias. Para isso, as seguintes classes devem ser criadas:

* Jewel.cs - A classe Jewel deverá armazenar as informações da joia, como a posição (x, y) no mapa e o tipo, que poderá ser Red, no valor de 100 pontos; Green, no valor de 50 pontos; e Blue, no valor de 10 pontos.

* Obstacle.cs - A classe Obstacle deverá armazenar as informações do obstáculo, que será a posição (x, y) e o tipo. Cada obstáculo deverá possuir um tipo, que poderá ser Water ou Tree.

* Robot.cs - A classe Robot deverá ser responsável por armazenar as informações do robô, que será a posição (x, y) e uma sacola (bag), em que o robô colocará as joias coletadas no mapa. Além disso, a classe Robot deverá implementar os métodos para que o robô possa interagir com o mapa, isto é, deslocar-se nas quatro direções e coletar as joias. Além disso, implemente um método para imprimir na tela o total de joias armazenadas na sacola e o valor total.

* Map.cs - A classe Map deverá armazenar as informações do mapa 2D e implementar métodos para adição e remoção de joias e obstáculos. Além de um método para imprimir o mapa na tela. A impressão do mapa deverá seguir a seguinte regra: Robo será impresso como ME; Joias Red, como JR; Joias Green, como JG; Joias Blue, como JB; Obstáculos do tipo Tree, como $$; Obstáculos do tipo Water, como ##; Espaços vazios, como --.

* JewelCollector.cs - A classe JewelCollector deverá ser responsável por implementar o método Main(), criar o mapa, inserir as joias, obstáculos, instanciar o robô e ler os comandos do teclado. Para que o usuário possa controlar o robô, os seguintes comandos deverão ser passados através das teclas w, s, a, d, g. Sendo que a tecla w desloca o robô para o norte, a tecla s desloca para o sul, a tecla a desloca para oeste e a tecla d para leste. Para coletar uma joia, use a tecla g.

Uma joia somente poderá ser coletada se o robô estiver em uma das posições adjacentes a ela. Todos os obstáculos são intransponíveis. Para cada comando executado pelo usuário, imprima o estado atual do mapa, bem como o estado da sacola do robô.

Observação: Caso julgue necessário para uma melhor estruturação do código, é permitido criar classes adicionais.

Fluxo de Execução

- Crie um mapa com dimensão 10x10

- Crie e insira as joias de acordo com o tipo e posição (x, y) abaixo:

Red - (1, 9)

Green - (7, 6)

Blue - (2, 1)

- Crie e insira os obstáculos de acordo com o tipo e posição (x, y) abaixo:

Water - (5, 0)

Tree - (5, 9)

- Crie o robô na posição (x, y) = (0, 0).

- Inicie o jogo, isto é, leia o teclado e colete todas as joias e desvie dos obstáculos interativamente.


### **Parte2**

Desenvolva o minigame Jewel Collector 2.0, implementado previamente na aula 2. O objetivo dessa nova versão é melhorar o código anterior através da implementação dos novos conceitos e recursos aprendidos até o momento. Cada classe deve estar em um arquivo separado, com o nome NomedaClasse.cs. Particularmente, os seguintes recursos DEVEM NECESSARIAMENTE ser utilizados:

* Devem ser usados, tanto arrays como alguma instância de uma Collection (a seu critério)
* Mecanismo de Eventos para captura dos eventos de teclado e visualização do mapa no console
* Geração de Documentação Automática: Todas as classes, os métodos públicos das classes utilizadas, bem como os fields públicos devem ser comentados e incluídos na documentação gerada.

Note que o uso de polimorfismo se fará necessário, pois a variável map precisará armazenar os diversos tipos de objetos. Dica: Para escrever o objeto na tela, sobrescreva a método ToString em cada classe.

Lembrando que as joias serão do tipo Red, valor de 100 pontos, símbolo JR; Green, no valor de 50 pontos, símbolo JG; e Blue, no valor de 10 pontos, símbolo JB. Obstáculos serão do tipo Water com símbolo ##, ou Tree com símbolo $$. Espaços vazio com o símbolo --. Robô com o símbolo ME.

Nesta versão do jogo, o robô inicia com 5 pontos de energia e poderá se deslocar nas quatro direções. A cada deslocamento, ele perde 1 ponto de energia. Quando chegar a zero, o robô não poderá se mover mais; e o jogo termina.

O robô interage com o ambiente podendo usar os itens no mapa quando ele estiver em posições adjacentes a estes itens. O efeito do uso depende das características do item. Alguns poderão ser coletados (collect), sendo assim removidos do mapa e guardados na sacola do robô. Outros poderão ser usados pelo robô para recarregar (recharge) sua energia. Para usar (coletar/recarregar) um item, use a tecla g.

Os itens Tree e Blue Jewel fornecerão energia para o robô. Tree fornecerá 3 pontos de energia, enquanto que Blue Jewel fornecerá 5 pontos. Todas as joias serão coletadas após o uso. Utilize o conceito de interface para realizar essas ações.

Implemente também exceções para tratar os seguintes casos:

- robô tenta se deslocar para uma posição fora dos limites do mapa;
- robô tenta se deslocar para uma posição ocupada por outro item;
- outras situações que achar pertinente o uso de exceções.

As joias e os obstáculos são intransponíveis. Para cada comando executado pelo usuário, imprima o estado atual do mapa, a energia do robô, bem como o estado da sacola do robô.

Quando todas as joias forem coletadas, o jogo avança para a fase seguinte. No qual novas joias e obstáculos serão aleatoriamente posicionados no mapa. A cada nova fase, o mapa aumenta suas dimensões em 1 unidade, até o limite máximo de (30, 30) unidades. A quantidade de itens deverá aumentar proporcionalmente ao tamanho do mapa.

A partir da fase 2, teremos um elemento radioativo, símbolo !!, que retirará 10 pontos de energia, caso o robô passe em posições adjacentes. No entanto, este elemento será transponível. Caso o robô o transponha, perderá no mínimo 30 pontos de energia e o elemento radioativo desaparecerá do mapa.

Observação: O que não estiver especificado, fica a critério do desenvolvedor.
Implemente o mapa como uma matriz de items (jewels, obstacles, demais elementos mostrados no mapa). Seu código deverá imprimir o mapa de forma simples
