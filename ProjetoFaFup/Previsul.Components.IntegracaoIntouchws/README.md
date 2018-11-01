## Componente de Integração com a Intouch

### Objetivo
Efetuar uma consulta no WebService e retornar dados de pessoas físicas ou jurídicas.

### Exemplo de Utilização via SOAPUI
1. Utilizar a URL
  http://wsi4.unitfour.com.br/intouchws.asmx?wsdl

2. Consumir o método "Gerar Token"
  Verificar dados de autenticação no PSI#3742

3. Utilizar o Token gerado no "header" do xml para o método a ser utilizado, por exemplo:
```
> <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:tem="http://tempuri.org/">
   <soapenv:Header>
      <tem:Credencial>
               <tem:Token>UFJFVklTVUx8ZnJMQjExd2gvU2I3UkNhR3F1K0h5QT09fGNhaXhhfDEwNDA0MXwxMDEwMjAxODA5MzUwM3wyOjExOzI6MTI7MjoxMzsyOjE0OzI6MTY7MjoxNzsyOjE4OzI6MTk7MjoyMDsyOjIxOzI6MjI7MjoyMzsyOjI0OzI6MjU7MjoyNjsyOjI5OzI6MzA7MjozMTsyOjMyOzI6MzM7MjozNDsyOjM4OzI6Mzk7Mjo0MDsyOjQxOzI6NDI7Mjo0MzsyOjQ0OzI6NTE7Mjo1NDsyOjU1OzI6NTY7Mjo1NzsyOjU4OzI6NTk7Mjo2MjsyOjYzOzI6NjQ7Mjo2NTsyOjY3OzI6Njg7Mjo2OTsyOjcwOzI6MTE5OzI6MTIwOzI6MTIxOzI6MTIyOzI6MTIzOzI6MTI0OzI6MTI1OzI6MTI2OzI6MTI3OzI6MTI4OzI6MTI5OzI6MTMwOzI6MTMxOzI6MTMyOzI6MTQwOzI6MTQxOzI6MTQyOzI6MTQzOzI6MTQ0OzI6MTQ1OzI6MTU5OzI6MTYwOzI6MTY5OzI6MTcwfDEzMzcxMzAzOHw2Njh8</tem:Token>
      </tem:Credencial>
   </soapenv:Header>
   <soapenv:Body>
      <tem:LocalizaPessoas>
         <tem:documento>99999999999</tem:documento>
         <tem:tipoPessoa>PF</tem:tipoPessoa>
      </tem:LocalizaPessoas>
   </soapenv:Body>
</soapenv:Envelope>
```
