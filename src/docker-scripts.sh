docker image rm zanfranceschi/desafio-02-frontend_e_sse
docker build -t zanfranceschi/desafio-02-frontend_e_sse .
docker push zanfranceschi/desafio-02-frontend_e_sse
docker run --rm -p 8080:80 zanfranceschi/desafio-02-frontend_e_sse