
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

        const ultimaCelula = novaLinha.querySelector("td:last-child");
        if (ultimaCelula) {
            ultimaCelula.remove();
        }

        tabelaDestino.appendChild(novaLinha);
    });

    tabelaOrigem.innerHTML = "";
});

const btnSendPedido = document.getElementById("send-dados");
btnSendPedido.addEventListener("click", () => {

    // Cabeçalho
    const nameRepInput = document.getElementById("name-representante").value;
    const codRepInput = document.getElementById("cod-representante").value;
    const dataLanInput = document.getElementById("data-lancamento").value;
    const statusPed = document.getElementById("status-pedido").value;
    const faturamentoSelect = document.getElementById("faturamentoSelect").value;
    const prazoPagamentoSelect = document.getElementById("prazoPagamentoSelect").value;
    const retiradaSelect = document.getElementById('retiradaSelect').value;

    // Dados Cliente
    const codCli = document.getElementById('input-cod-cli').value
    const desPed = document.getElementById('inputDesconto').value
    const desSelector = document.getElementById('seletorDesconto').value
    const numPedCliInput = document.getElementById('num-ped-cli').value
    const entPedSelect = document.getElementById('ent-ped').value
    const agendSelect = document.getElementById('agendamentoSelect').value
    const datProgFatInput = document.getElementById('data-prog-ft').value
    const natVendInput = document.getElementById('nat-vend').value
    const obsPedText = document.getElementById('obs-ped').value


    // Dados Produto
    const tabelaDestino = document.getElementById("dados-produtos-pedido").querySelector("tbody");
    const linhasDestino = tabelaDestino.querySelectorAll("tr");

    const produtosPedido = [];

    linhasDestino.forEach(linha => {
        const colunas = linha.querySelectorAll("td");
        const obj = {};

        if (colunas.length >= 4) {
            obj.codigo = colunas[0].textContent.trim();
            obj.descricao = colunas[1].textContent.trim();
            obj.unidade = colunas[2].textContent.trim();
            obj.precounit = colunas[3].textContent.trim();
            obj.qunatidade = colunas[3].textContent.trim();
            obj.totalPed = colunas[3].textContent.trim();

            produtosPedido.push(obj);
        }
    });    

    const dadosPedido = {
        nameRepInput,
        codRepInput,
        dataLanInput,
        statusPed,
        faturamentoSelect,
        prazoPagamentoSelect,
        retiradaSelect,
        codCli,
        desPed,
        desSelector,
        numPedCliInput,
        entPedSelect,
        agendSelect,
        datProgFatInput,
        natVendInput,
        obsPedText,
        produtosPedido
    };

    console.log(dadosPedido)
})