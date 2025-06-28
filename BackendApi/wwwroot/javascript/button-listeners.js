const btnRemoveClient = document.getElementById("btn-remove-itens-td");

btnRemoveClient.addEventListener("click", () => {
    const lines = document.querySelectorAll('.linha-cliente');
    lines.forEach(line => {
        line.innerText = '';
    });

    const linhas = document.querySelectorAll('.linha-cliente-tb');
    linhas.forEach(linha => linha.remove());

})