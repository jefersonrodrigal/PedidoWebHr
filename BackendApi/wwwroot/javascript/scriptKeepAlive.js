setInterval(function () {
    fetch('https://localhost:7121/pedidos/keepalive')
        .then(response => {
            if (!response.ok) throw new Error('Falha no keep-alive');
            console.log('Keep-alive enviado com sucesso');
        })
        .catch(error => {
            console.error('Erro ao manter sessão viva:', error);
        });
}, 1 * 60 * 1000); 