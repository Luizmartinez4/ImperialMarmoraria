export function FormataCelular(celularInput) {
    // Faz a formatação do telefone
    celularInput.addEventListener('keydown', function (e) {
        const cursor = celularInput.selectionStart;
        const key = e.key;

        // Se a tecla for Backspace
        if (key === 'Backspace') {
            const valor = celularInput.value;
            const isCharFixo = /\D/.test(valor[cursor - 1]);

            // Se for um caracter fixo e o cursor for maior que 0
            if (isCharFixo && cursor > 0) {
                e.preventDefault(); // Impede o backspace padrão

                // Move o cursor para trás até achar um número
                let novaPos = cursor - 1;
                //Enquanto não achar um numero ele decrementa a novaPos
                while (novaPos > 0 && /\D/.test(valor[novaPos - 1])) {
                    novaPos--;
                }

                // Remove o número correspondente
                const numeros = valor.replace(/\D/g, '');
                const indexNumero = contarNumerosAntes(valor, novaPos);
                const novoNumeros = numeros.slice(0, indexNumero - 1) + numeros.slice(indexNumero);

                aplicarMascara(novoNumeros, novaPos - 1); // aplica a máscara e define o cursor
            }
        }
    });

    // Evento padrão para aplicar máscara em qualquer input
    celularInput.addEventListener('input', function (e) {
        const numeros = e.target.value.replace(/\D/g, '');
        aplicarMascara(numeros);
    });

    // Função que conta quantos números existem antes de uma certa posição
    function contarNumerosAntes(texto, posicao) {
        let count = 0;
        for (let i = 0; i < posicao; i++) {
            if (/\d/.test(texto[i])) {
                count++;
            }
        }
        return count;
    }

    // Aplica a máscara com base nos dígitos e coloca o cursor na posição correta
    function aplicarMascara(numeros, forcarCursor = null) {
        const mascara = '(__) _____-____';

        // Se não há nenhum número, deixa o input vazio e sai
        if (!numeros || numeros.length === 0) {
            celularInput.value = '';
            return;
        }

        let resultado = '';
        let i = 0;
        let posCursor = 0;

        for (let index = 0; index < mascara.length; index++) {
            if (mascara[index] === '_') {
                if (numeros[i]) {
                    resultado += numeros[i];
                    i++;
                } else {
                    resultado += '_';
                    if (posCursor === 0) posCursor = index;
                }
            } else {
                resultado += mascara[index];
            }
        }

        // Se estiver no final a posição do cursor será o valor do tamanho total
        if (i === 11) {
            posCursor = resultado.length;
        }

        celularInput.value = resultado;

        // Caso não seja passado nenhum valor para forcaCursor ele pega o valor de posCursor
        setTimeout(() => {
            celularInput.setSelectionRange(
                forcarCursor !== null ? forcarCursor : posCursor,
                forcarCursor !== null ? forcarCursor : posCursor
            );
        }, 0);
    }
}