const mensagem = document.getElementById('check_message')

const canvas = document.getElementById('relogio');
const ctx = canvas.getContext('2d');
const radius = canvas.width / 2;
let angle = 0;

const duration = 1.7; // duração da animação em segundos
const fps = 60;
const increment = (2 * Math.PI) / (duration * fps); // quanto aumenta por frame

export function draw() {
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    // Desenha o arco verde preenchendo o círculo
    ctx.beginPath();
    ctx.moveTo(radius, radius); // Começa no centro
    ctx.arc(radius, radius, radius, -Math.PI / 2, -Math.PI / 2 + angle); // Gira a partir do topo
    ctx.closePath();
    ctx.fillStyle = 'rgba(0, 255, 0, 0.6)'; // Verde translúcido
    ctx.fill();

    angle += increment;

    if (angle <= 2 * Math.PI) {
        requestAnimationFrame(draw); // Continua animando
    } else {
        // Quando termina a animação, desenha o check
        ctx.fillStyle = 'white';
        ctx.font = `${radius * 0.8}px Arial`;
        ctx.textAlign = 'center';
        ctx.textBaseline = 'middle';
        ctx.fillText('✔', radius, radius);

        // Mensagem abaixo do círculo
        mensagem.style.display = 'block';
        mensagem.style.color = 'rgba(0, 255, 0, 0.6)';
        mensagem.style.paddingTop = '10px';
        mensagem.style.fontSize = '32px'
        mensagem.style.fontWeight = '700'
        mensagem.style.textAlign = 'center'
    }
}