# Crud Modal Usando C# ASP.NET Core MVC
Crud Modal em C# ASP.Net Core MVC#
Exemplo de um Crud Modal utilizando ASP.NET Core MVC 

## Proposta
Criar um crud onde as views serão chamadas de forma modal, neste exemplo utilizei o banco Firebird.

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

