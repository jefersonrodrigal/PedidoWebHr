﻿function criarElementoCliente() {
    // Verifica se já existe um elemento com o ID "cliente-razao_social"
    if (!document.getElementById("cliente-razao_social")) {
        const html = `
        <div class="row mb-5">
            <div class="col">
                Razão Social: <b class="titulo-card linha-cliente" id="cliente-razao_social"></b>
                <input required id="input-cod-cli" type="hidden" class="form-control" value="" disabled />
            </div>
            <div class="col">
                Denominação: <b class="titulo-card linha-cliente" id="cliente-denominacao"></b>
            </div>
            <div class="col">
                CNPJ/CPF: <b class="titulo-card linha-cliente" id="cliente-cnpj"></b>
            </div>
            <div class="col">
                Cidade: <b class="titulo-card linha-cliente" id="cliente-cidade"></b>
            </div>
        </div>
        <div class="row mb-5">
            <div class="col">
                Bairro: <b class="titulo-card linha-cliente" id="cliente-bairro"></b>
            </div>
            <div class="col">
                CEP: <b class="titulo-card linha-cliente" id="cliente-cep"></b>
            </div>
            <div class="col">
                Endereço/N°: <b class="titulo-card linha-cliente" id="cliente-endereco"></b>
            </div>
            <div class="col">
                Estado: <b class="titulo-card linha-cliente" id="cliente-estado"></b>
            </div>
        </div>
        <div class="row mb-5">
            <div class="col">
                Insc.Est: <b class="titulo-card linha-cliente" id="cliente-insc_est"></b>
            </div>
            <div class="col">
                Telefone: <b class="titulo-card linha-cliente" id="cliente-telefone"></b>
            </div>
            <div class="col">
                Email: <b class="titulo-card linha-cliente" id="cliente-email"></b>
            </div>
            <div class="col">
                Fax: <b class="titulo-card linha-cliente" id="cliente-fax"></b>
            </div>
        </div>`;

        // Cria um contêiner e insere o HTML nele
        const container = document.createElement("div");
        container.innerHTML = html;

        // Adiciona ao final do body
        document.body.appendChild(container);
    }
}

// Chama a função para garantir que os elementos estejam presentes
criarElementoCliente();