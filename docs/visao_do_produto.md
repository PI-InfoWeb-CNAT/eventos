# Documento de visão


### 1. Objetivo do Projeto 

O projeto tem como objetivo controlar as incrições, a programação e os certificados do W-Tads.
 

### 2. Descrição do problema 

|         __        | __   |
|:------------------|:-----|
| **_O problema_**    | a falta de uma plataforma simples para controlar o W-Tads, permitindo inscrição e emissão de certificados.  |
| **_afetando_**      | alunos, professores e público externo que participam do evento|
| **_cujo impacto é_**| falta de organização sistemática para controle do evento                                    |
| **_uma boa solução seria_** | desenvolvimento de um sistema que permite organizar de forma simples e fácil o W-Tads |


### 3. Descrição dos usuários

| Nome | Descrição | Responsabilidades |
|:---  |:--- |:--- |
| Inscritos  | Pessoas que irão participar do evento como ouvintes e irão receber certificado de participação |
| Palestrante  | Pessoas que irão participar do evento como palestrantese irão receber certificado |
| Organizadores | Administram o sistema | Irão cadastrar as sessões, horários e palestrantes |



### 4. Principais necessidades dos usuários
 
Os organizadores de eventos precisam de um ambiente simples e com boa usabilidade para controle de sessões, inscritos, check-in, geração de certificados e 
inclusão de dados importantes como: nome dos organizadores, contato, local, horário e link para inscrição.

Um dos problemas de organização de evento é o check-in e o certificado. É interessante que todos os inscritos façam um check-in por turno para que o certificado seja 
gerado com a hora total no qual o inscrito acompanhou o evento, considerando um evento de 3 dias e nos dois turnos, e, por exemplo, um inscrito que só pode participar um 
turno, deve receber o certificado com o total de horas o qual faz jus o acompanhamento.




### 5.	Alternativas concorrentes
https://plataforma.even3.com.br
Pontos positivos: intuitivo,  aba de transmissão online e aba de programação. Pontos negativos: abas demais, e design não atrativo.

https://evnts.com.br
Pontos positivos: interface atrativa, análise de dados dos eventos. Pontos negativos: Poucas informações sobre a criação dos eventos

https://sympla.com.br
Enviar material antecipadamente para os integrantes do evento, capacidade de modificar e filtrar a inscrição de um usuário. Porém há muita informação na tela.

https://www.eventbrite.com.br
Pontos positivos: realizar de relatório dentro do programa e definição de data, horário e quantidade dos participantes do evento. Pontos negativos: notificações em excesso.

https://eventos.nic.ifrn.edu.br
Pontos positivos: O site intuitivo com interface limpa; Pontos negativos: A tela do site tem muito zoom, os inscritos tem que cadastrar o CPF e não como saber com seria a tela do organizador.

### 6.	Visão geral do produto
Sistema simples com boa usabilidade e acessibilidade, o que também inclui bom acesso pelo celular, responsividade, e bom acesso por usuários com deficiência ou limitações. 

### 7. Descrição do ambiente dos usuários
Durante a organização do WTads, é necessário realizar o check-in do público e dos palestrantes para que haja a emissão de certificados, além de disponibilizar para o público os horários em que as apresentações ocorrerão. Em algumas situações, formam-se grandes filas durante o evento para que o check-in seja realizado, o que acaba gerando dificuldades no acesso a certificados que registrem a quantidade de horas efetivamente.
Dessa forma, a ideia do sistema é permitir que os organizadores cadastrem o evento, detalhando a hora, local e data das apresentações que nele ocorrerão, além de validar o check-in dos usuários e emitir certificados; e que o público, em geral, possa consultar detalhes dos eventos, se inscrever neles e receber certificados com a finalidade de estabelecer um canal de comunicação ágil entre palestrantes, público e organizadores. 
O sistema deve estar habilitado a receber requisições 7 dias por semana, 24 horas por dia. Os locais para a interação com o sistema são diversos e podem ter variação de qualidade de sinal de internet, o que pode limitar o acesso ao sistema



### 8. Requisitos funcionais
| Código | Nome | Descrição |
|:--- | :--- | :--- |
|RF01|Entrar no sistema | Usuários devem entrar no sistema para poder usar as funcionalidades|
|RF02|Cadastro de Palestrantes | Administrar os palestrantes que se apresentaram no evento|
|RF03|Administração das apresentações | Gerenciar a data, local e hora das apresentações|
|RF04|Inscrição do público | Inscritos se cadastraram no evento|
|RF05|Consulta das apresentações | Usuários serão capazes de ver detalhes das apresentações (data, local e hora)|
|RF06|Emissão de Certificado | O site emitira um certificado para o público e palestrantes|

### 9. Requisitos não funcionais
| Código | Nome | Descrição | Categoria | Classificação |
|:--- | :--- | :--- | :--- | :--- | 
|RF01|Design Responsivo | O site deve se adaptar a qualquer dispositivo seja móvel ou fixo | Usabilidade | Obrigatório|
|RF02|Criptografia de Dados | Senhas dos usuários devem ser gravadas e criptografadas no banco de dados | Segurança | Obrigatório|
|RF03|Controle de Acesso | Apenas usuários autenticados podem usar o site, a menos que seja o auto cadastramento no site | Segurança | Obrigatório|
|RF04|Facilidade de uso | O sistema deve ser fácil e interativo para o usuário | Usabilidade | Obrigatório|
|RF05|Tempo de resposta | A comunicação entre o servidor e o cliente deve ocorrer em tempo hábil | Performance | Desejável|
|RF06|Dados do usuário | o usuário será capaz de ver o seus dados, sem poder ver os dos outros | Segurança | Obrigatório|
