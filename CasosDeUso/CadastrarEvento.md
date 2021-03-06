### WDEV
### Especificação de Caso de Uso
### Controlar sessão

### Histórico da Revisão

|   Data   | Versão|   Descrição  |        Autor              |
|:---------|:------|:-------------|:--------------------------|
|22/11/2021|  1.0  |Versão inicial|Larissa Karla; Laura Emily;| 


### 1. Resumo
Este caso de uso permite que organizadores possam cadastrar eventos no sistema.

### 2. Atores
Organizador

### 3. Precondições 
O organizador deve ter feito login no sistema e acessado a página de eventos.

### 4. Pós-condições 
O sistema deve cadastrar o evento de forma rápida.

### 5. Fluxos de evento
### *5.1 Fluxo básico*
|   Ator   | Sistema |
|:---------|:------|
|1. O organizador clica no botão de "eventos anteriores".| |
| | 2. O sistema mostra a interface de "eventos anteriores".|
|3. O organizador visualiza a tela de "eventos anteriores".| |
| |4. O sistema solicita o nome do evento, a data inicial e a data final.|
|5. O organizador preenche os dados necessários colocando o nome do evento, a data inicial e a data final.| |
|  |6. O sistema grava os dados preenchidos pelo organizador.|
|7. O organizador clica em "salvar".| |
| |8. O sistema cadastra o evento.|

### *5.2 Fluxo de exceção 1 – Data inicial inválida*
1. O organizador clica no botão de adicionar evento.

2. O sistema mostra a interface de adicionar evento.

3. O sistema solicita o nome do evento, a data inicial e a data final.

5. O organizador insere uma data inicial inválida.

6. O sistema apresenta uma mensagem de erro, solicitando para o organizador utilizar uma data válida.

### *5.3 Fluxo de exceção 2 – Data final inválida*

1. O organizador clica no botão de adicionar evento.

2. O sistema mostra a interface de adicionar evento.

3. O sistema solicita o título do evento, a data inicial e a data final.	

4. O organizador insere uma data final inválida.

5. O sistema apresenta uma mensagem de erro, solicitando para o organizador utilizar uma data válida.

### *5.4 Fluxo de exceção 3 – Título inválido*

1. O organizador clica no botão de adicionar evento.

2. O sistema mostra a interface de adicionar evento.

3. O sistema solicita o nome do evento, a data inicial e a data final.	

4. O organizador insere um título sem texto.

5. O sistema apresenta uma mensagem de erro, solicitando para o organizador utilizar um título válido.

### 6. Protótipo(s) de interface do caso de uso
![Pagina de Eventos](https://github.com/PI-InfoWeb-CNAT/eventos/blob/main/CasosDeUso/Pagina%20de%20Eventos.png)

![Pagina de Eventos2](https://github.com/PI-InfoWeb-CNAT/eventos/blob/main/CasosDeUso/Pagina%20de%20Eventos2.png)
