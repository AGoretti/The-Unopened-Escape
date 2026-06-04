# Assets Necessários 

Seguindo os princípios do SGDD, a descrição de jogo foi mapeada em tarefas diretas de desenvolvimento divididas em Arte, Música e Sons, Hardware/TUI e Programação, formando um Backlock de Produção para guiar a produção de **The Unopened Escape**

---

## 1. Arte e Elementos Visuais

<br>
<p align="center">Tabela 1 - Assets de Arte</p>

| Elemento Visual | Categoria / Tipo | Descrição e Detalhes de Produção |
| :--- | :--- | :--- |
| **Tela de Loading** | Interface (UI) | Exibição do logotipo institucional da UnB, nomes dos estudantes e do professor. |
| **Tela de Recomendação** | Interface (UI) | Aviso inicial instruindo os usuários sobre o uso obrigatório/recomendado de fones de ouvido. |
| **Ambiente Quarto Inicial** | Cenário 3D | Quarto fechado, estilo horror psicológico, completamente sujo, degradado e sem janelas. |
| **Texturas do Quarto** | Texturização / PBR | Paredes descascadas/manchadas, piso sujo/envelhecido e teto com marcas de infiltrações. |
| **Cadeira de Ferro** | Modelo 3D / Prop | Modelo tridimensional de uma cadeira de ferro industrial envelhecida e enferrujada. |
| **Animação do Jogador Preso** | Animação | Animação do personagem imóvel acorrentado/preso (apenas cintura para baixo visível ao olhar para baixo). |
| **Mãos Virtuais** | Modelo 3D / Skin | Par de mãos em primeira pessoa com aparência machucada, ferida e suja. |
| **Mesa Desgastada** | Modelo 3D / Prop | Mesa de madeira velha e desgastada colocada à frente do jogador na Área 1. |
| **Cubo Mecânico** | Modelo 3D / Item | Dispositivo com barras de ferro nas arestas e faces preenchidas por botões, engrenagens e sliders. |
| **Material de Spotlight** | Iluminação / VFX | Efeito de iluminação cônica concentrada vinda diretamente de cima, destacando a mesa. |
| **Snap Magnético do Cubo** | Animação | Feedback visual sutil onde o cubo se alinha magneticamente à posição correta de interação. |
| **Botões do Cubo** | Interface (UI) | Arte gráfica dos botões texturizados de Autenticação, Configurações e Sair. |
| **Apagamento da Luz** | Animação / VFX | Transição gradual de diminuição da intensidade da iluminação da sala. |
| **Blackout Total** | Animação / VFX | Corte abrupto de luz para escuridão 100% no ambiente tridimensional. |
| **Escotilha do Teto** | Modelo 3D / Cenário | Comporta/escotilha mecânica de ferro no teto do quarto para transição de fases. |
| **Içamento da Cadeira** | Animação | Movimento mecânico vertical da cadeira de ferro sendo erguida em direção ao teto. |
| **Ambiente Sótão** | Cenário 3D | Espaço tridimensional claustrofóbico, escuro, degradado e sujo. |
| **Ratos** | Modelo 3D + Animação| Pequenos roedores com IA/Animação de corrida simples para transitar pelo chão do sótão. |
| **Cofre Rústico** | Modelo 3D / Prop | Cofre antigo de metal/madeira pesada colocado à frente do jogador na Área 2. |
| **Ampulheta Física** | Modelo 3D / Prop | Ampulheta tridimensional estilizada que funciona como o marcador de tempo da partida. |
| **Areia Escorrendo** | Animação / VFX | Efeito visual de partículas ou shader da areia caindo continuamente dentro da ampulheta. |
| **Teto Falso de Espinhos** | Modelo 3D / Cenário | Estrutura de teto móvel equipada com espinhos retráteis pontiagudos. |
| **Descida dos Espinhos** | Animação | Animação linear e progressiva do teto descendo em direção à cabeça do jogador. |
| **Luzes Piscando** | VFX / Iluminação | Script/Efeito visual de oscilação e mau contato nas lâmpadas para gerar distração. |
| **Chave Rústica** | Modelo 3D / Item | Objeto de inventário final (chave amarela antiga) usado para a libertação. |
| **Libertação do Personagem** | Animação | Animação em primeira pessoa das amarras se soltando e o personagem se levantando. |
| **Cena de Encontro Final** | Cenário / Evento | Espaço de transição onde o Jogador 1 (RV) visualiza e encontra o Jogador 2 após a fuga. |
| **Telas de Fim de Jogo** | Interface (UI) | Interfaces de Vitória e Derrota contendo os comandos funcionais "Jogar Novamente" e "Sair". |
| **Interface da Câmera (Mobile)**| Interface (UI) | Viewport ativa no aplicativo do celular para escanear os cards do ambiente real. |
| **Tela de Instruções (Mobile)** | Interface (UI) | Visualizador de documentos com estética de manuscrito ou páginas de diário antigo (estilo PDF). |
| **Botão Voltar (Mobile)** | Interface (UI) | Elemento de navegação clássico para retornar à tela anterior do aplicativo. |
| **Cards Físicos (TUI)** | Arte Impressa / TUI | Design das cartas de baralho físicas reais com grafismo místico/eldritch e área dedicada ao QR Code. |
| **Ilustrações dos Manuais** | Arte 2D | Desenhos misteriosos e anotações feitas à mão que compõem o conteúdo dos enigmas. |

<p align="center">Fonte: Autoria da Equipe do Grupo 1</a></p>

---

## 2. Música e Efeitos Sonoros

<br>
<p align="center">Tabela 2 - Assets de Música e Som</p>

| Efeito Sonoro | Categoria | Gatilho / Contexto de Execução |
| :--- | :--- | :--- |
| **Música de Horror Psicológico** | Trilha Sonora | Tocada de forma contínua apenas nas telas de menu e ambientação do quarto inicial. |
| **Rádio Antigo Chiando** | SFX Ambiente | Ruído branco de rádio analógico posicionado de forma espacializada no cenário 1. |
| **Goteiras** | SFX Ambiente | Som metálico e oco de gotas d'água caindo ritmicamente em poças ou baldes. |
| **Faíscas Elétricas** | SFX Ambiente | Som de curto-circuito sincronizado com as piscadas aleatórias de luz. |
| **Passos no Teto** | SFX Ambiente | Sons de passos pesados arrastando-se no sótão acima da cabeça do Jogador 1 na Área 1. |
| **Som de Sótão Claustrofóbico** | SFX Ambiente | Áudio contínuo de vento encanado em frestas de madeira e estalos estruturais. |
| **Ratos Correndo** | SFX Ambiente | Sons agudos de guinchos e garras arranhando a madeira do sótão. |
| **Engrenagens do Cubo** | SFX Interação | Ruído mecânico pesado de engrenagens de ferro se movendo ao interagir com o objeto. |
| **Feedback de Rotação** | SFX Interação | Som analógico estalado (*click*) a cada rotação bem-sucedida das engrenagens. |
| **Snap Magnético** | SFX Interação | Som de impacto metálico seco indicando que o cubo travou no local correto. |
| **Clique de Autenticação** | SFX Interação | Som pesado de botão mecânico industrial sendo pressionado até o fim. |
| **Ajuste de Sliders** | SFX Interação | Som de fricção metálica contínua enquanto o jogador arrasta os sliders mecânicos. |
| **Desligamento do Rádio** | SFX Evento | Som estalado de interrupção abrupta da energia do rádio da sala. |
| **Alarme Anti-Intruso** | SFX Evento | Alarme estridente, agudo e industrial disparado após a falha de autenticação. |
| **Comportas Fechando** | SFX Evento | Som metálico massivo de portões pesados batendo e trancando as saídas. |
| **Cadeira Arrastada** | SFX Evento | Som áspero de correntes e trilhos prendendo e puxando a cadeira de ferro para cima. |
| **Abertura/Fechamento da Escotilha**| SFX Evento | Ruído de trincos hidráulicos abrindo e fechando no teto da sala. |
| **Areia da Ampulheta** | SFX Contínuo | Som sutil e contínuo de grãos de areia batendo no vidro na Área 2. |
| **Aceleração da Areia** | SFX Punição | Aumento na velocidade/frequência do som de areia, indicando penalidade por erro. |
| **Mesa Balançando** | SFX Evento | Som de madeira batendo fortemente contra o piso de forma violenta. |
| **Entidade Oculta** | SFX Terror | Sussurros ininteligíveis e ruídos distorcidos de baixa frequência tocados nas laterais do áudio. |
| **Teto de Espinhos Descendo** | SFX Evento | Som contínuo de motores mecânicos ou correntes descendo a estrutura pesada de espinhos. |
| **Engrenagens Revertendo (Vitória)** | SFX Feedback | Som harmônico de mecanismos destravando e motores recolhendo o teto falso. |
| **Estruturas Quebrando (Derrota)**| SFX Feedback | Som violento de compressão, estilhaços de madeira e metal amassando no blackout. |
| **Blackout Abrupto** | SFX Evento | Som surdo de queda de energia geral instantânea. |
| **Trilha de Encerramento** | Trilha Sonora | Música específica para a tela final (melodia de alívio para Vitória / som fúnebre para Derrota). |

<p align="center">Fonte: Autoria da Equipe</a></p>

---

## 3. Hardware e Interfaces Tangíveis 

<br>
<p align="center">Tabela 3 - Assets de Hardware e TUI</p>

| Componente | Tipo de Elemento | Função e Requisito de Integração |
| :--- | :--- | :--- |
| **Cubo Físico Interativo** | Dispositivo Principal | Estrutura física real manipulada pelo Jogador 1 no mundo real/virtual. |
| **Engrenagens Físicas** | Componente Mecânico | Peças rotatórias acopladas às faces do cubo físico com leitura de rotação. |
| **Sliders Mecânicos** | Componente Mecânico | Potenciômetros deslizantes embutidos nas fendas do cubo para entrada de dados. |
| **Botões Físicos** | Componente Eletrônico | Chaves táteis e botões mecânicos integrados para envio de comandos de confirmação. |
| **Atração Magnética** | Mecanismo Físico | Ímãs ou travas físicas para simular o encaixe do cubo em superfícies. |
| **Sensor de Orientação** | Sensor Eletrônico | IMU (Giroscópio/Acelerômetro) para detectar a rotação e inclinação global do cubo. |
| **Leitor Numérico** | Firmware / Hardware | Sistema microcontrolado encarregado de traduzir a posição mecânica das peças em dados. |
| **Ampulheta Física Real** | Objeto Tangível | Dispositivo de contagem de tempo real na mesa de testes (se integrado ao hardware). |
| **Cartas Físicas Marcadas** | Mídia Física (TUI) | Cartas impressas contendo padrões visuais legíveis ou códigos QR específicos para cada enigma. |
| **Smartphone (Jogador 2)** | Dispositivo Mobile | Aparelho celular com módulo de câmera ativo executando o software do jogo. |
| **Módulo de Comunicação** | Infraestrutura / Rede | Protocolo de rede local (Wi-Fi/Bluetooth) ligando os sensores e o aplicativo móvel. |
| **Iluminação Sincronizada** | Atuador Externo | Atuadores de luz física na sala de testes para emular as piscadas e apagões (opcional). |
| **Áudio Espacializado** | Sistema de Saída | Algoritmo de áudio 3D (através de fones) para mapear a direção exata de goteiras e passos. |

<p align="center">Fonte: Autoria da Equipe do Grupo 1</a></p>

---

## 4. Programação

<br>
<p align="center">Tabela 4 - Assets de Programação</p>

| Módulo  | Funcionalidade Principal | Descrição Técnica do Escopo |
| :--- | :--- | :--- |
| **Gerenciador de Loading** | Core / UI | Inicializa a aplicação, gerencia o fluxo de créditos e renderiza a tela de onboarding de áudio. |
| **Game Loop e Cenas** | Core / Game State | Controla a máquina de estados principal do jogo, transitando entre Quarto, Sótão, Vitória e Derrota. |
| **Câmera em Primeira Pessoa** | Gameplay / VR | Mapeamento posicional da visão tridimensional do Jogador 1 através do headset. |
| **Restrição de Movimentos** | Gameplay / VR | Trava lógica da posição do jogador, permitindo apenas a movimentação da cabeça e das mãos de forma fixa. |
| **Mapeador de Interações** | Input / Sistema | Interpreta os dados vindos dos controles virtuais ou dos sensores físicos do cubo interativo. |
| **Lógica de Autenticação** | Mecânica / Puzzle | Processa a combinação enviada pelas engrenagens e valida a matriz numérica do enigma da Área 1. |
| **Validador de Senha** | Mecânica / Puzzle | Script verificador que engatilha o fluxo normal (sucesso) ou dispara a negação (credencial falsa). |
| **Gatilho Anti-Intruso** | Eventos / Scripting | Executa em sequência a animação da escotilha, tranca de portas, ativação do alarme e içamento da cadeira. |
| **Sincronizador de Animações** | Animação / Sistema | Garante que as rotações mecânicas, movimento de espinhos e comportamento dos ratos ocorram no tempo correto. |
| **Controlador de Luzes** | Visual / Scripting | Gerencia as curvas de intensidade de luz para o efeito de *fade out*, blecaute total e oscilação de lâmpadas. |
| **Motor de Áudio Espacial** | Áudio / Engine | Modula o ganho, atenuação e pan dos efeitos sonoros com base na posição da cabeça do jogador em RV. |
| **Lógica dos Puzzles do Sótão** | Mecânica / Puzzle | Algoritmo que gerencia os estados lógicos das diferentes faces do cubo e sua ligação com o cofre. |
| **Temporizador (Ampulheta)** | Mecânica / Core | Cronômetro regressivo mestre em float sincronizado com a animação de escorrimento da areia e descida do teto. |
| **Gerenciador de Perturbações** | Eventos / Scripting | Motor aleatório (*Random*) que sorteia o intervalo e executa eventos visuais e sonoros de distração no cenário. |
| **Sistema de Punição** | Mecânica / Feedback | Lógica que reduz instantaneamente o tempo restante (acelera a ampulheta) caso o jogador insira um código errado. |
| **Subsistema de Rede** | Conectividade | Arquitetura Cliente-Servidor (ou P2P local) para trafegar dados de status e o número de série do cofre em tempo real. |
| **Decodificador de QR Code** | Mobile / Visão Computacional| Integração com a câmera do celular para capturar, extrair a string do código impresso e mapear o ID da carta. |
| **Renderizador de Manuais** | Mobile / UI | Sistema de UI dinâmica no celular que carrega e exibe o documento correspondente à carta escaneada. |
| **Máquina de Fim de Jogo** | Core / Game Loop | Interrompe o gameplay ao detectar tempo esgotado (Derrota) ou cofre aberto (Vitória). |
| **Lógica de Reset Mestre** | Core / Game Loop | Limpa todas as variáveis da partida, zera os puzzles, gera um novo número de série e reinicia o fluxo completo ao clicar em reiniciar. |

<p align="center">Fonte: Autoria da Equipe do Grupo 1</a></p>