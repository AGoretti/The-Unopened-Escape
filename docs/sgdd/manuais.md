# Manuais de Resolução do Puzzle

Esta seção documenta e centraliza os arquivos de interface renderizados no smartphone do Jogador 2 após o escaneamento do QRcode dos cartões físicos. Cada documento simula uma página de um manual técnico antigo, mantendo a estética de horror analógico proposta pelo projeto.

---

## 1. Referências Externas dos Manuais

A tabela abaixo centraliza os recursos associados a cada puzzle do jogo, incluindo o link para o design do documento em Canva, o link do QR Code que será escaneado pelo Jogador 2 e o link para o design do card físico que será impresso e utilizado durante a dinâmica do jogo.

<!-- QUEM FOR CRIAR LEMBRA DE DEIXAR O ARQUIVO CANVA LIMITADO, TER Q PEDIR ACESSO PARA EDITAR-->
<br>
<p align="center">Tabela 1 - Vínculos dos Puzzles</p>

<table class="full-width-table">
    <thead>
        <tr>
            <th>Número</th>
            <th>Nome</th>
            <th>Design PDF</th>
            <th>QR Code</th>
            <th>Design Card Físico</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>1</td>
            <td>Fios e Portas</td>
            <td><a href="#">PDF</a></td>
            <td><a href="#">QR Code</a></td>
            <td><a href="#">Card Físico</a></td>
        </tr>
        <tr>
            <td>2</td>
            <td>Símbolos Eldritch</td>
            <td><a href="#">PDF</a></td>
            <td><a href="#">QR Code</a></td>
            <td><a href="#">Card Físico</a></td>
        </tr>
        <tr>
            <td>3</td>
            <td>Sons Metálicos</td>
            <td><a href="#">PDF</a></td>
            <td><a href="#">QR Code</a></td>
            <td><a href="#">Card Físico</a></td>
        </tr>
        <tr>
            <td>4</td>
            <td>Alavancas Mecânicas</td>
            <td><a href="#">PDF</a></td>
            <td><a href="#">QR Code</a></td>
            <td><a href="#">Card Físico</a></td>
        </tr>
        <tr>
            <td>5</td>
            <td>Perfis de Segurança</td>
            <td><a href="#">PDF</a></td>
            <td><a href="#">QR Code</a></td>
            <td><a href="#">Card Físico</a></td>
        </tr>
    </tbody>
</table>

<p align="center">Fonte: Autoria de <a href="https://github.com/zzzBECK">Alexandre Beck</a> e <a href="https://github.com/bolzanMGB">Othavio Araújo Bolzan</a></p>

---

## 2. Conteúdo dos Manuais de Resolução

Esta subseção detalha o texto, as tabelas de conversão e as pistas visuais contidas nos arquivos digitais acessados pelo Jogador 2.

---

### 2.1 Manual 01 — Protocolo de Religação de Circuitos

**1. Conteúdo Literário do Documento:**

*"CONFIDENCIAL — Setor de Manutenção Elétrica, Área 2: Em caso de falha no sistema de contenção, o operador externo deverá restaurar manualmente o roteamento dos circuitos de segurança. Localize os cinco cabos desgastados na face do painel e conecte-os às portas numeradas de 1 a 8, dispostas em sequência linear da esquerda para a direita. Aplique as regras na ordem estrita abaixo — a inversão da sequência compromete o circuito inteiro. Três portas deverão, obrigatoriamente, permanecer vazias ao final do protocolo. Solicite o ID do cofre ao operador interno antes de iniciar."*

**2. Matrizes de Resolução:**

<!-- TODO: confirmar com a equipe de arte que as 8 portas são dispostas em linha (1→8) e que "adjacente/ao lado" significa numericamente consecutivas (ex.: 4 e 5 são adjacentes). -->
<br>
<p align="center">Tabela 2 - Roteamento dos Cabos (aplicar na ordem: Vermelho → Preto → Azuis → Amarelo)</p>

<table class="full-width-table">
    <thead>
        <tr>
            <th>Ordem</th>
            <th>Cabo</th>
            <th>Condição</th>
            <th>Porta de Destino</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>1</td>
            <td>Vermelho</td>
            <td>Último dígito do ID for <strong>par</strong></td>
            <td>Porta 8</td>
        </tr>
        <tr>
            <td>1</td>
            <td>Vermelho</td>
            <td>Último dígito do ID for <strong>ímpar</strong></td>
            <td>Porta 1</td>
        </tr>
        <tr>
            <td>2</td>
            <td>Preto</td>
            <td>Soma dos 4 dígitos do ID <strong>&gt; 15</strong></td>
            <td>Porta 4</td>
        </tr>
        <tr>
            <td>2</td>
            <td>Preto</td>
            <td>Soma dos 4 dígitos do ID <strong>≤ 15</strong></td>
            <td>Porta 5</td>
        </tr>
        <tr>
            <td>3</td>
            <td>Azul × 2</td>
            <td>ID contém o dígito <strong>"0"</strong> ou <strong>"7"</strong> em qualquer posição</td>
            <td>Duas portas adjacentes (lado a lado) ainda vazias, escolhendo as de <strong>número mais alto</strong> disponíveis</td>
        </tr>
        <tr>
            <td>3</td>
            <td>Azul × 2</td>
            <td>ID <strong>não</strong> contém "0" nem "7"</td>
            <td>Porta 2 e Porta 7</td>
        </tr>
        <tr>
            <td>4</td>
            <td>Amarelo</td>
            <td>— (ver restrição abaixo)</td>
            <td>Porta vazia de <strong>menor número</strong> que <strong>não</strong> seja imediatamente adjacente ao Cabo Preto</td>
        </tr>
    </tbody>
</table>

<p align="center">Fonte: Autoria de <a href="https://github.com/zzzBECK">Alexandre Beck</a> e <a href="https://github.com/bolzanMGB">Othavio Araújo Bolzan</a></p>

<br>
<p align="center">Tabela 3 - Exceção Crítica: Falha de Tensão</p>

<table class="full-width-table">
    <thead>
        <tr>
            <th>Condição (verificar após aplicar todas as regras acima)</th>
            <th>Ação Obrigatória</th>
            <th>Resultado Final</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Porta 3 <strong>e</strong> Porta 6 estão <strong>ambas</strong> ocupadas</td>
            <td>Remover o Cabo Preto imediatamente e deixá-lo desconectado</td>
            <td>4 portas ocupadas · 4 portas vazias</td>
        </tr>
        <tr>
            <td>Qualquer outro caso</td>
            <td>Nenhuma ação adicional</td>
            <td>5 portas ocupadas · 3 portas vazias</td>
        </tr>
    </tbody>
</table>

<p align="center">Fonte: Autoria de <a href="https://github.com/zzzBECK">Alexandre Beck</a> e <a href="https://github.com/bolzanMGB">Othavio Araújo Bolzan</a></p>

---

### 2.2 Manual 02 — Litania de Ativação dos Selos

**1. Conteúdo Literário do Documento:**

*"REGISTRO OCULTISTA — Arquivo Interdito, Nível Ômega: Os selos gravados na face do cofre não podem ser ativados em ordem arbitrária. A sequência incorreta desperta o que há dentro. O operador externo deve consultar as regras de prioridade abaixo, aplicando-as uma a uma sobre os símbolos presentes, conforme descrito pelo operador interno. A ordem final resultante é a única sequência segura de toque."*

**2. Matrizes de Resolução:**

<br>
<p align="center">Tabela 4 - Regras de Prioridade dos Selos (aplicar em ordem: Regra 1 → 2 → 3 → 4)</p>

<table class="full-width-table">
    <thead>
        <tr>
            <th>Regra</th>
            <th>Condição de Aplicação</th>
            <th>Instrução</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>1</td>
            <td>Houver símbolo do <strong>Olho</strong> e símbolo da <strong>Vela</strong> presentes simultaneamente</td>
            <td>A <strong>Vela</strong> deve ser pressionada <strong>antes</strong> do Olho</td>
        </tr>
        <tr>
            <td>2</td>
            <td>Houver símbolo da <strong>Lua</strong> e símbolo da <strong>Chave</strong> presentes simultaneamente</td>
            <td>A <strong>Lua</strong> deve vir <strong>antes</strong> da Chave, sempre</td>
        </tr>
        <tr>
            <td>3</td>
            <td>Houver símbolo do <strong>Rato</strong> presente</td>
            <td>O <strong>Rato</strong> nunca pode ser o <strong>último</strong> a ser pressionado</td>
        </tr>
        <tr>
            <td>4</td>
            <td>Sempre</td>
            <td>O símbolo com o <strong>maior número de pontas</strong> (ver Tabela 5) deve ser pressionado por <strong>último</strong></td>
        </tr>
    </tbody>
</table>

<p align="center">Fonte: Autoria de <a href="https://github.com/zzzBECK">Alexandre Beck</a> e <a href="https://github.com/bolzanMGB">Othavio Araújo Bolzan</a></p>

<!-- TODO: confirmar com a equipe de arte os valores de pontas de cada símbolo conforme o design final dos ícones — os valores abaixo são preliminares. -->
<br>
<p align="center">Tabela 5 - Contagem de Pontas por Símbolo</p>

<table class="full-width-table">
    <thead>
        <tr>
            <th>Símbolo</th>
            <th>Número de Pontas</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Espiral</td>
            <td>0</td>
        </tr>
        <tr>
            <td>Vela</td>
            <td>1</td>
        </tr>
        <tr>
            <td>Lua</td>
            <td>2</td>
        </tr>
        <tr>
            <td>Olho</td>
            <td>3</td>
        </tr>
        <tr>
            <td>Triângulo</td>
            <td>4</td>
        </tr>
        <tr>
            <td>Chave</td>
            <td>5</td>
        </tr>
        <tr>
            <td>Rato</td>
            <td>6</td>
        </tr>
        <tr>
            <td>Mão</td>
            <td>7</td>
        </tr>
    </tbody>
</table>

<p align="center">Fonte: Autoria de <a href="https://github.com/zzzBECK">Alexandre Beck</a> e <a href="https://github.com/bolzanMGB">Othavio Araújo Bolzan</a></p>

---

### 2.3 Manual 03 — Cartilha de Decodificação Acústica

**1. Conteúdo Literário do Documento:**

*"PROTOCOLO DE ESCUTA — Divisão de Controle de Ruído, Área 2: O cofre se comunica através de batidas codificadas emitidas por sua estrutura interna. O operador externo deve aguardar a descrição completa da sequência pelo operador interno antes de iniciar a decodificação. Utilize as tabelas abaixo para traduzir cada batida em seu símbolo correspondente e, em seguida, aplique os modificadores de sequência, caso necessário."*

**2. Matrizes de Resolução:**

<br>
<p align="center">Tabela 6 - Tradução Acústica: Som → Símbolo</p>

<table class="full-width-table">
    <thead>
        <tr>
            <th>Padrão Sonoro</th>
            <th>Símbolo Correspondente</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Uma batida <strong>longa</strong></td>
            <td>Lua</td>
        </tr>
        <tr>
            <td><strong>Duas</strong> batidas curtas</td>
            <td>Chave</td>
        </tr>
        <tr>
            <td><strong>Três</strong> batidas rápidas</td>
            <td>Olho</td>
        </tr>
        <tr>
            <td>Uma <strong>pausa longa</strong></td>
            <td><em>(separador — indica troca de símbolo; não é um símbolo em si)</em></td>
        </tr>
    </tbody>
</table>

<p align="center">Fonte: Autoria de <a href="https://github.com/zzzBECK">Alexandre Beck</a> e <a href="https://github.com/bolzanMGB">Othavio Araújo Bolzan</a></p>

<br>
<p align="center">Tabela 7 - Modificadores de Sequência</p>

<table class="full-width-table">
    <thead>
        <tr>
            <th>Condição</th>
            <th>Efeito na Sequência</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>A sequência <strong>termina</strong> com uma batida <strong>longa</strong></td>
            <td>O <strong>último</strong> símbolo decodificado deve ser pressionado <strong>primeiro</strong></td>
        </tr>
        <tr>
            <td>Ocorrem <strong>duas pausas longas seguidas</strong> na sequência</td>
            <td><strong>Ignorar completamente</strong> o próximo som após as duas pausas</td>
        </tr>
    </tbody>
</table>

<p align="center">Fonte: Autoria de <a href="https://github.com/zzzBECK">Alexandre Beck</a> e <a href="https://github.com/bolzanMGB">Othavio Araújo Bolzan</a></p>

---

### 2.4 Manual 04 — Tabela de Calibração das Alavancas

**1. Conteúdo Literário do Documento:**

*"MANUAL TÉCNICO — Módulo de Calibração Mecânica, Revisão 7-C: O sistema de alavancas do painel requer calibração precisa antes de cada operação. As quatro alavancas devem ser posicionadas de acordo com as características do número de registro do cofre (ID). O operador externo receberá o ID do operador interno e aplicará as regras abaixo para determinar a posição correta de cada alavanca. Após o posicionamento, o operador interno deve pressionar o botão de validação."*

**2. Matrizes de Resolução:**

<!-- TODO: confirmar as posições default das Alavancas 2 e 4 quando a condição não se aplica — os valores "Cima" abaixo são preliminares. -->
<br>
<p align="center">Tabela 8 - Calibração das Alavancas</p>

<table class="full-width-table">
    <thead>
        <tr>
            <th>Alavanca</th>
            <th>Condição</th>
            <th>Posição Correta</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td rowspan="2"><strong>Alavanca 1</strong></td>
            <td>Último dígito do ID for <strong>par</strong></td>
            <td>Cima</td>
        </tr>
        <tr>
            <td>Último dígito do ID for <strong>ímpar</strong></td>
            <td>Baixo</td>
        </tr>
        <tr>
            <td rowspan="2"><strong>Alavanca 2</strong></td>
            <td>ID <strong>contém o dígito "8"</strong> em qualquer posição</td>
            <td>Meio</td>
        </tr>
        <tr>
            <td>ID <strong>não</strong> contém o dígito "8"</td>
            <td>Cima</td>
        </tr>
        <tr>
            <td><strong>Alavanca 3</strong></td>
            <td>Sempre</td>
            <td><strong>Oposta</strong> à Alavanca 1 (se Alavanca 1 = Cima → Baixo; se Alavanca 1 = Baixo → Cima)</td>
        </tr>
        <tr>
            <td rowspan="2"><strong>Alavanca 4</strong></td>
            <td>Algum dígito do ID for <strong>maior que 6</strong></td>
            <td>Baixo</td>
        </tr>
        <tr>
            <td>Nenhum dígito do ID for maior que 6</td>
            <td>Cima</td>
        </tr>
    </tbody>
</table>

<p align="center">Fonte: Autoria de <a href="https://github.com/zzzBECK">Alexandre Beck</a> e <a href="https://github.com/bolzanMGB">Othavio Araújo Bolzan</a></p>

---

### 2.5 Manual 05 — Diretiva de Perfis de Segurança

**1. Conteúdo Literário do Documento:**

*"DIRETIVA CLASSIFICADA — Autoridade de Segurança Interna, Setor Ômega: O painel de selos desta câmara opera sob um dos cinco Perfis de Segurança ativos, determinado pelo número de registro do cofre. Antes de qualquer ativação, o operador externo deve identificar o Perfil vigente consultando a Tabela 9. Em seguida, aplique as regras-base de ativação dos selos (conforme Manual 02 — Litania de Ativação dos Selos) com as modificações impostas pelo Perfil identificado (Tabela 10). O descumprimento desta diretiva invalida o protocolo de contenção."*

**2. Matrizes de Resolução:**

<br>
<p align="center">Tabela 9 - Seleção do Perfil de Segurança</p>

<table class="full-width-table">
    <thead>
        <tr>
            <th>Último Dígito do ID do Cofre</th>
            <th>Perfil Ativo</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>0 ou 1</td>
            <td>Perfil Padrão</td>
        </tr>
        <tr>
            <td>2 ou 3</td>
            <td>Perfil Invertido</td>
        </tr>
        <tr>
            <td>4 ou 5</td>
            <td>Perfil de Prioridade</td>
        </tr>
        <tr>
            <td>6 ou 7</td>
            <td>Perfil de Mentira</td>
        </tr>
        <tr>
            <td>8 ou 9</td>
            <td>Perfil de Sacrifício</td>
        </tr>
    </tbody>
</table>

<p align="center">Fonte: Autoria de <a href="https://github.com/zzzBECK">Alexandre Beck</a> e <a href="https://github.com/bolzanMGB">Othavio Araújo Bolzan</a></p>

<br>
<p align="center">Tabela 10 - Comportamento de Cada Perfil</p>

<table class="full-width-table">
    <thead>
        <tr>
            <th>Perfil</th>
            <th>Como Aplicar as Regras-Base (Manual 02)</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td><strong>Padrão</strong></td>
            <td>Siga as regras do Manual 02 normalmente, sem modificações.</td>
        </tr>
        <tr>
            <td><strong>Invertido</strong></td>
            <td>Determine a sequência correta aplicando as regras do Manual 02 e, em seguida, <strong>inverta completamente a ordem</strong> resultante antes de pressionar os símbolos.</td>
        </tr>
        <tr>
            <td><strong>Prioridade</strong></td>
            <td>Aplique as regras do Manual 02, porém os símbolos considerados <strong>mais importantes</strong> (maior número de pontas, conforme Tabela 5 do Manual 02) devem vir <strong>primeiro</strong> na sequência.</td>
        </tr>
        <tr>
            <td><strong>Mentira</strong></td>
            <td>Aplique as regras do Manual 02, mas <strong>ignore qualquer regra que contenha a palavra "sempre"</strong> (Regra 2 e Regra 4 do Manual 02 ficam suspensas).</td>
        </tr>
        <tr>
            <td><strong>Sacrifício</strong></td>
            <td>Aplique as regras do Manual 02, mas o símbolo considerado <strong>mais perigoso</strong> — aquele com maior número de pontas (Tabela 5 do Manual 02) — deve ser pressionado <strong>por último</strong>, independentemente de outras regras.</td>
        </tr>
    </tbody>
</table>

<p align="center">Fonte: Autoria de <a href="https://github.com/zzzBECK">Alexandre Beck</a> e <a href="https://github.com/bolzanMGB">Othavio Araújo Bolzan</a></p>
