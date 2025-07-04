window.addEventListener('DOMContentLoaded', event => {

    // Toggle the side navigation
    const sidebarToggle = document.body.querySelector('#sidebarToggle');
    if (sidebarToggle) {
        // Uncomment Below to persist sidebar toggle between refreshes
        // if (localStorage.getItem('sb|sidebar-toggle') === 'true') {
        //     document.body.classList.toggle('sb-sidenav-toggled');
        // }
        sidebarToggle.addEventListener('click', event => {
            event.preventDefault();
            document.body.classList.toggle('sb-sidenav-toggled');
            localStorage.setItem('sb|sidebar-toggle', document.body.classList.contains('sb-sidenav-toggled'));
        });
    }

});


let debounceTimeout;
let body = document.querySelector('body');
let scrollingElement = document.scrollingElement;

setScrollClass();

window.addEventListener('scroll', setScrollClass);
window.addEventListener('resize', setScrollClass);

function setScrollClass() {
  if (debounceTimeout) {
    window.cancelAnimationFrame(debounceTimeout);
  }

  debounceTimeout = window.requestAnimationFrame(function () {
    let scrollTop = scrollingElement.scrollTop;
    let scrollHeight = scrollingElement.scrollHeight;
    let innerHeight = window.innerHeight;
    let scrollBottom = scrollHeight - innerHeight - scrollTop;

    body.classList.toggle('at-top', scrollTop < 48);
    body.classList.toggle('at-bottom', scrollBottom < 48);
  });
}

var dropdown = document.getElementsByClassName("dropdown-btn");
var i;

for (i = 0; i < dropdown.length; i++) {
  dropdown[i].addEventListener("click", function() {
    this.classList.toggle("active");
    var dropdownContent = this.nextElementSibling;
    if (dropdownContent.style.display === "block") {
      dropdownContent.style.display = "none";
    } else {
      dropdownContent.style.display = "block";
    }
  });
}

const campoAnterior = document.getElementById('inputDesconto');
const meuSeletor = document.getElementById('seletorDesconto');

campoAnterior.addEventListener('input', function () {
    if (campoAnterior.value.trim() !== '') {
        meuSeletor.disabled = false;
    } else {
        meuSeletor.disabled = true;
    }
});

// Formatacao de campo de desconto
document.getElementById('inputDesconto').addEventListener('input', function (e) {
    let valor = e.target.value.replace(/\D/g, '');
    valor = (parseFloat(valor) / 100).toFixed(2) + '%';
    e.target.value = valor.replace('.', ',');
});


// Formata cnpj e CPF 
function formatarCpfCnpj(valor) {
    // Remove tudo que não é número
    valor = valor.replace(/\D/g, '');

    if (valor.length <= 14) {
        // Formata como CNPJ: 00.000.000/0000-00
        valor = valor.replace(/^(\d{2})(\d)/, '$1.$2');
        valor = valor.replace(/^(\d{2})\.(\d{3})(\d)/, '$1.$2.$3');
        valor = valor.replace(/\.(\d{3})(\d)/, '.$1/$2');
        valor = valor.replace(/(\d{4})(\d)/, '$1-$2');
    } else {
        // Formata como CPF: 000.000.000-00
        valor = valor.replace(/(\d{3})(\d)/, '$1.$2');
        valor = valor.replace(/(\d{3})(\d)/, '$1.$2');
        valor = valor.replace(/(\d{3})(\d{1,2})$/, '$1-$2');
    }

    return valor;
}

document.querySelector('#input-search-client').addEventListener('input', function (e) {
    e.target.value = formatarCpfCnpj(e.target.value);
});

const input = document.getElementById('input-search-products');

input.addEventListener('input', function (e) {
    let valor = e.target.value;

    // Verifica se já tem um prefixo com traço
    const match = valor.match(/^([A-Za-z]+)-(\d*)$/);
    let prefixo = '';
    let numeros = '';

    if (match) {
        prefixo = match[1];
        numeros = match[2].replace(/\D/g, '');
    } else {
        // Se não tiver traço, assume o início como prefixo
        const partes = valor.split('-');
        prefixo = partes[0].replace(/[^A-Za-z]/g, '');
        numeros = partes[1] ? partes[1].replace(/\D/g, '') : '';
    }

    // Formata com o prefixo atual
    e.target.value = prefixo ? `${prefixo}-${numeros}` : numeros;
});

input.addEventListener('keydown', function (e) {
    // Se pressionar backspace com cursor na primeira posição ou logo após o prefixo, limpa tudo
    const pos = input.selectionStart;
    if (e.key === 'Backspace' && pos <= 2) {
        e.preventDefault();
        input.value = '';
    }
});





