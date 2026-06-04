# The Unopened Escape

The Unopened Escape é um minijogo cooperativo e assimétrico de horror psicológico, desenvolvido para óculos de Realidade Virtual (Meta Quest) e integrado a uma interface mobile para smartphones. O jogo foi desenvolvido como projeto prático da disciplina Tópicos Especiais em Jogos Digitais – Turma 1 (2026/1), do curso de Engenharia de Software da Universidade de Brasília (UnB/FGA).

---

## 1. Links Importantes

* **Documento de Concepção (SGDD):** [Short Game Design Document - Google Docs](https://docs.google.com/document/d/19iKjf4_W0coSw6DeEdmJOn1mLrcc9Qn5BeEzh3aXI8o/edit?usp=sharing)
* **Entrega Final** [Demonstração The Unonped Escape - YouTube]()

---

## 2. Objetivos do projeto

* **Interface Assimétrica Total:** Implementar duas visões independentes de jogo (Realidade Virtual via Meta Quest e GUI/TUI via smartphone Android/iOS) rodando em cooperação simultânea;
* **Mecânicas sob Pressão:** Desenvolver um sistema dinâmico de temporizador e eventos randômicos de perturbação para desestabilizar a comunicação verbal do par de jogadores;
* **Rejogabilidade Dinâmica:** Modelar algoritmos de puzzles nas faces do cofre que alteram suas respostas com base em um ID/Número de Série randômico gerado no início de cada sessão;
* **Imersão em Horror Psicológico:** Estruturar um ecossistema sonoro tridimensional, utilizando áudios espaciais e feedback háptico analógico de engrenagens para guiar o fluxo cognitivo do jogador confinado.

---

## 2. Download e Instalação

O jogo é distribuído em formatos prontos para execução através da aba de Releases deste repositório. Não é necessário compilar o código fonte para jogar.

<!--

### 2.1. Obtenção dos Arquivos
1. Acesse a seção de **Releases** na barra lateral direita deste repositório no GitHub.
2. Baixe o arquivo executável `TheUnopenedEscape.apk` correspondente ao sistema de Realidade Virtual (Jogador 1).
3. Baixe o aplicativo mobile ou o arquivo consolidado `Manuais_Jogador2.pdf` (Jogador 2).
4. Faça a impressão dos cartões de suporte físico (disponibilizados no pacote de mídias da release).

### 2.2. Configuração do Jogador 1 (Ambiente VR)
1. Ative o modo de desenvolvedor em seu dispositivo Meta Quest.
2. Realize a instalação do arquivo `.apk` baixado utilizando uma ferramenta de sideload homologada (como o aplicativo SideQuest).
3. Certifique-se de que a área de segurança (Guardian) esteja configurada corretamente para interações estacionárias ou em pé.
4. Inicialize o jogo a partir do menu de "Fontes Desconhecidas" do headset.

### 2.3. Configuração do Jogador 2 (Ambiente de Suporte)
1. Abra o arquivo PDF dos manuais no smartphone/tablet ou utilize as vias impressas em papel.
2. Organize os cartões tangíveis sobre uma superfície plana na ordem numérica indicada para agilizar a consulta durante a partida.
-->

---

## 3. Como Jogar 

The Unopened Escape é uma experiência puramente cooperativa onde a comunicação verbal é a única ponte de conexão entre os participantes.

1. **Início e Autenticação:** O Jogador 1 iniciará retido na cadeira de ferro da Sala de Triagem (Área 1). Ele deve manipular fisicamente o cubo mecânico posicionado na mesa à sua frente para liberar o acesso inicial. Ao falhar, o sistema o transportará verticalmente para o Sótão (Área 2).
2. **Coleta do ID do Cofre:** Assim que o Jogador 1 avistar o cofre principal na Área 2, ele deve localizar o número de registro (ID do Cofre) fixado no chassi do objeto e ditá-lo claramente em voz alta para o Jogador 2.
3. **Decodificação Analógica:** O Jogador 2 utilizará o ID informado pelo parceiro para realizar o cruzamento de dados nas tabelas lógicas presentes nos manuais antigos. O ID altera completamente o gabarito de resolução de cada partida.
4. **Resolução dos Enigmas:** O Jogador 2 deve decifrar as regras lógicas de alinhamento de engrenagens, fios, botões ou chaves e instruir verbalmente o Jogador 1 sobre quais comandos aplicar no ambiente virtual.
5. **Gerenciamento do Tempo:** O teto de espinhos da Área 2 descerá continuamente. Cada puzzle resolvido incorretamente penaliza a dupla reduzindo o tempo restante da ampulheta. Os jogadores vencem ao desbloquear as cinco faces do cofre e obter a chave de liberação antes do esmagamento total.

---

## 4. Tecnologias Utilizadas
   
1. **Unity Engine:** Motor gráfico utilizado para simulação de física, renderização de materiais e controle de iluminação de horror.

2. **Linguagem C:** Programação orientada a componentes e tratamento lógico das mecânicas internas de validação.

3. **Meta Quest XR SDK:** Biblioteca para mapeamento posicional das mãos, interações de agarre (grab) e feedback háptico nos controles.

4. **Figma e Canva:** Ferramentas gráficas aplicadas na identidade visual, paleta rústica de cores e diagramação dos manuais digitais e impressos.

---

## 5. Integrantes do Grupo

<table border="1" style="border-collapse: collapse; width: 100%;">
  <tbody>
    <tr>
      <td align="center" style="padding: 10px;">
        <a href="https://github.com/zzzBECK">
          <img src="https://github.com/zzzBECK.png?size=120" width="120px;" alt="Alexandre de Santana Beck"/>
        </a>
        <br />
        <b>Alexandre de Santana Beck</b>
        <br />
        211061350
      </td>
      <td align="center" style="padding: 10px;">
        <a href="https://github.com/AGoretti">
          <img src="https://github.com/AGoretti.png?size=120" width="120px;" alt="André Goretti Motta"/>
        </a>
        <br />
        <b>André Goretti Motta</b>
        <br />
        160112028
      </td>
      <td align="center" style="padding: 10px;">
        <a href="https://github.com/LuisGFNunes">
          <img src="https://github.com/LuisGFNunes.png?size=120" width="120px;" alt="Luis Gustavo Ferreira Nunes"/>
        </a>
        <br />
        <b>Luis Gustavo Ferreira Nunes</b>
        <br />
        251012313
      </td>
      <td align="center" style="padding: 10px;">
        <a href="https://github.com/mateusaraujo2006">
          <img src="https://github.com/mateusaraujo2006.png?size=120" width="120px;" alt="Mateus Alves Araujo"/>
        </a>
        <br />
        <b>Mateus Alves Araujo</b>
        <br />
        251013624
      </td>
    </tr>
    <tr>
      <td align="center" style="padding: 10px;">
        <a href="https://github.com/bolzanMGB">
          <img src="https://github.com/bolzanMGB.png?size=120" width="120px;" alt="Othavio Araujo Bolzan"/>
        </a>
        <br />
        <b>Othavio Araujo Bolzan</b>
        <br />
        231039150
      </td>
      <td align="center" style="padding: 10px;">
        <a href="https://github.com/USERNAME">
          <img src="https://github.com/USERNAME.png?size=120" width="120px;" alt="Victor Hugo Rodrigues Guimarães"/>
        </a>
        <br />
        <b>Victor Hugo Rodrigues Guimarães</b>
        <br />
        211063256
      </td>
      <td align="center" style="padding: 10px;">
        <a href="https://github.com/Yanmatheus0812">
          <img src="https://github.com/Yanmatheus0812.png?size=120" width="120px;" alt="Yan Matheus SB de Aguiar"/>
        </a>
        <br />
        <b>Yan Matheus Santa Brigida de Aguiar</b>
        <br />
        231038303
      </td>
      <td align="center" style="padding: 10px;">
        <!-- célula vazia para completar a linha -->
      </td>
    </tr>
  </tbody>
</table>

