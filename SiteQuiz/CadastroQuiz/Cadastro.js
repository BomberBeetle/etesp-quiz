function RevelarSenha() {
    var txtSenha = document.getElementById("txtSenha");
    var btnRev = document.getElementById("btnRevelar")
    
    if (txtSenha.type == "password") {
        txtSenha.type = "text";
        btnRev.style.backgroundImage = 'url("Imagens/olho.png")';
        //return null;   
    }
    else {
        txtSenha.type = "password";
        btnRev.style.backgroundImage = 'url("Imagens/olho2.png")';
    }
}

function RevelarSenha2() {
    var txtSenha = document.getElementById("txtSenha");
    var btnRev = document.getElementById("btnRevelar2")

    if (txtSenha.type == "password") {
        txtSenha.type = "text";
        btnRev.style.backgroundImage = 'url("Imagens/olho.png")';
        //return null;   
    }
    else {
        txtSenha.type = "password";
        btnRev.style.backgroundImage = 'url("Imagens/olho2.png")';
    }
}

/*Login.aspx*/

function togglePass() {
    if (document.getElementById("showpassField").checked) {
        document.getElementById("passField").type = "text"
    }
    else {
        document.getElementById("passField").type = "password"
    }
}

/*AreaParticipante*/

function MostrarDados() {
    var tamanhoTela = window.innerWidth;
    document.getElementById('divContGrupo').style.display = 'none';
    document.getElementById('divContDados').style.display = 'block';
    document.getElementById('divCorpoAreaParticipante').style.height = '1000px';
    document.getElementById('divGrandeParticipante').style.height = '800px';
    document.getElementById('divConteudoParticipante').style.height = '600px';
    document.getElementById('divContDados').style.height = '550px';
    if (tamanhoTela <= 350) {
        alert('huhgfjkkf');
    }
    else if (tamanhoTela <= 450) {
        document.getElementById('divContGrupo').style.display = 'none';
        document.getElementById('divContDados').style.display = 'block';
        document.getElementById('divCorpoAreaParticipante').style.height = '800px';
        document.getElementById('divGrandeParticipante').style.height = '600px';
        document.getElementById('divConteudoParticipante').style.height = '400px';
        document.getElementById('divContDados').style.height = '350px';
    }
}

function MostrarGrupos() {
    var tamanhoTela = window.innerWidth;
    document.getElementById('divContDados').style.display = 'none';
    document.getElementById('divContGrupo').style.display = 'block';
    document.getElementById('divCorpoAreaParticipante').style.height = '1500px';
    document.getElementById('divGrandeParticipante').style.height = '1300px';
    document.getElementById('divConteudoParticipante').style.height = '1100px';
    document.getElementById('divContGrupo').style.height = '1050px';
    if (tamanhoTela <= 600) {
        document.getElementById('divContDados').style.display = 'none';
        document.getElementById('divContGrupo').style.display = 'block';
        document.getElementById('divCorpoAreaParticipante').style.height = '1600px';
        document.getElementById('divGrandeParticipante').style.height = '1400px';
        document.getElementById('divConteudoParticipante').style.height = '1200px';
        document.getElementById('divContGrupo').style.height = '1150px';
    }
}

function MostrarDados2() {
    document.getElementById('divContQuiz').style.display = 'none';
    document.getElementById('divContDados').style.display = 'block';
    document.getElementById('divCorpoAreaParticipante').style.height = '1000px';
    document.getElementById('divGrandeParticipante').style.height = '800px';
    document.getElementById('divConteudoParticipante').style.height = '600px';
    document.getElementById('divContDados').style.height = '550px';
}

function MostrarQuiz() {
    document.getElementById('divContDados').style.display = 'none';
    document.getElementById('divContQuiz').style.display = 'block';
}

function EsqueceuSenha() {
    document.getElementById('divLogin').style.display = 'none';
    document.getElementById('divEsqueceuSenha').style.display = 'block';
}

function VoltarLogin() {
    document.getElementById('divEsqueceuSenha').style.display = 'none';
    document.getElementById('divLogin').style.display = 'block';
}