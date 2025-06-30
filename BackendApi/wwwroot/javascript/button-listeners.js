
const btnRemoveClient = document.getElementById("btn-remove-itens-td");
btnRemoveClient.addEventListener("click", () => {
        const lines = document.querySelectorAll('.linha-cliente');
        lines.forEach(line => {
            line.innerText = '';
        });

        const linhas = document.querySelectorAll('.linha-cliente-tb');
        linhas.forEach(linha => linha.remove());

})

document.querySelector("#dados-produtos").addEventListener("click", function (e) {
    console.log("Encontrei a tabela")
    if (e.target.closest(".corelementos")) {
        const linha = e.target.closest("tr");
        if (linha) {
            linha.remove();
        }
    }
});

const btnInclude = document.getElementById("btn-include");
btnInclude.addEventListener("click", function () {
    const tabelaOrigem = document.getElementById("dados-produtos").querySelector("tbody");
    const tabelaDestino = document.getElementById("dados-produtos-pedido").querySelector("tbody");

    const linhas = tabelaOrigem.querySelectorAll("tr");

    linhas.forEach(linha => {
        const novaLinha = linha.cloneNode(true);

        // Substituir inputs por texto
        const inputs = novaLinha.querySelectorAll("input");
        inputs.forEach(input => {
            const valor = input.value;
            const texto = document.createTextNode(valor);
            input.parentNode.replaceChild(texto, input);
        });

        // Remove última célula se necessário
        const ultimaCelula = novaLinha.querySelector("td:last-child");
        if (ultimaCelula) {
            ultimaCelula.remove();
        }

        tabelaDestino.appendChild(novaLinha);
    });

    // Limpa a tabela de origem
    tabelaOrigem.innerHTML = "";
});