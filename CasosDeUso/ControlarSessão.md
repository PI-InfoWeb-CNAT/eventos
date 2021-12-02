### WDEV
### Especificação de Caso de Uso
### Controlar sessão

### Histórico da Revisão

|   Data   | Versão|   Descrição  |        Autor              |
|:---------|:------|:-------------|:--------------------------|
|22/11/2021|  1.0  |Versão inicial|Larissa Karla; Laura Emily;| 


### 1. Resumo
Este caso de uso permite que o organizador controle as sessões do evento.

### 2. Atores
Organizador

### 3. Precondições 
O organizador deve ter feito login no sistema.

### 4. Pós-condições 
O sistema cadastra a sessão de forma rápida.

### 5. Fluxos de evento
### *5.1 Fluxo básico*
|   Ator   | Sistema |
|:---------|:------|
|1. O organizador clica em adicionar sessão.|         |
|        |2. O sistema solicita horário inicial, hora final, local e título da sessão.|
|3. O organizador preenche os dados necessários colocando hora inicial, hora final, local e título.| |
|  |4. O sistema grava os dados preenchidos pelo organizador.|
|5. O organizador clica em adicionar sessão.| |
| |6. O sistema cadastra a sessão.|
|7. O organizador visualiza a sessão anexada à tabela de programação.| |

### *5.2 Fluxo de exceção 1 – Hora inicial inválida*

1. O organizador entra na página de programação.

2. O organizador clica em adicionar sessão.

3. O sistema solicita horário inicial, hora final, local e título da sessão.

4. O organizador insere uma hora inicial inválida.

5. O sistema apresenta uma mensagem de erro, solicitando para o organizador utilizar uma hora válida.

### 5.3 Fluxo de exceção 2 – Hora final inválida

1. O organizador clica em adicionar sessão.

2. O sistema solicita horário inicial, hora final, local e título da sessão.

3. O organizador insere uma hora final inválida.

4. O sistema apresenta uma mensagem de erro, solicitando que o organizador utilize uma hora válida.

### 5.4 Fluxo de exceção 3 – título inválido

1. O organizador clica no botão de adicionar sessão.

2. O sistema solicita horário inicial, hora final, local e título da sessão.

4. O organizador insere um título sem texto.

5. O sistema apresenta uma mensagem de erro, solicitando para o organizador utilizar um título válido.

### *5.3 Fluxo de exceção 3 – local inválido*

1. O organizador clica no botão de adicionar sessão.

2. O sistema solicita horário inicial, hora final, local e título da sessão.

3. O organizador insere um local sem texto.

4. O sistema apresenta uma mensagem de erro, solicitando para o organizador utilizar um local válido.

### 6. Protótipo(s) de interface do caso de uso
![Pagina de Eventos](https://github.com/PI-InfoWeb-CNAT/eventos/blob/main/CasosDeUso/Pagina%20Inicial%20do%20Organizador.png)
