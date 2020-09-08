$(".escolhaMes").on('change', function () {
    var mesId = $('.escolhaMes').val();

    $.ajax({
        url: "Despesas/GastoMes",
        method: "POST",
        data: { mesId: mesId },
        success: function (dados) {
            //Necessario remover o canvas para depois adiciona-lo, pq senão da BUG
            $('canvas#GraficoGastoMes').remove();
            $('div.GraficoGastoMes').append('<canvas id="GraficoGastoMes" style="width: 400px; height: 400px;"></canvas>');

            var ctx = document.getElementById('GraficoGastoMes').getContext('2d');

            var grafico = new Chart(ctx, {
                type: 'doughnut',
                data: {
                    labels: PegarTiposDespesas(dados),
                    datasets: [{
                        labe: "Gastos por despesa",
                        backgroundColor: PegarCores(dados.length),
                        hoverBackgroundColor: PegarCores(dados.length),
                        data: PegarValores(dados)
                    }],
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Gastos por despesa"
                    }
                }
            });
        }
    });
});

function CarregarDadosGastosMes () {
    var mesId = $('.escolhaMes').val();

    $.ajax({
        url: "Despesas/GastoMes",
        method: "POST",
        data: { mesId: mesId },
        success: function (dados) {
            //Necessario remover o canvas para depois adiciona-lo, pq senão da BUG
            $('canvas#GraficoGastoMes').remove();
            $('div.GraficoGastoMes').append('<canvas id="GraficoGastoMes" style="width: 400px; height: 400px;"></canvas>');

            var ctx = document.getElementById('GraficoGastoMes').getContext('2d');

            var grafico = new Chart(ctx, {
                type: 'doughnut',
                data: {
                    labels: PegarTiposDespesas(dados),
                    datasets: [{
                        labe: "Gastos por despesa",
                        backgroundColor: PegarCores(dados.length),
                        hoverBackgroundColor: PegarCores(dados.length),
                        data: PegarValores(dados)
                    }],
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Gastos por despesa"
                    }
                }
            });
        }
    });
};

function CarregarDadosGastosTotais() {
    $.ajax({
        url: "Despesas/GastosTotais",
        method: "POST",
        success: function (dados) {
            new Chart(document.getElementById("GraficoGastosTotais"), {
                type: 'line',

                data: {
                    labels: PegarMeses(dados),

                    datasets: [{
                        label: "Total Gasto",
                        data: PegarValores(dados),
                        backgroundColor: "#ecf0f1",
                        borderColor: "#2980b9",
                        fill: false,
                        spanGaps: false
                    }]
                },

                options: {
                    title: {
                        display: true,
                        text: "Total Gasto"
                    }
                }
            });
        }
    });
}
$(".escolhaMes").on('change', function () {
    var mesId = $('.escolhaMes').val();

    $.ajax({
        url: "Despesas/GastosTotalMes",
        method: "POST",
        data: { mesId: mesId },
        success: function (dados) {
            //Necessario remover o canvas para depois adiciona-lo, pq senão da BUG
            $('canvas#GraficoGastoTotalMes').remove();
            $('div.GraficoGastoTotalMes').append('<canvas id="GraficoGastoTotalMes" style="width: 400px; height: 400px;"></canvas>');

            var ctx = document.getElementById('GraficoGastoTotalMes').getContext('2d');

            var grafico = new Chart(ctx, {
                type: 'doughnut',
                data: {
                    labels: ['Restante', 'Total Gasto'],
                    datasets: [{
                        labe: "Total Gasto",
                        backgroundColor: ['#27ae60', '#c0392b'],
                        data: [(dados.salario - dados.valorTotalGasto), dados.valorTotalGasto]
                    }],
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Total gasto no Mês"
                    }
                }
            });
        }
    });
});


function CarregarDadosGastosTotalMes () {

    $.ajax({
        url: "Despesas/GastosTotalMes",
        method: "POST",
        data: { mesId: 1 },
        success: function (dados) {
            //Necessario remover o canvas para depois adiciona-lo, pq senão da BUG
            $('canvas#GraficoGastoTotalMes').remove();
            $('div.GraficoGastoTotalMes').append('<canvas id="GraficoGastoTotalMes" style="width: 400px; height: 400px;"></canvas>');

            var ctx = document.getElementById('GraficoGastoTotalMes').getContext('2d');

            var grafico = new Chart(ctx, {
                type: 'doughnut',
                data: {
                    labels: ['Restante', 'Total Gasto'],
                    datasets: [{
                        labe: "Total Gasto",
                        backgroundColor: ['#27ae60', '#c0392b'],
                        data: [(dados.salario - dados.valorTotalGasto), dados.valorTotalGasto]
                    }],
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Total gasto no Mês"
                    }
                }
            });
        }
    });
}
function PegarValores(dados) {
    var valores = [];
    var tamanho = dados.length;
    var indice = 0;

    while (indice < tamanho) {
        valores.push(dados[indice].valores);
        indice++;
    }

    return valores;
}

function PegarTiposDespesas(dados) {
    var labels = [];
    var tamanho = dados.length;
    var indice = 0;

    while (indice < tamanho) {
        labels.push(dados[indice].tiposDespesas);
        indice++;
    }

    return labels;
}

function PegarCores(quantidade) {
    var cores = [];

    while (quantidade > 0) {
        var r = Math.floor(Math.random() * 255);
        var g = Math.floor(Math.random() * 255);
        var b = Math.floor(Math.random() * 255);

        cores.push("rgb(" + r + ", " + g + ", " + b + ")");
        quantidade--;
    }

    return cores;
}

function PegarMeses(dados) {
    var labels = [];
    var tamanho = dados.length;
    var indice = 0;
    while (indice < tamanho) {
        labels.push(dados[indice].nomeMeses);
        indice++;
    }

    return labels;
}
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
