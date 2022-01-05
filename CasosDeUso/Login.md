### WDEV
### Especificação de Caso de Uso
### Login

### Histórico da Revisão

|   Data   | Versão|   Descrição  |        Autor              |
|:---------|:------|:-------------|:--------------------------|
|05/01/2021|  1.0  |Versão inicial| Marina Medeiros           | 


### 1. Resumo
Este caso de uso permite que o usuário faça login no WDev .

### 2. Atores
Inscrito, apresentador, organizador.


### 3. Precondições 
O usuário deve ter feito cadastro no sistema.

### 4. Pós-condições 
O sistema deve realizar a autenticação do usuário de forma rápida.

### 5. Fluxos de evento
### *5.1 Fluxo básico*
|   Ator   | Sistema |
|:---------|:------|
|1. O usuário acessa o sistema..| |
| | 2. O sistema solicita o email e a senha do usuário.
|3. O usuário preenche as informações solicitadas.| |
| |4. O sistema realiza a autenticação do usuário.|
|5. O usuário visualiza a página inicial..| |

### *5.2 Fluxo de exceção 1 - Dados inválidos*
|   Ator   | Sistema |
|:---------|:------|
|1. O usuário acessa o sistema..| |
| | 2. O sistema solicita o email e a senha do usuário.|
|3. O usuário preenche as informações solicitadas com dados inválidos.| |
| |4. O sistema solicita email e senha novamente.|
|5. O usuário preenche as informações solicitadas.| |
| |6. O sistema realiza a autenticação do usuário.|
|7. O usuário visualiza a página inicial.| |

### 6. Protótipo(s) de interface do caso de uso
![Pagina de Eventos](https://github.com/PI-InfoWeb-CNAT/eventos/blob/main/CasosDeUso/Pagina%20de%20Eventos.png)

![Pagina de Eventos2](https://github.com/PI-InfoWeb-CNAT/eventos/blob/main/CasosDeUso/Pagina%20de%20Eventos2.png)
