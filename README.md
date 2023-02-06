# PoC Serilog, InfluxDB e Grafana

PoC para validar o log da aplicação utilizando Serilog, gravando as informações no InfluxDB e exibindo as informações em dashboard com Grafana.
Todas as ações executadas na API são logadas no InfluxDb.

<table>
  <tr>
    <th></th>
    <th>Tecnologia</th>
    <th>Versão</th>
    <th>Ferramentas</th>    
  </tr>
  <tr>
    <td><img align="center" alt="Rafa-Csharp" height="30" width="40" src="https://icongr.am/devicon/dot-net-original.svg?size=40"></td>
    <td>.Net Core</td>
    <td>7.0</td>
    <td><a href="https://serilog.net">Serilog</a></td>
  </tr>
  <tr>
    <td><img align="center" alt="Rafa-Csharp" height="30" width="40" src="https://icongr.am/devicon/csharp-original.svg?size=40"></td>
    <td>C#</td>
    <td>10.0</td>
    <td></td>
  </tr>    
  <tr>
    <td><img align="center" alt="Rafa-Csharp" height="30" width="40" src="https://icongr.am/devicon/visualstudio-plain.svg?size=40"></td>
    <td>Visual Studio</td>
    <td>2022 Community</td>
    <td></td>
  </tr>    
  <tr>
    <td><img align="center" alt="Rafa-Csharp" height="30" width="40" src="https://icongr.am/devicon/git-original.svg?size=40"></td>
    <td>Git</td>
    <td>lasted</td>
    <td><a href="https://docs.github.com/pt/get-started/quickstart/github-flow">Github Flow</a></td>    
  </tr>  
  <tr>
    <td><img align="center" alt="Rafa-Csharp" height="30" width="40" src="https://www.svgrepo.com/show/353901/influxdb.svg?size=40"></td>
    <td><a href="https://www.influxdata.com/products/influxdb/">InfluxDB</a></td>
    <td>lasted</td>
    <td></td>    
  </tr> 
  <tr>
    <td><img align="center" alt="Rafa-Csharp" height="30" width="40" src="https://www.vectorlogo.zone/logos/grafana/grafana-icon.svg?size=40"></td>
    <td><a href="https://grafana.com/">Grafana</a></td>
    <td>lasted</td>
    <td></td>    
  </tr> 
  <tr>
    <td><img align="center" alt="Rafa-Csharp" height="30" width="40" src="https://icongr.am/devicon/docker-original.svg?size=40"></td>
    <td><a href="https://www.docker.com/">Docker</a></td>
    <td>lasted</td>
    <td><a href="https://docs.docker.com/compose">Docker Compose</a></td>    
  </tr>
</table>

# Executando a aplicação

- Abra o terminal da sua máquina, caso esteja utilizando o Windows o CMD, caso esteja utilizando o Linux o bash;

- Entre no diretorio /src e execute o comando abaixo:
```bash
docker compose up -d
```

- Acesse o painel administrativo do **grafana** através do endereço: http://localhost:3000/;

- Na pagina inicial clique sobre "Add your first data source";

- Encontre e clique no data source **InfluxDb**;

- Preencha o formulário com as informações abaixo:
```
Query Language = Flux

URL = http://influxdb:8086

Organization = logapi

Token = 9859DAA6-3B3F-48FE-A981-AE9D31FBB334

Default Bucket = logapi
```

- Por fim, clique o=no botão "Save & test";

- Agora basta você voltar para a home do grafana e montar seu primeiro dashboard clicando em "Create you first dashboard".
