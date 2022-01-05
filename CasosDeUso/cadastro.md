### WDEV
### Especificação de Caso de Uso
### Fazer Cadastro

### Histórico da Revisão

|   Data   | Versão|   Descrição  |        Autor              |
|:---------|:------|:-------------|:--------------------------|
|05/01/2022|  1.0  |Versão inicial|Marina Medeiros;| 


### 1. Resumo
Este caso de uso permite que o usuário faça cadastro no WDev .

### 2. Atores
Inscrito, apresentador, organizador.

### 3. Precondições 
Não existem.

### 4. Pós-condições 
O sistema deve realizar o cadastro do usuário de forma rápida.

### 5. Fluxos de evento
### *5.1 Fluxo básico*
|   Ator   | Sistema |
|:---------|:------|
|1. O usuário acessa o sistema.| |
| | 2. O sistema solicita e-mail, nome, CPF, matrícula, senha e confirmação de senha do usuário|
|3. O usuário preenche as informações solicitadas e seleciona "cadastrar".| |
| |4. O sistema realiza o cadastro do usuário.|
|5. O usuário visualiza a página inicial.| |

### *5.2 Fluxo de exceção 1 - Dados inválidos*
|   Ator   | Sistema |
|:---------|:------|
|1. O usuário acessa o sistema.| |
| | 2. O sistema solicita e-mail, nome, CPF, matrícula, senha e confirmação de senha do usuário|
|3. O usuário preenche os campos de CPF, email ou matrícula com dados inválidos.| |
| |4. O sistema alerta o usuário que os dados são inválidos.|
|5. O usuário preenche os campos de CPF, email ou matrícula com dados válidos e seleciona "cadastrar".| |
| |6. O sistema realiza o cadastro do usuário.|
|7. O usuário visualiza a página inicial.| |

### *5.2 Fluxo de exceção 1 - Caracteres insuficientes*
|   Ator   | Sistema |
|:---------|:------|
|1. O usuário acessa o sistema.| |
| | 2. O sistema solicita e-mail, nome, CPF, matrícula, senha e confirmação de senha do usuário|
|3. O usuário preenche os campos solicitados com dados que contém caracteres insuficientes| |
| |4. O sistema alerta o usuário que os dados são inválidos.|
|5. O usuário preencheos campos solicitados com dados válidos e seleciona "cadastrar".| |
| |6. O sistema realiza o cadastro do usuário.|
|7. O usuário visualiza a página inicial.| |

### 6. Protótipo(s) de interface do caso de uso
![Cadastrar](https://github.com/PI-InfoWeb-CNAT/eventos/blob/main/CasosDeUso/Cadastro.png)

