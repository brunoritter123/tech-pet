# Tech Pet

[![Run in Insomnia}](https://insomnia.rest/images/run.svg)](https://insomnia.rest/run/?label=Tech-Pet&uri=https%3A%2F%2Fgithub.com%2Fbrunoritter123%2Ftech-pet%2Fblob%2Fmaster%2Fresources%2Finsomnia%2FInsomnia.json)


Subir compose inteiro
```bash
podman-compose --file docker-compose.yml up --detach
```

Re-criar container da api com as atualizações do projeto
```bash
podman-compose --file docker-compose.yml up --detach --build api
```