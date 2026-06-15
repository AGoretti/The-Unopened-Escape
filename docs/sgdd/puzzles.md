# Lógica dos Puzzles do Cofre

Esta seção documenta a especificação técnica e o fluxo lógico de cada um dos enigmas integrados ao cofre do jogo.

---

## 1. Mecânica de ID do Cofre

Cada partida gerará um cofre com um ID diferente exibido em sua face frontal. O cubo possuirá 5 puzzles, um para cada face restante, e a resolução de alguns deles dependerá obrigatoriamente do cruzamento de dados entre os manuais e este ID gerado pelo sistema.

---

## 2. Especificações dos Puzzles

<!-- somente alguns puzzles vao depender do id, nao todos-->

### 2.1 Puzzle 1

**Descrição Geral:**
  _Descreva o conceito visual e temático deste puzzle aqui._

**Dependência do ID do Cofre:** ( ) Sim  ( ) Não
  * _Se sim, como o ID afeta o resultado?_

**Funcionamento Técnico:**
  _Como o jogador interage com ele no VR/Físico? O que ele precisa acionar ou mover?_

**Regras e Condições:**
  1. Regra 1...
  2. Regra 2...



---

### 2.2 Puzzle dos Símbolos Eldritch

**Descrição Geral:**
  Uma face do cofre exibe símbolos estranhos e místicos (olho, espiral, triângulo, lua, mão, chave, rato, vela, entre outros). O jogador no VR precisa pressionar os símbolos na ordem correta, que varia conforme a combinação de símbolos presentes. A estética remete a manuais antigos e ocultistas, combinando com o tema misterioso do jogo.

**Dependência do ID do Cofre:** ( ) Sim  (x) Não
  * _A ordem dos símbolos é determinada pelas regras do manual, não pelo ID do cofre._

**Funcionamento Técnico:**
  No VR (Jogador 1): Uma face do cofre exibe um subconjunto dos símbolos disponíveis. O jogador os pressiona em sequência tocando cada um.

  No Manual (Jogador 2): O Jogador 2 possui uma tabela de regras de prioridade que define a ordem correta de ativação com base nos símbolos presentes.

  **Fluxo de comunicação:**
  - Jogador 1: "Estou vendo olho, vela, lua e chave."
  - Jogador 2 consulta o manual e responde: "Vai em vela, lua, chave e olho."

**Regras e Condições (exemplos):**
  1. Se houver símbolo de olho e de vela, pressione primeiro a vela.
  2. Se houver lua, ela sempre vem antes da chave.
  3. Se houver rato, ele nunca pode ser o último.
  4. O símbolo com mais pontas deve ser pressionado por último.



---

### 2.3 Puzzle 3

**Descrição Geral:**
  _Descreva o conceito visual e temático deste puzzle aqui._

**Dependência do ID do Cofre:** ( ) Sim  ( ) Não
  * _Se sim, como o ID afeta o resultado?_

**Funcionamento Técnico:**
  _Como o jogador interage com ele no VR/Físico? O que ele precisa acionar ou mover?_

**Regras e Condições:**
  1. Regra 1...
  2. Regra 2...

**Dependência do ID do Cofre:** ( ) Sim  ( ) Não
  * _Se sim, como o ID afeta o resultado?_

---

### 2.4 Puzzle 4

**Descrição Geral:**
  _Descreva o conceito visual e temático deste puzzle aqui._

**Dependência do ID do Cofre:** ( ) Sim  ( ) Não
  * _Se sim, como o ID afeta o resultado?_

**Funcionamento Técnico:**
  _Como o jogador interage com ele no VR/Físico? O que ele precisa acionar ou mover?_

**Regras e Condições:**
  1. Regra 1...
  2. Regra 2...

---

### 2.5 Puzzle 5

**Descrição Geral:**
  _Descreva o conceito visual e temático deste puzzle aqui._

**Dependência do ID do Cofre:** ( ) Sim  ( ) Não
  * _Se sim, como o ID afeta o resultado?_

**Funcionamento Técnico:**
  _Como o jogador interage com ele no VR/Físico? O que ele precisa acionar ou mover?_

**Regras e Condições:**
  1. Regra 1...
  2. Regra 2...
