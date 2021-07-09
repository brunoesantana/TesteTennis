# tech-test

Você **não poderá usar bibliotecas externas** ou ferramentas para propósito de criação ou teste. Especificamente, você poderá usar bibliotecas de testes unitários ou ferramentas de build disponíveis para a linguagem que você escolher (por exemplo, Nunit, MSTest, etc).

**Precisaremos rodar e compilar o seu código**. Por favor encaminhe uma breve descrição do design e suposições junto com o seu código, bem como as instruções detalhadas de como rodar sua aplicação.

 Não é necessário que você trabalhe nos mínimos detalhes da solução, porém estaremos procurando algo mais que somente o esqueleto do código.

O programa deve ser escrito usando o desenvolvimento orientado a testes, seguindo as etapas de refatoração vermelhas e verdes.
Não sacrifique TDD para completar a solução, isso resultará em uma falha.
Avaliaremos uma variedade de aspectos, como design da solução, SOLID e orientação a objeto. Mesmo que estes problemas não sejam extensos, nós esperamos que você encaminhe um código que acredite ser de qualidade, um código possível de ser rodado e evoluído.

## Introdução:

 - Deve haver uma maneira de prover um arquivo como entrada de dados para a aplicação
 - A aplicação deve executar
 - Realize um fork do projeto
 - Adicione @pottencial (Pottencial Seguradora) como membro do seu fork. Você pode fazer isto em  https://gitlab.com/`your-user`/tech-test-train/settings/members
 - Quando você começar, faça um commit vazio com a mensagem "Iniciando o teste de tecnologia" e quando terminar, faça o commit com uma mensagem "Finalizado o teste de tecnologia".
 - Commit após cada ciclo de refatoração pelo menos.
 - Não use branches.
 - Tente não gastar mais de 3 horas para concluir o teste técnico.
 - Você deve prover evidências suficientes de que sua solução está completa indicando, no mínimo, que ela funciona utilizando os dados de teste que são fornecidos

## Problema
Neste problema você deverá implementar as regras de um jogo de tênis simples (apenas dois jogadores).

As regras de um jogo de tênis tem diversos detalhes, mas para simplificar o problema, você deve implementar apenas as regras de um game:

- Em um game cada jogador pode ter a seguinte pontuação: 0, 15, 30, ou 40;
- Os jogadores sempre começam com 0 pontos;
- Se o jogador possui 40 pontos e ganha a disputa, ele vence o game;
- Se ambos jogadores atingem 40 pontos, ocorre um empate (deuce);
- Estando em empate, o jogador que ganhar a bola seguinte está em vantagem (advantage);
- Se um jogador em vantagem ganha novamente a bola, ele vence o game;
- Se um jogador estiver em vantagem e o outro ganhar a bola, volta a ocorrer o empta (deuce).

Caso tenha tempo e vontade de melhorar o seu código, você pode implementar mais regras do tênis (serviço, sets, tie-break, etc). Mais informações sobre as regras em http://pt.wikipedia.org/wiki/T%C3%A9nis