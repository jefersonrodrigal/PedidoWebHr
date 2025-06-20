const buttons = document.querySelectorAll(".btn-info-cliente");

buttons.forEach(function (botao) {
    botao.addEventListener("click", function () {
        const id = botao.getAttribute("data-id");
        fetch(`https://localhost:7121/clientes/representante/cliente/${id}`)
            .then(res => res.json())
            .then(data => {
                document.getElementById("codCli").textContent = data.CodCli;
                document.getElementById("NomFantCli").textContent = data.NomFantCli;
                document.getElementById("UfCli").textContent = data.UfCli;
                document.getElementById("Contato").textContent = data.Contato;
                document.getElementById("Contato2").textContent = data.Contato2;
                document.getElementById("Cgccpf").textContent = data.Cgccpf;
                document.getElementById("NomCli").textContent = data.NomCli;
                document.getElementById("Endereço").textContent = data.Endereço;
                document.getElementById("CepCli").textContent = data.CepCli;
                document.getElementById("Cidade").textContent = data.Cidade;
                document.getElementById("EmailCli").textContent = data.EmailCli;
                document.getElementById("FaxCli").textContent = data.FaxCli;
            })
            .catch(err => console.error('Erro no GET:', err));
        
    });
});