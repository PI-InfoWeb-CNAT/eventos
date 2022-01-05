### WDEV
### Especificação de Caso de Uso
### Editar perfil

### Histórico da Revisão

|   Data   | Versão|   Descrição  |        Autor              |
|:---------|:------|:-------------|:--------------------------|
|05/01/2022|  1.0  |Versão inicial| Marina Medeiros           | 


### 1. Resumo
Este caso de uso permite que o usuário altere as informações de seu perfil .

### 2. Atores
Inscrito, apresentador, organizador.

### 3. Precondições 
O usuário deve ter feito cadastro e login no sistema.

### 4. Pós-condições 
O sistema deve realizar as alterações de forma rápida.

### 5. Fluxos de evento
### *5.1 Fluxo básico*
|   Ator   | Sistema |
|:---------|:------|
|1. O usuário acessa a aba de “Editar perfil”.| |
| | 2. a apresenta as informações de e-mail e nome do usuário.|
|3. O usuário altera as informações solicitadas e seleciona a opção de “salvar edição”.| |
| |4.O sistema solicita a confirmação do usuário.|
|5. O usuário confirma.| |
| |6. O sistema atualiza as informações do usuário|

### *5.2 Fluxo de exceção 1 - Nome ou email com caracteres insuficientes*
|   Ator   | Sistema |
|:---------|:------|
|1. O usuário acessa a aba de “Editar perfil”.| |
| | 2. a apresenta as informações de e-mail e nome do usuário.|
|3. O usuário altera as informações apresentadas com dados que contém caracteres insuficientes.| |
| |4.O sistema apresenta um alerta ao usuário de que as informações inseridas tem caracteres insuficientes|
|5. O usuário preenche as informações apresentadas com caracteres suficientes e seleciona a opção de “salvar edição”.| |
| |6.O sistema solicita a confirmação do usuário.|
|7. O usuário confirma.| |
| |8. O sistema atualiza as informações do usuário|

### *5.3 Fluxo de exceção 2 - Email inválido.*
|   Ator   | Sistema |
|:---------|:------|
|1. O usuário acessa a aba de “Editar perfil”.| |
| | 2. a apresenta as informações de e-mail e nome do usuário.|
|3. O usuário altera o dado de “email” um endereço de email inválido.| |
| |4.O sistema apresenta um alerta ao usuário de que as informações inseridas tem caracteres insuficientes|
|5. O usuário preenche as informações apresentadas com caracteres suficientes e seleciona a opção de “salvar edição”.| |
| |6.O sistema solicita a confirmação do usuário.|
|7. O usuário confirma.| |
| |8. O sistema atualiza as informações do usuário|

### 6. Protótipo(s) de interface do caso de uso
![Pagina de Eventos](https://github.com/PI-InfoWeb-CNAT/eventos/blob/main/CasosDeUso/EditarPerfil%20-%20Geral.png)
