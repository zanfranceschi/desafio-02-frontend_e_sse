# Desafio 02: Frontend com SSE – Cotação de Ações
Esse repositório faz parte do desafio disponível [nessa thread do twitter](https://twitter.com/zanfranceschi/status/1550228591652519936) e também [nesse post de dev.to](https://dev.to/zanfranceschi/desafio-frontend-conectar-a-uma-api-para-sse-9ok).

Por favor, note que o código disponível aqui não tem qualidade de produção e não deveria ser usado para referência sobre como desenvolver uma API para SSE.

## Organização do Repositório
- O fonte da API para consumir os eventos de cotação está disponível em [src](./src).


## Material de Apoio
https://www.highcharts.com/demo e https://www.highcharts.com/demo/dynamic-click-to-add - para referência de gráficos dinâmicos.


### Docker
Para executar a [imagem docker](https://hub.docker.com/repository/docker/zanfranceschi/desafio-02-frontend_e_sse) diretamente do dockerhub (sem precisar fazer build):
~~~
docker run --rm -p 8080:80 zanfranceschi/desafio-02-frontend_e_sse
~~~

Se preferir fazer o build da imagem, siga os passos à seguir.
~~~
cd ./src
~~~

Para construir a imagem docker, execute:
~~~
docker build -t desafio-02-frontend_e_sse .
~~~

Para executar um container, execute:
~~~
docker run --rm -p 8080:80 desafio-02-frontend_e_sse
~~~


### API de Cotação de Ações
Os exemplos têm como premissa que você esteja executando o container docker na porta 8080.

Requisição:
~~~
GET http://localhost:8080/cotacoes
~~~

A resposta será do tipo "text/event-stream". Use o seguinte como exemplo para iniciar.
~~~js
const source = new EventSource('http://localhost:8080/cotacoes');

source.onmessage = function (event) {
    console.log(event.data);
};

source.onopen = function(event) {
    console.log('onopen');
};

source.onerror = function(event) {
    console.log('onerror');
}
~~~

Você também pode usar o arquivo [./src/frontend.html](./src/frontend.html) ou acessar [http://localhost:8080](http://localhost:8080) após ter subido a imagem docker como uma referência.

## Sugestão de Resolução

A imagem seguinte é a minha sugestão de resolução:

![image](https://user-images.githubusercontent.com/1862567/180513785-b899b256-1691-410d-a566-219fb7504b0a.png)


O fonte para essa sugestão de resolução com a biblioteca highcharts está em [./src/frontend-com-grafico.html](./src/frontend-com-grafico.html).

## Resoluções da Comunidade

Abaixo você encontra exemplos de resoluções criados pela comunidade:

**FAÇA SEU PULL REQUEST E INCLUA SUA SOLUÇÃO AQUI!!!**
