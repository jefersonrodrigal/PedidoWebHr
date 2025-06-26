document.addEventListener('DOMContentLoaded', function () {
    const campos = [
        'faturamentoSelect',
        'prazoPagamentoSelect',
        'retiradaSelect',
        'agendamentoSelect'
    ];

    // Restaurar valores salvos
    campos.forEach(id => {
        const select = document.getElementById(id);
        const valorSalvo = localStorage.getItem(id);
        if (select && valorSalvo) {
            select.value = valorSalvo;
        }
    });

    // Salvar ao clicar no botão
    document.getElementById('salvarDados').addEventListener('click', function () {
        campos.forEach(id => {
            const select = document.getElementById(id);
            if (select) {
                localStorage.setItem(id, select.value);
            }
        });

        // Mostrar overlay
        const overlay = document.getElementById('overlay');
        overlay.style.display = 'block';

        // (Opcional) Esconder após 2 segundos
        setTimeout(() => {
            overlay.style.display = 'none';
        }, 2000);
    });
});


const nome = localStorage.getItem("faturamentoSelect");
console.log(nome);

const valorSalvo = localStorage.getItem("faturamentoSelect");
const select = document.getElementById("faturamentoSelect");

if (select) {
    const optionSelecionada = [...select.options].find(opt => opt.value === valorSalvo);
    if (optionSelecionada) {
        console.log(optionSelecionada.text); // ← aqui está o texto visível
    }
}
