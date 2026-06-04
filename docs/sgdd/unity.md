# Estrutura do Projeto e Configuração Unity

Este documento descreve a arquitetura técnica do projeto no motor gráfico Unity, detalhando a organização de arquivos, componentes (scripts C#) e a estrutura de cenas.

---

<!-- isso aq é so um template, n sei mexer muito no unity -->

## 1. Organização de Arquivos (Project Hierarchy)
O projeto segue uma estrutura padrão para garantir a escalabilidade e o controle de versão no GitHub:

* `Assets/Scenes`: Arquivos de cena (.unity).
* `Assets/Scripts`: Classes em C# que controlam a lógica do jogo.
* `Assets/Prefabs`: Objetos pré-configurados (ex: o cubo mecânico, portas, gatilhos).
* `Assets/Models`: Modelos 3D (.fbx ou .obj) importados.
* `Assets/Materials`: Texturas, shaders e propriedades visuais.
* `Assets/Audio`: Efeitos sonoros e trilha sonora.

---

## 2. Configurações de Ambiente
* **Render Pipeline:** Utilizado o *Universal Render Pipeline (URP)*, otimizado para dispositivos móveis e Meta Quest.
* **XR Interaction Toolkit:** Framework base para manipulação de objetos e movimentação em Realidade Virtual (VR).

---

## 3. Arquitetura de Scripts (Classes C#)
A lógica do jogo é dividida em classes responsáveis por funções específicas:

* `CuboMecanico.cs`: Gerencia o estado das faces do cofre, validação de inputs e interação com o ID.
* `ManualHandler.cs`: Controla a exibição das pistas conforme o QR Code escaneado.
* `EventManager.cs`: Gerencia eventos aleatórios (luzes piscando, sons ambientais).
* `GameFlow.cs`: Classe mestre que controla o estado de Vitória/Derrota e o cronômetro.

---

## 4. Estrutura de Cenários
O projeto é dividido em dois ambientes principais que carregam de forma síncrona:

* **Area_Triagem (VR):** Cenário principal onde o cofre reside. Configurado com *Lightmaps* para otimização de performance no Meta Quest.
* **Area_Sotao (Mobile):** Cenário de suporte. Contém os triggers que conectam as ações do jogador VR com a lógica de backend.

---

## 5. Assets Utilizados

<p align="center">Tabela 1 - Inventário de Assets</p>
<table class="full-width-table">
  <thead>
    <tr>
      <th style="text-align: left;">Categoria</th>
      <th style="text-align: left;">Descrição/Fonte</th>
      <th style="text-align: left;">Finalidade</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Modelagem 3D</td>
      <td></td>
      <td></td>
    </tr>
    <tr>
      <td>Audio</td>
      <td></td>
      <td></td>
    </tr>
    <tr>
      <td>VR Framework</td>
      <td></td>
      <td></td>
    </tr>
  </tbody>
</table>
<p align="center">Fonte: Autoria de <a href="https://github.com/SEU GIT AQUI">NOME</a></p>

---

