# Tabelas Dinâmicas com JQUERY#
Exemplo de como criar um Table Html dinamicamente utilizando JQUERY

## Proposta
Criar uma matriz estilo excel e depois preencher algumas colunas dinamicamente

# [Views Modais](#)

## Primeiramente definimos o código javascript onde sera feita a chamada modal em cada clique do botão
```javascript
<script>
    $(function () {
        $(".details").click(function () {
            var id = $(this).attr("data-id");
            $("#modal").load("/Paciente/Details?id=" + id, function () {
                $("#modal").modal();
            })
        });

        $(".edit").click(function () {
            var id = $(this).attr("data-id");
            $("#modal").load("/Paciente/Edit?id=" + id, function () {
                $("#modal").modal();
            })
        });

        $(".delete").click(function () {
            var id = $(this).attr("data-id");
            $("#modal").load("/Paciente/Delete?id=" + id, function () {
                $("#modal").modal();
            })
        });

        $(".create").click(function () {
            $("#modal").load("/Paciente/Create", function () {
                $("#modal").modal();
            })
        });

    })
</script> 
```
No Exemplo acima, foi criado o titulo das colunas, para isso criei um array do alfabeto para definir o nome de cada coluna


## Montando os Campos dinamicamente#

Criaremos os campos de acordo com a quantidade de colunas e linhas definidas

```javascript
  html = html + "<tbody>";	   	   
	   
	   
       nomeColuna = "";	   	   
	   for (x=0; x < numeroLinhas; x++)
	   {	   	  	  
	      html = html + "<tr >"; 				 	 
	      for (i=0; i < numeroColunas; i++)
	      {
		    nomeColuna =  letrasAlfabeto[i] + numeroLinha;
	        html = html + "<td id='" + nomeColuna + "'>-</td>";
	      }
          html = html + "</tr> ";				   	   	 
		  numeroLinha = numeroLinha + 1;	
       }
       html = html + "</tbody>";

```

Com isso, no nosso controller atráves de requisições POST obtemos os dados vindo de cada tela. Exemplo:

```javascript
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(include: "IdPaciente,Nome,Idade,Peso,Altura")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                PacienteDAL pd = new PacienteDAL();
                pd.InserirPaciente(paciente);
                return RedirectToAction("Index","Paciente");
            }


            return View(paciente);
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(include: "IdPaciente,Nome,Idade,Peso,Altura")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                PacienteDAL pd = new PacienteDAL();
                pd.EditarPaciente(paciente);
                return RedirectToAction("Index");
            }
            return View(paciente);
        }        
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PacienteDAL pd = new PacienteDAL();
            pd.DeletarPaciente(id);
            return RedirectToAction("Index");
        }        

```

