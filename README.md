# MonitoramentoTarefa
Monitorar projeto e tarefas

## 🚀 Começando
Essas instruções permitirão que você obtenha uma cópia do projeto em operação na sua máquina local para fins de desenvolvimento e teste.

### 📋 Pré-requisitos
.Net 8,
.Docker,
.Sql Rodando no Docker,
.Mudar a conect string so banco de dados 

### 🔧 Instalação
Rodar o comando 
docker build . -t monitoramento1
para subir uma imagem com a aplicação de monitoramento.

docker build . -t monitoramento1

## 🖇️ Colaborando
#  Peguntas de refinamento
A exclusão vai ser lógica ou total,
Não retornar um erro ao remover o projeto, retornar uma mensagem de informação.
Adicionar mais validações no cadastro de tarefa e de Projeto. EX. nomes requiridos.

# Melhorias
Melhoria a arquitetura, separaria a leitura da escrita CQRS.
Colocaria o padrão Command.
Trabalharia com banco NSQL  para quardar os eventos de mudança.



