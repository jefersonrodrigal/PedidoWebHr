
document.addEventListener("DOMContentLoaded", () => {

    const buttons = document.querySelectorAll(".btn-info-cliente");
    buttons.forEach(function (botao) {
        botao.addEventListener("click", function () {
            const id = botao.getAttribute("data-id");
            fetch(`https://localhost:7121/clientes/info/${id}`)
                .then(res => res.json())
                .then(data => {
                    document.getElementById("codCli").textContent = data.CodCli;
                    document.getElementById("NomFantCli").textContent = data.NomFantCli;
                    document.getElementById("UfCli").textContent = data.UfCli;
                    document.getElementById("Contato").textContent = data.Contato;
                    document.getElementById("Contato2").textContent = data.Contato2;
                    document.getElementById("Cgccpf").textContent = data.Cgccpf.toString().replace(/^(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})$/, "$1.$2.$3/$4-$5");
                    document.getElementById("NomCli").textContent = data.NomCli;
                    document.getElementById("Endereço").textContent = data.Endereço;
                    document.getElementById("CepCli").textContent = data.CepCli.toString().replace(/^(\d{2})(\d{3})(\d{3})$/, "$1.$2-$3");
                    document.getElementById("Cidade").textContent = data.Cidade;
                    document.getElementById("EmailCli").textContent = data.EmailCli;
                    document.getElementById("FaxCli").textContent = data.FaxCli;


                })
                .catch(err => console.error('Erro no GET:', err));

        });
    });

    const btnSearchClients = document.getElementById("btn-search-cliente");
    btnSearchClients.addEventListener('click', () => {
        const tbody = document.getElementById("tbl-dados-clientes");

        if (tbody.rows.length > 0) {
            return; 
        }

        const cliente = document.getElementById("input-search-client").value.replace(/[^\d]/g, "");
        const url = `https://localhost:7121/pedidos/lancamento-pedido/busca-cliente/${cliente}`;

        fetch(url)
            .then(response => {
                if (!response.ok) throw new Error("Erro ao buscar os dados da API");
                return response.json();
            })
            .then(cliente => {
                console.log(cliente)
                const linha = document.createElement("tr");
                linha.classList.add("linha-cliente-tb")
                linha.innerHTML = `
                    <th scope="row">${cliente.nomCli}</th>
                    <td>${formatarCnpj(cliente.cgccpf)}</td>
                    <td>${cliente.endereco}</td>
                    <td>${cliente.contato}</td>
                    <td><button type="button" class="btn corelementos"><i class="fa fa-plus"></i></button></td>
                `;
                tbody.appendChild(linha);

                // Atualiza os campos de cliente
                document.getElementById('cliente-razao_social').textContent = cliente.nomCli;
                document.getElementById('input-cod-cli').value = cliente.codCli
                document.getElementById('cliente-denominacao').textContent = cliente.nomFantCli;
                document.getElementById('cliente-cnpj').textContent = cliente.cgccpf;
                document.getElementById('cliente-cidade').textContent = cliente.cidade;
                document.getElementById('cliente-bairro').textContent = cliente.bairro;
                document.getElementById('cliente-cep').textContent = cliente.cepCli;
                document.getElementById('cliente-endereco').textContent = cliente.endereco;
                document.getElementById('cliente-estado').textContent = cliente.ufCli;
                document.getElementById('cliente-insc_est').textContent = cliente.inscEstadual;
                document.getElementById('cliente-telefone').textContent = cliente.contato;
                document.getElementById('cliente-email').textContent = cliente.emailCli;
                document.getElementById('cliente-fax').textContent = cliente.fax;

                const overlay = document.getElementById('overlay');
                overlay.style.display = 'block';
                setTimeout(() => {
                    overlay.style.display = 'none';
                }, 1000);

                const input = document.getElementById('input-search-client');
                input.value = '';
            })
            .catch(erro => {
                console.error("Erro ao carregar os dados:", erro);
                btn.disabled = false; // só reabilita se houver erro
            });

        function formatarCnpj(cgccpf) {
            const str = cgccpf.toString();
            return str.length === 14
                ? str.replace(/^(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})$/, "$1.$2.$3/$4-$5")
                : str.replace(/^(\d{3})(\d{3})(\d{3})(\d{2})$/, "$1.$2.$3-$4");
        }
    });

    const btnSearchProducts = document.getElementById("btn-search-products");
    btnSearchProducts.addEventListener('click', () => {
        const productInput = document.getElementById('input-search-products');
        const productName = productInput.value.trim();

        if (!productName) return alert("Digite o nome ou código do produto.");

        const url = `https://localhost:7121/pedidos/lancamento-pedido/busca-produto/${encodeURIComponent(productName)}`;

        fetch(url)
            .then(response => {
                if (!response.ok) throw new Error("Produto não encontrado.");
                
                return response.json();
            })
            .then(prod => {
                console.log(prod)
                const tbody = document.getElementById("tbl-dados-produtos");
                const linha = document.createElement("tr");

                const priceId = `price-${prod.codpro}`;
                const qtyId = `qty-${prod.codpro}`;
                const totalId = `total-${prod.codpro}`;

                linha.innerHTML = `
             <td>${prod.codpro}</td>
             <td>${prod.desnfv}</td>
             <td>${prod.unimed}</td>
             <td>
                 <input type="text" class="form-control price-input" id="${priceId}" placeholder="R$ 0,00" required />
             </td>
             <td>
                 <input type="number" class="form-control" id="${qtyId}" placeholder="Quantidade" min="0" step="1" required />
             </td>
             <td id="${totalId}">R$ 0,00</td>
             <td>
                 <button type="button" class="btn corelementos"><i class="fa fa-minus"></i></button>
             </td>
         `;

                tbody.appendChild(linha);

                const overlay = document.getElementById('overlay');
                overlay.style.display = 'block';
                setTimeout(() => overlay.style.display = 'none', 1000);

                productInput.value = '';

                const inputPrice = document.getElementById(priceId);
                const inputQty = document.getElementById(qtyId);
                const totalCell = document.getElementById(totalId);

                // Função para formatar valor em R$ ao digitar
                const formatCurrency = (value) => {
                    const cleanValue = value.replace(/\D/g, '');
                    const numberValue = parseFloat(cleanValue) / 100;
                    return numberValue.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
                };

                // Atualiza o total conforme inputs
                const atualizarTotal = () => {
                    const precoFormatado = inputPrice.value.replace(/\D/g, '');
                    const preco = parseFloat(precoFormatado) / 100 || 0;
                    const quantidade = parseFloat(inputQty.value) || 0;
                    const total = preco * quantidade;
                    totalCell.textContent = total.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
                };

                // Formata valor enquanto digita
                inputPrice.addEventListener('input', (e) => {
                    const cursorPos = e.target.selectionStart;
                    const oldLength = e.target.value.length;

                    e.target.value = formatCurrency(e.target.value);
                    atualizarTotal();

                    // Ajusta posição do cursor após formatação
                    const newLength = e.target.value.length;
                    e.target.setSelectionRange(cursorPos + (newLength - oldLength), cursorPos + (newLength - oldLength));
                });

                inputQty.addEventListener('input', atualizarTotal);
            })
            .catch(error => {
                console.error("Erro ao buscar produto:", error);
                /*
                const errorModalBody = document.getElementById("errorModalBody");
                errorModalBody.textContent = "Erro ao buscar produto: " + error.message;
   
                // Exibir o modal
                const modal = new bootstrap.Modal(document.getElementById('errorModal'));
                modal.show();
                */
            });
    });

    const btnSendPedido = document.getElementById("send-dados");
    btnSendPedido.addEventListener("click", () => {

        // Cabeçalho
        const datEmi = document.getElementById("data-lancamento").value;
        const obsPed = document.getElementById('obs-ped').value;
        const codCli = parseInt(document.getElementById('input-cod-cli').value);
        const codRep = parseInt(document.getElementById("cod-representante").value);
        const codCpg = parseInt(document.getElementById("prazoPagamentoSelect").value);
        const pedCli = document.getElementById('num-ped-cli').value;
        const datPrv = document.getElementById('data-prog-ft').value;
        const pedIme = parseInt(document.getElementById('ent-ped').value);
        const tipFat = parseInt(document.getElementById("faturamentoSelect").value);
        const natOpe = parseInt(document.getElementById('nat-vend').value);
        const perDsc = parseFloat(document.getElementById('inputDesconto').value);
        const sitPpd = document.getElementById("status-pedido").value;
        const tipDis = parseInt(document.getElementById('seletorDesconto').value);
        const retMer = document.getElementById('retiradaSelect').value;
        const necAge = document.getElementById('agendamentoSelect').value;
        
        // Dados Produto
        const tabelaDestino = document.getElementById("dados-produtos-pedido").querySelector("tbody");
        const linhasDestino = tabelaDestino.querySelectorAll("tr");

        const products = [];

        linhasDestino.forEach(linha => {
            const colunas = linha.querySelectorAll("td");
            const obj = {};

            if (colunas.length >= 4) {
                obj.codPro = colunas[0].textContent.trim();
                obj.qtdPed = parseFloat(colunas[4].textContent.trim());
                obj.desNfv = colunas[1].textContent.trim();
                obj.uniMed = colunas[2].textContent.trim();
                obj.preUni = parseFloat(colunas[3].textContent.trim().slice(3));
                obj.vlrTot = parseFloat(colunas[5].textContent.trim().slice(3));

                products.push(obj);
            }
        });

        const dadosPedido = {
            datEmi,
            obsPed,
            codCli,
            codRep,
            codCpg,
            pedCli,
            datPrv,
            pedIme,
            tipFat,
            natOpe,
            perDsc,
            sitPpd,
            tipDis,
            retMer,
            necAge,
            products
        }

        async function sendData(data) {
            try {
                const response = await fetch("https://localhost:7121/pedidos/lancamento-pedido/lancamento", {
                    method: 'POST',
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify(data)
                });

                const content = await response.json();

                if (!response.ok) {
                    throw new Error(content.message || "Erro ao enviar dados");
                }

                console.log('Sucesso', content);
            } catch (error) {
                console.log('Erro na requisição:', error.message);
            }
        }

        sendData(dadosPedido)

    })

   
})
