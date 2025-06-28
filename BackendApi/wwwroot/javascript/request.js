
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

    const btnSearchProducts = document.getElementById("btn-search-products")
    btnSearchProducts.addEventListener('click', () => {
        const product = document.getElementById('input-search-products').value
        const url = `https://localhost:7121/pedidos/lancamento-pedido/busca-produto/${encodeURIComponent(product)}`

        fetch(url)
            .then(data => data.json())
            .then(product => {
                console.log(product)
                const tbody = document.getElementById("tbl-dados-produtos");
                const linha = document.createElement("tr");

                linha.innerHTML = `
                <th scope="row">${product.cod_pro}</th>
                <td>${product.desc_pro}</td>
                <td>
                   <label class="visually-hidden" for="specificSizeInputName">Produtos</label>
                   <input type="text" class="form-control" id="specificSizeInputName" placeholder="Quantidade" required />
                </td>
                <td>
                    <label class="visually-hidden" for="specificSizeInputName">Produtos</label>
                    <input type="text" class="form-control" id="specificSizeInputName" placeholder="Preço Unit.:" required />
                </td>
                <td> <button type="button" class="btn corelementos"><i class="fa fa-minus"></i></button></td>`;

                tbody.appendChild(linha);

                const overlay = document.getElementById('overlay');
                overlay.style.display = 'block';

                setTimeout(() => {
                    overlay.style.display = 'none';
                }, 1000);

                const input = document.getElementById('input-search-products')
                input.value = '';

            })
            .catch(error => console.log(error))
    });

})
