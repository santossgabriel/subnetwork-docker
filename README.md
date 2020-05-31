## **Laboratório para estudo de segurança em Aplicações WEB**

**Descrição:** Este projeto vem com o objetivo de automatizar a criação de um ambiente virtual, para facilitar a prática e entendimento de alguns conceitos básicos de segurança em aplicações WEB.

### 1. Requisitos:
* <a href="https://docs.docker.com/get-started/">Docker</a>.
* <a href="https://docs.docker.com/compose/install/">Docker Compose</a>.
* <a href="https://www.virtualbox.org/wiki/Downloads">Virtual Box</a> para acessar a rede interna.
### 2. Configuração do ambiente
* Todas as imagens do docker devem ser construídas utilizando o arquivo de build, como a imagem base é dependencia para as demais, é sugerido seguir a ordem:
  ```
  $ ./build.sh 1
  $ ./build.sh 2
  $ ./build.sh 3
  $ ./build.sh 4
  $ ./build.sh 5
  $ ./build.sh 6
  $ ./build.sh 7
  ```
    * Caso ocorra erro de permissão execute o arquivo de build como root, adicione o usuário logado ao grupo **docker** criado na instalação do docker.
      ```
      $ sudo usermod -aG docker $USER
      ```

* Subir os containers com o docker compose, para isso, no diretório do arquivo docker-compose.yaml, um dos commandos deve ser executado. O parâmetro **-d** é para não travar o terminal e exibir os logs:
  ```
  $ docker-compose up
  $ docker-compose up -d
  ```

* Utilizar o Virtual Box ou configurar uma rede virtual:
  
  * Virtual box
    * Configurar o adaptador de rede

      ![](images/vbox_adapter_config.png?raw=true)

    * Configurar um ip estático com a rede 172.20.20.0/24, gateway e dns.

      ![](images/ip_config.png?raw=true)
    
    * Valide a configuração acessando http://mail.fakebank.lab

  * Rede virtual
    * TODO