# Lógica dos Puzzles do Cofre

Esta seção documenta a especificação técnica e o fluxo lógico de cada um dos enigmas integrados ao cofre do jogo.

---

## 1. Mecânica de ID do Cofre

Cada partida gerará um cofre com um ID diferente exibido em sua face frontal. O cubo possuirá 5 puzzles, um para cada face restante, e a resolução de alguns deles dependerá obrigatoriamente do cruzamento de dados entre os manuais e este ID gerado pelo sistema.

---

## 2. Especificações dos Puzzles

<!-- somente alguns puzzles vao depender do id, nao todos-->

### 2.1 Puzzle dos Fios e Portas

**Descrição Geral:**
  Puzzle onde o Jogador 1 precisa conectar cabos em portas. Essa face do cofre apresenta 5 cabos desgastados e 8 portas de conexão que devem ser configuradas na ordem correta de acordo com as instruções do Jogador 2.

**Dependência do ID do Cofre:** (x) Sim  ( ) Não
  * O ID do cofre determina a configuração correta dos cabos nas portas, sendo necessário consultá-lo em cada etapa das regras.

**Funcionamento Técnico:**
  No VR (Jogador 1): A face do cofre apresenta 5 cabos desgastados:
  - Azul
  - Vermelho
  - Amarelo
  - Preto
  - Azul

  e 8 portas de conexão. O jogador pluga os cabos conforme as instruções recebidas do Jogador 2.

  No Manual (Jogador 2): O Jogador 2 solicita o ID do cofre ao Jogador 1 e aplica as regras na ordem estrita para determinar onde cada cabo deve ser conectado.

**Regras e Condições:**
  As regras devem ser seguidas na ordem estrita abaixo. Três portas deverão obrigatoriamente terminar vazias.

  1. **Regra 1 — Cabo Vermelho:**
     - Se o último dígito do ID for par: conecte o cabo Vermelho na Porta 8.
     - Se o último dígito do ID for ímpar: conecte o cabo Vermelho na Porta 1.

  2. **Regra 2 — Cabo Preto:**
     Some todos os 4 dígitos do ID do cofre.
     - Se a soma for maior que 15: o cabo Preto vai na Porta 4.
     - Se a soma for 15 ou menor: o cabo Preto vai na Porta 5.

  3. **Regra 3 — Cabos Azuis (Redundância):**
     Os dois cabos azuis são idênticos; a ordem física entre eles não importa.
     - Se o ID possuir o número "0" ou "7" em qualquer posição: conecte os dois cabos azuis em portas adjacentes (lado a lado) que estejam vazias, escolhendo as portas de número mais alto disponíveis.
     - Caso contrário: conecte um cabo azul na Porta 2 e o outro na Porta 7.

  4. **Regra 4 — Cabo Amarelo (VLAN de Segurança):**
     O cabo Amarelo nunca pode ser conectado em uma porta imediatamente ao lado do cabo Preto. Conecte-o na porta de número mais baixo que ainda estiver vazia e que cumpra essa restrição.

  5. **Regra 5 — Falha de Tensão (Exceção Crítica):**
     Se, após aplicar as regras de 1 a 4, a Porta 3 e a Porta 6 estiverem ambas ocupadas, o circuito entrará em curto. O Jogador 1 deve remover o Cabo Preto imediatamente e deixá-lo desconectado (o puzzle será concluído com 4 portas ocupadas e 4 vazias).

---

### 2.2 Puzzle dos Símbolos Eldritch

**Descrição Geral:**
  Uma face do cofre exibe símbolos estranhos e místicos (olho, espiral, triângulo, lua, mão, chave, rato, vela, entre outros). O jogador no VR precisa pressionar os símbolos na ordem correta, que varia conforme a combinação de símbolos presentes. A estética remete a manuais antigos e ocultistas, combinando com o tema misterioso do jogo.

**Dependência do ID do Cofre:** ( ) Sim  (x) Não
  * A ordem dos símbolos é determinada pelas regras do manual, não pelo ID do cofre.

**Funcionamento Técnico:**
  No VR (Jogador 1): Uma face do cofre exibe um subconjunto dos símbolos disponíveis. O jogador os pressiona em sequência tocando cada um.

  No Manual (Jogador 2): O Jogador 2 possui uma tabela de regras de prioridade que define a ordem correta de ativação com base nos símbolos presentes.

**Regras e Condições:**
  1. Se houver símbolo de olho e de vela, pressione primeiro a vela.
  2. Se houver lua, ela sempre vem antes da chave.
  3. Se houver rato, ele nunca pode ser o último.
  4. O símbolo com mais pontas deve ser pressionado por último.

---

### 2.3 Puzzle dos Sons Metálicos

**Descrição Geral:**
  Uma face do cofre emite uma sequência de sons metálicos, como batidas curtas, batidas longas e pausas. O Jogador 1 precisa ouvir a sequência e descrevê-la ao Jogador 2, que consulta o manual para traduzir os sons em uma ordem de símbolos ou botões.

**Dependência do ID do Cofre:** ( ) Sim  (x) Não
  * A solução depende apenas do padrão sonoro emitido pelo cofre e da tabela de tradução presente no manual.

**Funcionamento Técnico:**
  No VR (Jogador 1): O jogador ouve uma sequência de batidas emitidas pelo cofre e precisa informar ao Jogador 2 o padrão percebido.

  No Manual (Jogador 2): O Jogador 2 possui uma tabela que associa cada tipo de som a um símbolo ou ação.

**Regras e Condições:**
  1. Uma batida longa representa o símbolo da lua.
  2. Duas batidas curtas representam o símbolo da chave.
  3. Três batidas rápidas representam o símbolo do olho.
  4. Uma pausa longa indica troca de símbolo.
  5. Se a sequência terminar com batida longa, o último símbolo deve ser pressionado primeiro.
  6. Se houver duas pausas seguidas, ignore o próximo som.

---

### 2.4 Puzzle das Alavancas Mecânicas

**Descrição Geral:**
  Uma face do cofre apresenta um conjunto de alavancas antigas, cada uma podendo ser posicionada para cima, para o meio ou para baixo. O Jogador 1 precisa posicionar todas as alavancas corretamente para liberar uma das travas do cofre. A solução depende da interpretação das regras do manual pelo Jogador 2.

**Dependência do ID do Cofre:** (x) Sim  ( ) Não
  * A posição correta das alavancas é determinada por características do ID do cofre, como paridade, presença de certos números e comparação entre os dígitos.

**Funcionamento Técnico:**
  No VR (Jogador 1): O jogador visualiza quatro alavancas na face do cofre. Cada alavanca pode ser movida entre três posições: cima, meio e baixo. Após posicioná-las, ele pressiona um botão para validar a configuração.

  No Manual (Jogador 2): O Jogador 2 consulta uma tabela que define a posição correta de cada alavanca com base no ID informado pelo Jogador 1.

**Regras e Condições:**
  1. Se o ID terminar em número par, a primeira alavanca fica para cima.
  2. Se o ID terminar em número ímpar, a primeira alavanca fica para baixo.
  3. Se o ID possuir o número 8, a segunda alavanca fica no meio.
  4. A terceira alavanca deve ficar na posição oposta da primeira.
  5. Se algum dígito do ID for maior que 6, a quarta alavanca fica para baixo.

---

### 2.5 Puzzle dos Perfis de Segurança

**Descrição Geral:**
  Uma face do cofre exibe símbolos místicos que devem ser pressionados em uma ordem correta. Porém, antes de aplicar as regras do manual, o Jogador 2 precisa identificar o Perfil de Segurança ativo a partir do último dígito do ID do cofre. Cada perfil altera a forma como as regras devem ser interpretadas.

**Dependência do ID do Cofre:** (x) Sim  ( ) Não
  * O ID do cofre não define diretamente a resposta, mas determina qual perfil de regras deve ser usado.

**Funcionamento Técnico:**
  No VR (Jogador 1): O jogador visualiza o ID do cofre e os símbolos presentes na face do puzzle. Ele informa o ID e descreve os símbolos ao Jogador 2. Depois, pressiona os símbolos na ordem indicada.

  No Manual (Jogador 2): O Jogador 2 consulta o último dígito do ID para descobrir o perfil ativo. Em seguida, aplica as regras do perfil sobre os símbolos informados pelo Jogador 1.

**Regras e Condições:**
  1. Se o último dígito do ID for 0 ou 1, use o **Perfil Padrão**: siga as regras normalmente.
  2. Se o último dígito do ID for 2 ou 3, use o **Perfil Invertido**: descubra a sequência correta e depois inverta a ordem.
  3. Se o último dígito do ID for 4 ou 5, use o **Perfil de Prioridade**: símbolos considerados mais importantes vêm primeiro.
  4. Se o último dígito do ID for 6 ou 7, use o **Perfil de Mentira**: ignore regras que usam a palavra "sempre".
  5. Se o último dígito do ID for 8 ou 9, use o **Perfil de Sacrifício**: o símbolo mais perigoso deve ser pressionado por último.
