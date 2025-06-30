
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
                const linha = document.createElement("tr");
                linha.classList.add("linha-cliente-tb")
                linha.innerHTML = `
                    <th scope="row">${cliente.nom_cli}</th>
                    <td>${formatarCnpj(cliente.cgccpf)}</td>
                    <td>${cliente.endereco}</td>
                    <td>${cliente.contato}</td>
                    <td><button type="button" class="btn corelementos"><i class="fa fa-plus"></i></button></td>
                `;
                tbody.appendChild(linha);

                // Atualiza os campos de cliente
                document.getElementById('cliente-razao_social').textContent = cliente.nom_cli;
                document.getElementById('cliente-denominacao').textContent = cliente.nom_fant_cli;
                document.getElementById('cliente-cnpj').textContent = cliente.cgccpf;
                document.getElementById('cliente-cidade').textContent = cliente.cidade;
                document.getElementById('cliente-bairro').textContent = cliente.bairro;
                document.getElementById('cliente-cep').textContent = cliente.cep_cli;
                document.getElementById('cliente-endereco').textContent = cliente.endereco;
                document.getElementById('cliente-estado').textContent = cliente.uf_cli;
                document.getElementById('cliente-insc_est').textContent = cliente.insc_estadual;
                document.getElementById('cliente-telefone').textContent = cliente.contato;
                document.getElementById('cliente-email').textContent = cliente.email_cli;
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
                const tbody = document.getElementById("tbl-dados-produtos");
                const linha = document.createElement("tr");

                const priceId = `price-${prod.cod_pro}`;
                const qtyId = `qty-${prod.cod_pro}`;
                const totalId = `total-${prod.cod_pro}`;

                linha.innerHTML = `
             <td>${prod.cod_pro}</td>
             <td>${prod.desc_pro}</td>
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

})
