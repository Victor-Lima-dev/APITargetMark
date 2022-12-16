# APITargetMark

# TargetMarkAPI

Esse é um projeto iniciante para um estudante de backend, mas com potencial para crescer. É uma empresa que atende às necessidades das empresas que querem criar campanhas de marketing e enviar mensagens em massa com base no público-alvo, além de oferecer relatórios de desempenho, pode ser uma opção viável.

O nome da empresa  é "TargetMark", já que ela irá ajudar as empresas a atingir seus públicos-alvo de maneira mais eficiente através do envio de mensagens em massa e do fornecimento de relatórios detalhados.

## Funções Presentes

 - Possui um CRUD para Clientes
   		 - Endpoint para listar os clientes **/clientes**
   		 - Endpoint para cadastrar clientes **/cadastrar**
   		 - Endpoint para editar clientes **Editar/{id}**
   		 - Endpoint para deletar clientes **/Deletar**
   		 - Endpoint para buscar clientes a partir do id **Buscar/Cliente/{id}**
   		 - Buscar Clientes por genero **Buscar/Genero/{genero}** 
   		 - Buscar Clientes por regiao **Buscar/Regiao/{regiao}**
   	 - Para cadastrar e editar existe um método para verificar se o cliente
   	   ta 			duplicado e para verificar se o parametro Genero ta    correto
   	   .
 - Possui um CRUD para Campanha
		 - Endpoint para listar os campanhas **/campanhas**
		 - Endpoint para criar campanha **/campanhas/Criar**
		 - Endpoint para editar campanha **/campanhas/Editar**
		 - Endpoint para deletar campanha **/campanhas/Deletar**
		 
		  
 - Possui um CRUD para Empresa
		 - Endpoint para listar as empresas 
		 - Endpoint para criar empresa
		 - Endpoint para editar empresa
		 - Endpoint para deletar empresa

 - Possui um CRUD para Mensagem
		 - Endpoint para listar as mensagens
		 - Endpoint para criar mensagem
		 - Endpoint para editar mensagem
		 - Endpoint para deletar mensagem

 - Possui um CRUD para Relatorio
		 - Endpoint para listar os relatorios
		 - Endpoint para criar relatorio
		 - Endpoint para editar relatorio
		 - Endpoint para deletar relatorio

 - Autentificação JWT

## Tecnologias Utilizadas

 - **ASPNET**
 - **.NET**
 - **EntityFramework**
 - **SqlServer**
 - **Swagger**
 - **JSON WEB TOKEN**
