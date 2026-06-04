# Descrição do Jogo


Esta seção apresenta o **Jogo Mental** da aplicação. Trata-se de uma descrição puramente linear, cronológica e contínua que mapeia a experiência do início ao fim. Esse processo permite que a equipe simule e valide a jornada do usuário, a curva de tensão e a árvore de interações mentalmente, servindo como base direta para a extração do **backlog de assets**.

---

## 1. Áreas
### 1.1 Área 1
O jogo se inicia com uma tela de `loading` que exibe o logotipo da `UnB`, os nomes dos estudantes e do professor envolvido no projeto, seguida por uma recomendação expressa para o uso de fones de ouvido.

Em seguida, o **Jogador 1** é introduzido a um quarto que possui temática de **horror psicológico** com realismo sombrio e sujo, tendo como característica principal o fato de ser pequeno, degradado e escuro (sem janelas). A trilha sonora consiste em uma música ambiente e agonizante, proveniente de um rádio velho jogado em cima de uma mesa de madeira desgastada, que é acompanhada por barulhos constantes de goteiras, faíscas elétricas e passos fortes vindos do teto.

Dentro desse quarto, o jogador encontra-se completamente preso e imóvel. Ao olhar para baixo, ele percebe que está amarrado pelas pernas e pela cintura a uma grande cadeira de ferro enferrujada, sendo possível enxergar apenas da cintura para baixo do seu corpo. Suas mãos virtuais são flutuantes, apresentando uma aparência levemente ferida e suja.

Na frente do jogador, há uma mesa que possui em seu centro um **cubo mecânico** que é banhado por uma luz estilo `spotlight` natural vinda de cima. Ele possui barras de ferro estendidas em suas arestas que o jogador utiliza para manipular sua posição nas mãos. Quando solto, o cubo retorna para um apoio de metal que simula atração magnética, realizando um `snap` automático na posição da face que estiver mais próxima dos olhos do usuário. 

Para avançar, o jogador precisa interagir com o cubo, que funciona como a interface de autenticação do casarão e possui um feedback sonoro de mecanismo analógico antigo. Ele traz os seguintes botões em suas faces:

- **Botão de Autenticação:** Permite que o jogador selecione uma combinação de dois números ao girar engrenagens mecânicas que aumentam ou diminuem os valores. Após ajustar os números, ele clica no botão para confirmar a senha de acesso.
- **Botões de Configurações**: Permitem que o jogador ajuste as opções de luz, som e música através de `sliders` mecânicos no próprio cubo. 
- **Botão de Sair:** Ao ser apertado, a luz do `spotlight` se apaga devagar e o rádio velho na mesa começa a chiar intensamente até desligar, deixando o jogador em um `blackout` total e silêncio absoluto por 2 segundos antes do aplicativo fechar.

Ao pressionar o botão de **Autenticar**, o sistema reconhece a credencial como falsa e aciona imediatamente o **Protocolo Anti-Intruso**: um alarme estridente é disparado, as comportas de ferro se fecham e a cadeira é arrastada mecanicamente através de uma escotilha no teto, elevando o jogador para o sótão da mansão.

### 1.2. Área 2

Ao chegar ao topo, a escotilha se fecha e o personagem, inicialmente ofuscado pela mudança repentina de iluminação, vai recuperando a visão aos poucos. Ele emerge no sótão, um ambiente claustrofóbico, sujo e infestado por ratos que correm pelo chão. A disposição é semelhante à anterior, com uma mesa ao centro, mas agora há um **cofre rústico** à sua frente.

O cofre possui em suas faces, invez das opções de menu que haviam no cubo mecânico, os **puzzles** necessários para escapar da mansão. Nesse momento, uma ampulheta física no canto da mesa começa a escorrer a areia, iniciando a contagem de tempo, e o teto falso, repleto de espinhos retráteis pontiagudos, começa a descer lentamente em direção à cabeça do jogador.

No decorrer da partida, eventos aleatórios criados para gerar desconforto e quebrar a comunicação entre os jogadores começam a acontecer, como luzes piscando agressivamente, barulhos altos e manifestações de uma entidade oculta na escuridão. Ao errar um puzzle, o jogador sofre punições: a mesa balança violentamente e ecoa um som de areia desabando, indicando uma perda considerável no tempo restante da ampulheta, apressando a descida dos espinhos.

---

## 2. Desfechos e Fim de Jogo

Há duas possibilidades: 

### 2.1 Vitória

Alcançada através da resolução correta de todos os puzzles do cubo. Ao decifrar o enigma final a tempo, há um barulho analógico de engrenagens, indicando que o teto pontiagudo parou de descer e que começará a subir novamente, e o cofre se abre com um estalo metálico, revelando uma **chave rústica desgastada e pintada de amarelo**. O **Jogador 1** deve pegá-la com as mãos virtuais e inseri-la na fechadura da própria cadeira para abrir as travas que o prendem. Uma animação em primeira pessoa com sons abafados e de coisas quebrando é iniciada, mostrando o personagem se libertando e se encontrando com o **Jogador 2** e fugindo da mansão. A tela de fim de jogo surge parabenizando os jogadores, com as opções de `Jogar Novamente` ou `Sair`.

### 2.2 Derrota

Caso o tempo da ampulheta zere antes da abertura do cofre, o mecanismo trava permanentemente. Inicia-se uma animação onde o teto de espinhos atinge o limite e esmaga o personagem. Os sons do ambiente tornam-se subitamente abafados e misturam-se a ruídos de estruturas quebrando, simulando a morte do intruso. O `blackout` é imediato, seguido pela tela de fim de jogo com as opções de `Jogar Novamente` ou `Sair`.

---

## 3. Experiência do Jogador 2 

Para o segundo jogador, localizado no perímetro externo da mansão, o aplicativo se inicia com a mesma tela de `loading` exibindo o logotipo institucional da `UnB`. Em seguida, a interface ativa a câmera do smartphone com a instrução visualizada na tela: `“Aponte o QR Code das instruções”`, centralizada por uma marcação gráfica.

Ao apontar a câmera para os marcadores presentes nas cartas físicas (as pastas confidenciais que ele roubou do escritório principal antes de fugir), o aplicativo identifica o código e abre um documento fixo na tela, similar a um `PDF`. Este documento é totalmente estilizado com a temática do horror psicológico, assemelhando-se a um manual de instruções velho, com anotações corridas feitas à mão e ilustrações misteriosas.

Cada carta física possui uma estética eldritchiana e mítica, carregando os dados cruciais para desvendar um tipo específico de puzzle do cubo. O **Jogador 2** utiliza o botão `"Voltar"` no topo da tela para retornar à câmera sempre que precisar escanear uma nova carta, dependendo inteiramente de sua comunicação verbal clara e rápida para ditar as respostas e salvar seu parceiro no sótão.